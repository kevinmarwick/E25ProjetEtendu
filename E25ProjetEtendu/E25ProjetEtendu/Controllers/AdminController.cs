﻿using E25ProjetEtendu.Models;
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
            {
                return NotFound();
            }

            return View(produit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProduct(int id, Produit product, IFormFile ImageFile)
		{
            if (id != product.ProduitId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
				await _adminService.EditProduct(product, ImageFile);
				ViewBag.SuccessMessage = " Produit mis à jour avec succès.";
                return RedirectToAction("IndexProduits");

            }

            return View(product);
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
        public async Task<IActionResult> AddProduct(AddProduitViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            await _adminService.AddProductFromViewModel(vm);

            ViewBag.SuccessMessage = "Produit créé avec succès.";
            return RedirectToAction("AddProduct");
        }




    }
}
