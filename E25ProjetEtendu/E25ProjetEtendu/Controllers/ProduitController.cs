﻿using E25ProjetEtendu.Models;
using E25ProjetEtendu.ViewModels;
using E25ProjetEtendu.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E25ProjetEtendu.Data;

namespace E25ProjetEtendu.Controllers
{
    public class ProduitController : Controller
    {
        private readonly IProduitService _produitService;
        private readonly ApplicationDbContext _context;
        public ProduitController(IProduitService produitService, ApplicationDbContext context)
        {
            _produitService = produitService;
            _context = context;
        }
        // GET: ProduitController
        /// <summary>
        /// cette methode retourne une liste de produit actif
        /// </summary>
        /// <param name="recherche">le mots clé mise dans la barre de recherche</param>
        /// <param name="page">la page ou l'utilisateur est présentement</param>
        /// <param name="tri">l'option de tri choisi par l'utilisateur</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index(string recherche, string tri, int? categoryId, decimal? minPrice, decimal? maxPrice, int page = 1)
        {
            var (produits, totalProduits) = await _produitService
           .GetFilteredProducts(recherche, tri, page, 20, categoryId, minPrice, maxPrice);


            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalProduits / 20);
            ViewBag.Search = recherche;
            ViewBag.Sort = tri;
            ViewBag.MinPrice = minPrice;
            ViewBag.MaxPrice = maxPrice;
            ViewBag.SelectedCategory = categoryId;

            ViewBag.Categories = await _context.Categories
                .Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.CategoryId.ToString()
                }).ToListAsync();


            return View(produits);
        }



        public async Task<IActionResult> Details(int id)
        {
            var produit = await _produitService.GetProduitById(id);
            if (produit == null)
                return NotFound();

            var similaires = await _produitService.GetProduitsSimilairesAsync(produit);
            ViewBag.ProduitsSimilaires = similaires;

            return View(produit);
        }



        // GET: ProduitController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProduitController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProduitController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProduitController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProduitController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProduitController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Pannier()
        {
            return View(); // juste retourner la vue, sans modèle
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId, int quantity = 1)
        {
            try
            {
                await _produitService.AddToCart(productId, quantity);
                TempData["Success"] = "Produit ajouté au panier !";
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Erreur : {ex.Message}";
            }

            return RedirectToAction("Index"); // ou redirige vers la page souhaitée
        }
        [HttpPost]
        public IActionResult AugmenterProduitAuPannier(int productId)
        {
            _produitService.AugmenteProduitPannier(productId);

            var cart = _produitService.GetCartItems();
            var item = cart.FirstOrDefault(i => i.ProduitId == productId);

            return Json(new
            {
                productId = productId,
                quantity = item?.Quantite ?? 0,
                subtotal = item != null ? item.Prix * item.Quantite : 0,
                total = cart.Sum(i => i.Prix * i.Quantite)
            });
        }

        [HttpPost]
        public IActionResult RetirerProduitDuPannier(int productId)
        {
            _produitService.EnleverProduitPannier(productId);

            var cart = _produitService.GetCartItems();
            var item = cart.FirstOrDefault(i => i.ProduitId == productId);

            return Json(new
            {
                productId = productId,
                quantity = item?.Quantite ?? 0,
                subtotal = item != null ? item.Prix * item.Quantite : 0,
                total = cart.Sum(i => i.Prix * i.Quantite)
            });
        }
        [HttpPost]
        public JsonResult ViderPannier()
        {
            _produitService.VidePannier();
            return Json(new { success = true });
        }


    }
}
