using E25ProjetEtendu.Data;
using E25ProjetEtendu.Models;
using E25ProjetEtendu.Services.IServices;
using E25ProjetEtendu.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E25ProjetEtendu.Controllers
{
    [Authorize(Roles = "Delivery")]
    public class DeliveryController : Controller
    {
        private readonly IDeliveryService _deliveryService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        

        public DeliveryController(IDeliveryService deliveryService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext dbContext)
        {
            _deliveryService = deliveryService;
            _userManager = userManager;
            _signInManager = signInManager;
            

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
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                ModelState.AddModelError("", "Utilisateur non trouvé.");
                return RedirectToAction("Index");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Mot de passe invalide.");
                return RedirectToAction("Index");
            }

            var assignationReussie = await _deliveryService.AssignerCommandeAuLivreur(orderId, user.Id);
            if (!assignationReussie)
            {
                TempData["Erreur"] = "La commande n'est plus disponible.";
                return RedirectToAction("Index");
            }

            TempData["Succès"] = "Commande acceptée avec succès.";
            return RedirectToAction("Index"); 
        }


    }

}
