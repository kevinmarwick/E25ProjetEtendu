using E25ProjetEtendu.Data;
using E25ProjetEtendu.Models;
using E25ProjetEtendu.Services;
using E25ProjetEtendu.Services.IServices;
using E25ProjetEtendu.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stripe.Climate;

namespace E25ProjetEtendu.Controllers
{
    [Authorize(Roles = "Delivery")]
    public class DeliveryController : Controller
    {
        private readonly IDeliveryService _deliveryService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly SmsService _smsService;
        

        public DeliveryController(IDeliveryService deliveryService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext dbContext, SmsService smsService)
        {
            _deliveryService = deliveryService;
            _userManager = userManager;
            _signInManager = signInManager;
            _smsService = smsService;            

        }

        public async Task<IActionResult> Index()
        {
            var nextOrder = await _deliveryService.GetUnassignedOrder();
            var assignedOrders = await _deliveryService.GetAssignedOrders();

            var vm = new DeliveryVM
            {
                NextOrder = nextOrder,
                AssignedOrders = assignedOrders
            };

            return View(vm);
        }

        public async Task<IActionResult> DeliveryHistories()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmDelivery(int orderId, string email, string password)
        {
            const int MaxAttempts = 3;
            var emailKey = $"DeliveryLoginAttempts_{email.ToLower()}";
            int attempts = HttpContext.Session.GetInt32(emailKey) ?? 0;

            if (attempts >= MaxAttempts)
            {
                TempData["Erreur"] = "Vous avez dépassé le nombre maximal de tentatives pour cette adresse courriel.";
                return RedirectToAction("Index");
            }

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                attempts++;
                HttpContext.Session.SetInt32(emailKey, attempts);
                TempData["Erreur"] = $"Utilisateur non trouvé. Tentative {attempts} sur {MaxAttempts}.";
                return RedirectToAction("Index");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (!result.Succeeded)
            {
                attempts++;
                HttpContext.Session.SetInt32(emailKey, attempts);

                if (attempts >= MaxAttempts)
                {
                    TempData["Erreur"] = "Trop de tentatives échouées pour cet utilisateur.";
                }
                else
                {
                    TempData["Erreur"] = $"Mot de passe invalide. Tentative {attempts} sur {MaxAttempts}.";
                }

                return RedirectToAction("Index");
            }

            // Connexion réussie — on supprime les tentatives pour cet email
            HttpContext.Session.Remove(emailKey);

            var assignationReussie = await _deliveryService.AssignerCommandeAuLivreur(orderId, user.Id);
            if (!assignationReussie)
            {
                TempData["Erreur"] = "La commande n'est plus disponible.";
                return RedirectToAction("Index");
            }

            TempData["Succès"] = "Commande acceptée avec succès.";
            await _smsService.EnvoyerLienConfirmationAuLivreur(user.PhoneNumber, orderId);

            return RedirectToAction("Index");
        }




    }

}
