using E25ProjetEtendu.Data;
using E25ProjetEtendu.Models.DTOs;
using E25ProjetEtendu.Services.IServices;
using E25ProjetEtendu.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Stripe.Checkout;
using System.Security.Claims;


namespace TonProjet.Controllers
{
    public class PaymentController : Controller
    {
        public readonly ApplicationDbContext _context;
        public readonly IOrderService _orderService;
        public readonly IProduitService _produitService;
        public PaymentController(ApplicationDbContext context,IOrderService orderService, IProduitService produitService)
        {
            _context = context;
            _orderService = orderService;
            _produitService = produitService;
        }

        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> CreateCheckoutSession(string panierJson)
        //{
        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        //    var existingOrder = await _orderService.GetActiveOrder(userId);
        //    if (existingOrder != null)
        //    {
        //        TempData["Error"] = "Vous avez déjà une commande en cours.";
        //        return RedirectToAction("Pannier", "Produit");
        //    }

        //    var dto = JsonConvert.DeserializeObject<OrderRequestDTO>(panierJson);

        //    // Store delivery location temporarily so it can be used in Success() post-payment
        //    TempData["LastDeliveryLocation"] = dto.Location;

        //    // Réserver les stocks
        //    bool reserved = await _produitService.ReserveStock(dto.Items, userId);
        //    if (!reserved)
        //    {
        //        TempData["Error"] = "Certains produits ne sont plus disponibles en quantité suffisante.";
        //        return RedirectToAction("Pannier", "Produit");
        //    }

        //    //  Calcul global
        //    const decimal TPS = 0.05m;
        //    const decimal TVQ = 0.09975m;

        //    // Get product prices
        //    var produits = await _context.produits
        //        .Where(p => dto.Items.Select(i => i.ProductId).Contains(p.ProduitId))
        //        .ToListAsync();

        //    // Subtotal calculation using matched prices
        //    decimal sousTotal = dto.Items.Sum(item =>
        //    {
        //        var produit = produits.First(p => p.ProduitId == item.ProductId);
        //        return produit.Prix * item.Quantity;
        //    });

        //    decimal tps = sousTotal * TPS;
        //    decimal tvq = sousTotal * TVQ;
        //    decimal totalTTC = sousTotal + tps + tvq;

            
        //    var lineItems = new List<SessionLineItemOptions>
        //    {
        //        new SessionLineItemOptions
        //        {
        //            PriceData = new SessionLineItemPriceDataOptions
        //            {
        //                UnitAmount = (long)(totalTTC * 100), // en cents
        //                Currency = "cad",
        //                ProductData = new SessionLineItemPriceDataProductDataOptions
        //                {
        //                    Name = "Commande complète (taxes incluses)"
        //                }
        //            },
        //            Quantity = 1
        //        }
        //    };

            
        //    var options = new SessionCreateOptions
        //    {
        //        PaymentMethodTypes = new List<string> { "card" },
        //        LineItems = lineItems,
        //        Mode = "payment",
        //        SuccessUrl = Url.Action("Success", "Payment", null, Request.Scheme),
        //        CancelUrl = Url.Action("Cancel", "Payment", null, Request.Scheme)
        //    };

        //    var service = new SessionService();
        //    var session = await service.CreateAsync(options);
           


        //    return Redirect(session.Url);
        //}



        public async Task<IActionResult> Success()
        {
            //Temporaire, afin de montrer commande terminée
            HttpContext.Session.SetString("DeliveredOrderSeen", "false");


            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var location = TempData["LastDeliveryLocation"]?.ToString() ?? "Non spécifiée";

            bool created = await _orderService.TryCreateOrderFromReservation(userId, location);


            if (!created)
            {
                TempData["Error"] = "Votre session de paiement a expiré. Aucun produit n’a été commandé mais le paiement a peut-être été authorisé.  Veuillez contacter l'ADEPT.";
                return RedirectToAction("Pannier", "Produit");
            }
            else
            {
				HttpContext.Session.Remove("CancelledOrderSeen");
				await _produitService.FinalizeReservation(userId);

                //Utilisé dans CurrentOrderStatus afin de vider le panier au succès de la commande
                TempData["ClearCart"] = "true";

                return RedirectToAction("CurrentOrderStatus", "Order");
			}          

		}

