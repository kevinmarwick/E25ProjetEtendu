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

        [Authorize(Roles ="Admin")]
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

            await _adminService.EditProductFromVM(vm);
            TempData["SuccessMessage"] = "Produit mis à jour avec succès.";
            return RedirectToAction("IndexProduits");
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

            await _adminService.AddProductFromVM(vm);

            TempData["SuccessMessage"] = "Produit créé avec succès.";
            return RedirectToAction("AddProduct");
        }

        public async Task<IActionResult> IndexUsers()
        {
            List<ApplicationUser>  users = await _userService.GetAllUsers();
            return View(users);
        }
    }
}
