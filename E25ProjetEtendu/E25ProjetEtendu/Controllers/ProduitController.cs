using E25ProjetEtendu.Models;
using E25ProjetEtendu.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace E25ProjetEtendu.Controllers
{
    public class ProduitController : Controller
    {
        private readonly IProduitService _produitService;

        public ProduitController(IProduitService produitService)
        {
            _produitService = produitService;
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
        public async Task<ActionResult> Index(string recherche, int page = 1, string tri = "")
        {
            const int pageSize = 5;

            (List<Produit> produits, int totalProduits) = await _produitService.GetFilteredProductsAsync(recherche, tri, page, pageSize);

            ViewBag.Search = recherche;
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalProduits / pageSize);
            ViewBag.Sort = tri;

            return View(produits);
        }


        // GET: ProduitController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
    }
}
