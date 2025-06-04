using E25ProjetEtendu.Models;
using E25ProjetEtendu.Services.IServices;
using E25ProjetEtendu.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace E25ProjetEtendu.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly IProduitService _produitService;
        private readonly IUserService _userService;

        public AdminController(IAdminService adminService, IProduitService produitService, IUserService userService)
        {
            _adminService = adminService;
            _produitService = produitService;
            _userService = userService;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Dashboard()
        {
            return View();
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditProduct(int id)
        {
            var vm = await _adminService.GetEditProductVM(id);
            if (vm == null)
                return NotFound();

            return View(vm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProduct(EditProductVM vm)
        {
            if (!ModelState.IsValid)
                return View(vm);
            try
            {
                await _adminService.EditProductFromVM(vm);
                TempData["SuccessMessage"] = "Produit mis à jour avec succès.";
                return RedirectToAction("IndexProduits");
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("SKU", ex.Message);
                return View(vm);
            }

        }


        public async Task<IActionResult> IndexProduits()
        {
            IEnumerable<Produit> produits = await _adminService.GetAllProducts();
            return View(produits);
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> UpdateInventoryAndPrice(UpdateProductVM model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Les données envoyées sont invalides.");

            await _adminService.UpdateInventoryAndPrice(model.ProduitId, model.Qty, model.Prix);
            return Ok();
        }


        //GET
        public async Task<IActionResult> AddProduct()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProduct(AddProductVM vm)
        {
            if (!ModelState.IsValid)
                return View(vm);
            try
            {
                await _adminService.AddProductFromVM(vm);
                TempData["SuccessMessage"] = "Produit créé avec succès.";
                return RedirectToAction("AddProduct");
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("SKU", ex.Message);
                return View(vm);
            }



        }

        public async Task<IActionResult> IndexUsers()
        {
            List<UserViewModel> users = await _userService.GetNonPrivilegedUsers();
            return View(users);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GiveDelivererRole(string userId)
        {
            try
            {
                ApplicationUser? user = await _userService.GetUserById(userId);

                //Make sure the user has a phone number before giving the deliverer role
                if (user != null && user.PhoneNumber == null)
                {
                    TempData["Error"] = "L'utilisateur doit avoir un numéro de téléphone sauvegardé";
                    return RedirectToAction("IndexUsers");
                }

                //Give the deliverer role
                bool success = await _userService.GiveDelivererRights(userId);

                if (!success)
                {
                    TempData["Error"] = "Échec lors de l'ajout du rôle 'Livreur'.";
                }
                else
                {
                    TempData["Success"] = "Rôle 'Livreur' attribué avec succès.";
                }

                return RedirectToAction("IndexUsers");
            }
            catch
            {
                TempData["Error"] = "Utilisateur non trouvé ou erreur lors de l'attribution du rôle 'Livreur'.";
                return RedirectToAction("IndexUsers");
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveDelivererRole(string userId)
        {
            var success = await _userService.RemoveDelivererRights(userId);
            if (!success)
            {
                TempData["Error"] = "Échec lors du retrait du rôle 'Livreur'.";
            }
            else
            {
                TempData["Success"] = "Rôle 'Livreur' retiré avec succès.";
            }

            return RedirectToAction("IndexUsers");
        }
        [HttpPost]
        public async Task<IActionResult> AddBalance(UserViewModel model)
        {
            if (string.IsNullOrEmpty(model.Id) || model.Balance <= 0)
            {
                TempData["Error"] = "Identifiant utilisateur invalide ou montant incorrect.";
                return RedirectToAction("IndexUsers");
            }

            var success = await _adminService.AddBalance(model.Id, model.Balance);
            if (!success)
            {
                TempData["Error"] = "Échec lors de l'ajout du solde. Assurez-vous que l'utilisateur existe et que le montant est valide.";
            }
            else
            {
                TempData["Success"] = $"Solde ajouté avec succès à l'utilisateur {model.FullName}.";
            }

            return RedirectToAction("IndexUsers");
        }

    }


}
