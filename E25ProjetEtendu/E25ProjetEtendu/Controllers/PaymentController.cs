using E25ProjetEtendu.DTO;
using E25ProjetEtendu.Models.DTOs;
using E25ProjetEtendu.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Stripe.Checkout;
using System.Security.Claims;


namespace TonProjet.Controllers
{
    public class PaymentController : Controller
    {
        public readonly IProduitService _produitService;
        public PaymentController(IProduitService produitService)
        {
            _produitService = produitService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCheckoutSession(string panierJson)
        {
            var cartItems = JsonConvert.DeserializeObject<List<CartItemDTO>>(panierJson);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            bool reserved = await _produitService.ReserveStock(cartItems, userId);
            if (!reserved)
            {
                TempData["Error"] = "Certains produits ne sont plus disponibles en quantité suffisante.";
                return RedirectToAction("Panier", "Produit");
            }


            var panier = JsonConvert.DeserializeObject<List<ProduitPanier>>(panierJson);
            var lineItems = new List<SessionLineItemOptions>();

            foreach (var item in panier)
            {
                lineItems.Add(new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = (long)(item.Prix * 100),
                        Currency = "cad",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = item.Nom
                        }
                    },
                    Quantity = item.Quantite
                });
            }

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = lineItems,
                Mode = "payment",
                SuccessUrl = "https://localhost:7135/Payment/Success",
                CancelUrl = "https://localhost:7135/Payment/Cancel"
            };

            var service = new SessionService();
            Session session = service.Create(options);

            return Redirect(session.Url);
        }


        public async Task<IActionResult> Success()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _produitService.FinalizeReservation(userId);

            return View();
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
