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
            Console.WriteLine("Raw JSON:");
            Console.WriteLine(panierJson);

            var panier = JsonConvert.DeserializeObject<List<ProduitPanier>>(panierJson);
            var cartItems = panier.Select(p => new CartItemDTO
            {
                ProductId = p.ProduitId,
                Quantity = p.Quantite
            }).ToList();


            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            bool reserved = await _produitService.ReserveStock(cartItems, userId);
            if (!reserved)
            {
                TempData["Error"] = "Certains produits ne sont plus disponibles en quantité suffisante.";
                return RedirectToAction("Pannier", "Produit");
            }

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
                SuccessUrl = Url.Action("Success", "Payment", null, Request.Scheme),
                CancelUrl = Url.Action("Cancel", "Payment", null, Request.Scheme)

            };

            var service = new SessionService();
            Session session = await service.CreateAsync(options);


            return Redirect(session.Url);
        }


        public async Task<IActionResult> Success()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            bool created = await _orderService.TryCreateOrderFromReservation(userId);

            if (!created)
            {
                TempData["Error"] = "Votre session de paiement a expiré. Aucun produit n’a été commandé mais le paiement a peut-être été authorisé.  Veuillez contacter l'ADEPT.";
                return RedirectToAction("Pannier", "Produit");
            }

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