		public async Task<IActionResult> Cancel()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _produitService.CancelReservation(userId);

            TempData["Error"] = "Paiement annulé. Les articles ont été remis en stock.";
            return RedirectToAction("Pannier", "Produit");
        }
        /// <summary>
        /// // Soumet le paiement pour le panier en cours.
        /// </summary>
        /// <param name="panierJson"></param>
        /// <param name="paymentMethod"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SubmitPayment(string panierJson, string paymentMethod)
        {
            // Recuperer l'identifiant de l'utilisateur connecte
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Deserialiser le panier recu en JSON
            var dto = JsonConvert.DeserializeObject<OrderRequestDTO>(panierJson);

            // Enregistrer temporairement le lieu de livraison pour l'utiliser apres paiement
            TempData["LastDeliveryLocation"] = dto.Location;

            // Taux de taxes
            const decimal TPS = 0.05m;
            const decimal TVQ = 0.09975m;

            // Recuperer les produits correspondants aux identifiants dans le panier
            var produits = await _context.produits
                .Where(p => dto.Items.Select(i => i.ProductId).Contains(p.ProduitId))
                .ToListAsync();

            // Calcul du sous-total
            decimal sousTotal = dto.Items.Sum(item =>
            {
                var produit = produits.First(p => p.ProduitId == item.ProductId);
                return produit.Prix * item.Quantity;
            });

            // Calcul des taxes et du total TTC
            decimal tps = sousTotal * TPS;
            decimal tvq = sousTotal * TVQ;
            decimal totalTTC = sousTotal + tps + tvq;

            // Recuperer l'utilisateur
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                TempData["Error"] = "Utilisateur introuvable.";
                return RedirectToAction("Pannier", "Produit");
            }

            // Paiement avec solde du compte
            if (paymentMethod == "solde")
            {
                if (user.Balance >= totalTTC)
                {
                    // Reservation du stock
                    bool reserved = await _produitService.ReserveStock(dto.Items, userId);
                    if (!reserved)
                    {
                        TempData["Error"] = "Stock insuffisant.";
                        return RedirectToAction("Pannier", "Produit");
                    }

                    // Mise a jour de la balance utilisateur
                    user.Balance -= totalTTC;
                    await _context.SaveChangesAsync();

                    // Creation de la commande
                    bool created = await _orderService.TryCreateOrderFromReservation(userId, dto.Location);
                    if (created)
                    {
                        await _produitService.FinalizeReservation(userId);
                        TempData["ClearCart"] = "true";
                        return RedirectToAction("CurrentOrderStatus", "Order");
                    }
                    else
                    {
                        TempData["Error"] = "Erreur lors de la creation de la commande.";
                        return RedirectToAction("Pannier", "Produit");
                    }
                }
                else
                {
                    TempData["Error"] = "Solde insuffisant.";
                    return RedirectToAction("Pannier", "Produit");
                }
            }

            // Paiement par carte de credit via Stripe
            bool stripeReserved = await _produitService.ReserveStock(dto.Items, userId);
            if (!stripeReserved)
            {
                TempData["Error"] = "Certains produits ne sont plus disponibles en quantite suffisante.";
                return RedirectToAction("Pannier", "Produit");
            }

            // Preparer les lignes Stripe avec le total TTC
            var lineItems = new List<SessionLineItemOptions>
    {
        new SessionLineItemOptions
        {
            PriceData = new SessionLineItemPriceDataOptions
            {
                UnitAmount = (long)(totalTTC * 100),
                Currency = "cad",
                ProductData = new SessionLineItemPriceDataProductDataOptions
                {
                    Name = "Commande complete (taxes incluses)"
                }
            },
            Quantity = 1
        }
    };

            // Creation de la session Stripe
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = lineItems,
                Mode = "payment",
                SuccessUrl = Url.Action("Success", "Payment", null, Request.Scheme),
                CancelUrl = Url.Action("Cancel", "Payment", null, Request.Scheme)
            };

            var service = new SessionService();
            var session = await service.CreateAsync(options);

            // Redirection vers la page de paiement Stripe
            return Redirect(session.Url);
        }





    }
}
