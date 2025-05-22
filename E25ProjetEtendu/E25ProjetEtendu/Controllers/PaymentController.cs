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

        [HttpPost]
        public async Task<IActionResult> CreateCheckoutSession(string panierJson)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var existingOrder = await _orderService.GetActiveOrder(userId);
            if (existingOrder != null)
            {
                TempData["Error"] = "Vous avez déjà une commande en cours.";
                return RedirectToAction("Pannier", "Produit");
            }

            var dto = JsonConvert.DeserializeObject<OrderRequestDTO>(panierJson);

            // Store delivery location temporarily so it can be used in Success() post-payment
            TempData["LastDeliveryLocation"] = dto.Location;





            // Réserver les stocks
            bool reserved = await _produitService.ReserveStock(dto.Items, userId);
            if (!reserved)
            {
                TempData["Error"] = "Certains produits ne sont plus disponibles en quantité suffisante.";
                return RedirectToAction("Pannier", "Produit");
            }

            //  Calcul global
            const decimal TPS = 0.05m;
            const decimal TVQ = 0.09975m;

            // Get product prices
            var produits = await _context.produits
                .Where(p => dto.Items.Select(i => i.ProductId).Contains(p.ProduitId))
                .ToListAsync();

            // Subtotal calculation using matched prices
            decimal sousTotal = dto.Items.Sum(item =>
            {
                var produit = produits.First(p => p.ProduitId == item.ProductId);
                return produit.Prix * item.Quantity;
            });

            decimal tps = sousTotal * TPS;
            decimal tvq = sousTotal * TVQ;
            decimal totalTTC = sousTotal + tps + tvq;

            
            var lineItems = new List<SessionLineItemOptions>
            {
                new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = (long)(totalTTC * 100), // en cents
                        Currency = "cad",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = "Commande complète (taxes incluses)"
                        }
                    },
                    Quantity = 1
                }
            };

            
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
           


            return Redirect(session.Url);
        }



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

    }
}
