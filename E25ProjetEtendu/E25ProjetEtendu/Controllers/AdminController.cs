using E25ProjetEtendu.Models;
using E25ProjetEtendu.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E25ProjetEtendu.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [Authorize(Roles ="Admin")]
        public IActionResult Dashboard()
        {
            return View();
        }

        public async Task<IActionResult> IndexProduits()
        {
            IEnumerable<Produit> produits = await _adminService.GetAllProduits();
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

        ////POST
        //[HttpPost]
        //public async Task<Produit> AddProduct(Produit produit)
        //{

        //}

    }
}
