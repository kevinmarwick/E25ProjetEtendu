using E25ProjetEtendu.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Stripe.Checkout;

namespace TonProjet.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCheckoutSession(string panierJson)
        {
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

        public IActionResult Success() => View();
        public IActionResult Cancel() => View();
    }
}
