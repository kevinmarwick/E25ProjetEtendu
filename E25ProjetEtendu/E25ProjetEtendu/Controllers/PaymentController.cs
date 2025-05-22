using E25ProjetEtendu.Data;
using E25ProjetEtendu.Models.DTOs;
using E25ProjetEtendu.Services.IServices;
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

            Console.WriteLine("Raw JSON:");
            Console.WriteLine(panierJson);

            var panier = JsonConvert.DeserializeObject<List<ProduitPanier>>(panierJson);

            var cartItems = panier.Select(p => new CartItemDTO
            {
                ProductId = p.ProduitId,
                Quantity = p.Quantite
            }).ToList();


            

            // Réserver les stocks
            bool reserved = await _produitService.ReserveStock(cartItems, userId);
            if (!reserved)
            {
                TempData["Error"] = "Certains produits ne sont plus disponibles en quantité suffisante.";
                return RedirectToAction("Pannier", "Produit");
            }

            //  Calcul global
            const decimal TPS = 0.05m;
            const decimal TVQ = 0.09975m;

            decimal sousTotal = panier.Sum(p => p.Prix * p.Quantite);
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

            bool created = await _orderService.TryCreateOrderFromReservation(userId);

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
