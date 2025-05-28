using E25ProjetEtendu.Configuration;
using E25ProjetEtendu.Data;
using E25ProjetEtendu.Models;
using E25ProjetEtendu.Services;
using E25ProjetEtendu.Services.IServices;
using E25ProjetEtendu.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Stripe.Climate;

namespace E25ProjetEtendu.Controllers
{
    [Authorize(Roles = "DeliveryStation")]
    public class DeliveryController : Controller
    {
        private readonly IDeliveryService _deliveryService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly SmsService _smsService;
        private readonly IEmailSender _emailSender;
        private readonly IOptions<AdminSettings> _adminSettings;


        public DeliveryController(IDeliveryService deliveryService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext dbContext, SmsService smsService, IEmailSender emailSender)
        {
            _deliveryService = deliveryService;
            _userManager = userManager;
            _signInManager = signInManager;
            _smsService = smsService;
            _emailSender = emailSender;

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
        public async Task<IActionResult> ConfirmDelivery(int orderId, string email, string password)
        {
            //const int MaxAttempts = 3;
            //var emailKey = $"DeliveryLoginAttempts_{email.ToLower()}";
            //int attempts = HttpContext.Session.GetInt32(emailKey) ?? 0;

            //if (attempts >= MaxAttempts)
            //{
            //    TempData["Erreur"] = "Vous avez dépassé le nombre maximal de tentatives pour cette adresse courriel.";
            //    return RedirectToAction("Index");
            //}

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                //attempts++;
                //HttpContext.Session.SetInt32(emailKey, attempts);
                TempData["Erreur"] = "Utilisateur non trouvé";
                await _emailSender.SendEmailAsync(
                    _adminSettings.Value.Email,
                    $"Tentative de connexion non autorisée par {email}",
                    $"<p>L'utilisateur <strong>{email}</strong> ({user.FullName} ID:{user.Id}) s'est connecté avec succès mais <strong>n'a pas le rôle 'Livreur'</strong>. Tentative d'assignation de commande #{orderId} bloquée.</p>"
                );

                return RedirectToAction("Index");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (!result.Succeeded)
            {
                //attempts++;
                //HttpContext.Session.SetInt32(emailKey, attempts);

                //if (attempts >= MaxAttempts)
                //{
                //    TempData["Erreur"] = "Trop de tentatives échouées pour cet utilisateur.";
                //}
                //else
                //{
                //    TempData["Erreur"] = $"Mot de passe invalide. Tentative {attempts} sur {MaxAttempts}.";
                //}

                TempData["Erreur"] = "Mot de passe invalide.";
                await _emailSender.SendEmailAsync(
                    _adminSettings.Value.Email,
                    $"Échec d'authentification: {email}",
                    $"Échec d'authentification pour {email} ({user.FullName} ID:{user.Id}) — mot de passe invalide."
                );

                return RedirectToAction("Index");
            }

            //// Connexion réussie — on supprime les tentatives pour cet email
            //HttpContext.Session.Remove(emailKey);

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
