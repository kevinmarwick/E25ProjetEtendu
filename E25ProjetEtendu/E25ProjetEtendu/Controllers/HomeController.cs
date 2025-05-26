using E25ProjetEtendu.Models;
using E25ProjetEtendu.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace E25ProjetEtendu.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProduitService _produitService;

        public HomeController(ILogger<HomeController> logger, IProduitService produitService)
        {
            _logger = logger;
            _produitService = produitService;
        }

        public async Task<IActionResult> Index(int note = 5)
        {
                
                var produitsPopulaires = await _produitService.GetProduitsPopulaires(note); // À créer
                return View(produitsPopulaires);
            

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
