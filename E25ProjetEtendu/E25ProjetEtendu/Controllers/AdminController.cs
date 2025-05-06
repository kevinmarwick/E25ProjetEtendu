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

        public AdminController(IAdminService adminService, IProduitService produitService)
        {
            _adminService = adminService;
            _produitService = produitService;
        }

        [Authorize(Roles ="Admin")]
        public IActionResult Dashboard()
        {
            return View();
        }

        // GET: Produit/Edit/id
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditProduct(int id)
        {
            var produit = await _produitService.GetProduitById(id);
            if (produit == null)
                return NotFound();

            var vm = new EditProductVM
            {
                ProduitId = produit.ProduitId,
                Nom = produit.Nom,
                ValeurNutritive = produit.ValeurNutritive,
                CurrentImage = produit.Image
            };

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
        public async Task<IActionResult> UpdateInventoryAndPrice(int produitId, int qty, decimal prix)
        {
            try
            {
                await _adminService.UpdateInventoryAndPrice(produitId, qty, prix);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
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




    }
}
