using E25ProjetEtendu.Data;
using E25ProjetEtendu.Models;
using E25ProjetEtendu.Services.IServices;
using E25ProjetEtendu.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace E25ProjetEtendu.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly IProduitService _produitService;
        private readonly IUserService _userService;
        private readonly ApplicationDbContext _context;

        public AdminController(IAdminService adminService, IProduitService produitService, IUserService userService, ApplicationDbContext context)
        {
            _adminService = adminService;
            _produitService = produitService;
            _userService = userService;
            _context = context;
        }

        
        public IActionResult Dashboard()
        {
            return View();
        }


        
        public async Task<IActionResult> EditProduct(int id)
        {
            var vm = await _adminService.GetEditProductVM(id);
            if (vm == null)
                return NotFound();

            return View(vm);
        }

        [HttpGet]
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProduct(EditProductVM vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Categories = await _adminService.GetCategoriesSelectList(); // 🟢 ici
                return View(vm);
            }

            try
            {
                await _adminService.EditProductFromVM(vm);
                TempData["SuccessMessage"] = "Produit mis à jour avec succès.";
                return RedirectToAction("IndexProduits");
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("SKU", ex.Message);
                vm.Categories = await _adminService.GetCategoriesSelectList(); // 🟢 aussi ici
                return View(vm);
            }
        }


        public async Task<IActionResult> IndexProduits()
        {
            IEnumerable<Produit> produits = await _adminService.GetAllProducts();
            return View(produits);
        }
        public async Task<IActionResult> IndexCategories()
        {
            IEnumerable<Category> categories = await _adminService.GetAllCategory();
            return View(categories);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            var vm = new AddCategoryVM();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCategory(AddCategoryVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            try
            {
                await _adminService.AddCategoryFromVM(vm);
                TempData["SuccessMessage"] = "Catégory ajoutée avec succès.";
                return RedirectToAction("IndexProduits");
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("Name", ex.Message);
                return View(vm);
            }
        }
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> UpdateInventoryAndPrice(UpdateProductVM model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Les données envoyées sont invalides.");

            await _adminService.UpdateInventoryAndPrice(model.ProduitId, model.Qty, model.Prix);
            return Ok();
        }


        //GET
        [HttpGet]
        public async Task<IActionResult> AddProduct()
        {
            var categories = await _context.Categories
                .Select(c => new SelectListItem
                {
                    Value = c.CategoryId.ToString(),
                    Text = c.Name
                })
                .ToListAsync();

            var vm = new AddProductVM
            {
                Categories = categories
            };

            return View(vm);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProduct(AddProductVM vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Categories = await _context.Categories
                    .Select(c => new SelectListItem
                    {
                        Value = c.CategoryId.ToString(),
                        Text = c.Name
                    })
                    .ToListAsync();
                return View(vm);
            }

            try
            {
                await _adminService.AddProductFromVM(vm);
                TempData["SuccessMessage"] = "Produit créé avec succès.";
                return RedirectToAction("AddProduct");
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("SKU", ex.Message);

                vm.Categories = await _context.Categories
                    .Select(c => new SelectListItem
                    {
                        Value = c.CategoryId.ToString(),
                        Text = c.Name
                    })
                    .ToListAsync();

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
            var success = await _userService.GiveDelivererRights(userId);
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
