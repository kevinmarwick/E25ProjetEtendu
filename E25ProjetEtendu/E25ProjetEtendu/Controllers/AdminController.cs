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
            catch(InvalidOperationException ex)
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
            catch(InvalidOperationException ex)
            {
                ModelState.AddModelError("SKU", ex.Message);
                return View(vm);
            }
            

            
        }
    }
}
