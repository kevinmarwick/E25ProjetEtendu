using E25ProjetEtendu.Data;
using E25ProjetEtendu.Models;
using E25ProjetEtendu.Services.IServices;
using E25ProjetEtendu.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace E25ProjetEtendu.Services
{
    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext _context;
        private readonly IProduitService _produitService;

        public AdminService(ApplicationDbContext context, IProduitService produitService)
        {
            _context = context;
            _produitService = produitService;
        }
        /// <summary>
        /// retourne la liste de produit
        /// </summary>
        /// <returns></returns>
        public async Task<List<Produit>> GetAllProduits(int? categoryId = null, decimal? minPrice = null, decimal? maxPrice = null)
        {
            var query = _context.produits
                .Include(p => p.Category)
                .AsQueryable();

            if (categoryId.HasValue)
                query = query.Where(p => p.CategoryId == categoryId.Value);

            if (minPrice.HasValue)
                query = query.Where(p => p.Prix >= minPrice.Value);

            if (maxPrice.HasValue)
                query = query.Where(p => p.Prix <= maxPrice.Value);

            return await query.ToListAsync();
        }



        /// <summary>
        /// retourne la liste des category
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Category>> GetAllCategory()
        {
            return await _context.Categories.OrderBy(c => c.Name).ToListAsync();
        }
        /// <summary>
        /// Update l'inventaire
        /// </summary>
        /// <param name="produitId"></param>
        /// <param name="qty"></param>
        /// <param name="prix"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task UpdateInventoryAndPrice(int produitId, int qty, decimal prix)
        {
            Produit produit = await _produitService.GetProduitById(produitId);
            if (produit == null)
                throw new Exception("Produit non trouvé");

            produit.InventoryQuantity = qty;
            produit.Prix = prix;

            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// sauvegarde un image
        /// </summary>
        /// <param name="imageFile"></param>
        /// <returns></returns>
        public async Task<string> SaveImage(IFormFile imageFile)
        {
            if (imageFile == null || imageFile.Length == 0)
                return null;

            var fileName = Path.GetFileName(imageFile.FileName);
            var uploadsDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");

            if (!Directory.Exists(uploadsDir))
                Directory.CreateDirectory(uploadsDir);

            var filePath = Path.Combine(uploadsDir, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            return fileName;
        }
        /// <summary>
        /// ajoute une category 
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<Category> AddCategoryFromVM(AddCategoryVM vm)
        {
            bool nameExists = await _context.Categories.AnyAsync(c => c.Name == vm.Name);
            if (nameExists)
            {
                throw new InvalidOperationException("Une catégorie avec ce nom existe déjà.");
            }

            var category = new Category
            {
                Name = vm.Name
            };
            _context.Categories.Add(category);
            await  _context.SaveChangesAsync();
            return category;
        }
        /// <summary>
        /// ajoute un produit
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<Produit> AddProductFromVM(AddProductVM vm)
        {
            var fileName = await SaveImage(vm.ImageFile);
            bool SKUexists = await _context.produits.AnyAsync(p => p.SKU == vm.SKU);
            if (SKUexists)
            {
                throw new InvalidOperationException("ce SKU existe déja");
            }
            var product = new Produit
            {
                Nom = vm.Nom,
                InventoryQuantity = vm.Qty,
                Prix = vm.Prix,
                ValeurNutritive = vm.ValeurNutritive,
                EstActif = vm.EstActif,
                Image = fileName,
                SKU = vm.SKU,
                CategoryId = vm.CategoryId
            };

            _context.produits.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }
        /// <summary>
        /// va chercher le produit a modifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<EditProductVM?> GetEditProductVM(int id)
        {
            var produit = await _produitService.GetProduitById(id);
            if (produit == null) return null;

            var categories = await _context.Categories
                .Select(c => new SelectListItem
                {
                    Value = c.CategoryId.ToString(),
                    Text = c.Name
                }).ToListAsync();

            return new EditProductVM
            {
                ProduitId = produit.ProduitId,
                Nom = produit.Nom,
                ValeurNutritive = produit.ValeurNutritive,
                CurrentImage = produit.Image,
                SKU = produit.SKU,
                CategoryId = produit.CategoryId,
                Categories = categories
            };
        }
        /// <summary>
        /// retourne un selectlist de category
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<SelectListItem>> GetCategoriesSelectList()
        {
            return await _context.Categories
                .Select(c => new SelectListItem
                {
                    Value = c.CategoryId.ToString(),
                    Text = c.Name
                }).ToListAsync();
        }
        /// <summary>
        /// retourne une category avec un id specifique pour le modifier 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Category> GetCategoryById(int id)
        {
            return await _context.Categories.FindAsync(id);
        }
        /// <summary>
        /// modifier une category
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<(bool Success, string? ErrorMessage)> EditCategoryFromVM(EditCategoryVM vm)
        {
            var category = await GetCategoryById(vm.CategoryId);
            if (category == null)
                return (false, "Catégorie introuvable");

            bool nameExists = await _context.Categories
                .AnyAsync(c => c.Name == vm.Name && c.CategoryId != vm.CategoryId);

            if (nameExists)
                return (false, "Ce nom de catégorie existe déjà");

            category.Name = vm.Name;
            await _context.SaveChangesAsync();

            return (true, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<EditCategoryVM> GetEditCategory(int id)
        {
                var category = await GetCategoryById(id);
            if(category == null)
            {
                return null;
            }
            return new EditCategoryVM { Name = category.Name, CategoryId = category.CategoryId};
        }
        /// <summary>
        /// modifie un produit
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<Produit> EditProductFromVM(EditProductVM vm)
        {
            var product = await _produitService.GetProduitById(vm.ProduitId);
            if (product == null)
            {
                throw new Exception("Produit non trouvé");
            }

            // Vérifie si le SKU existe déjà pour un autre produit
            bool SKUexists = await _context.produits
            .AnyAsync(p => p.SKU == vm.SKU && p.ProduitId != vm.ProduitId);
            if (SKUexists)
            {
                throw new InvalidOperationException("Ce SKU existe déjà");
            }
            
            product.Nom = vm.Nom;
            product.ValeurNutritive = vm.ValeurNutritive;
            product.SKU = vm.SKU;
            product.CategoryId = vm.CategoryId;

            if (vm.NewImageFile != null && vm.NewImageFile.Length > 0)
            {
                var fileName = await SaveImage(vm.NewImageFile);
                product.Image = fileName;
            }

            await _context.SaveChangesAsync();
            return product;
        }

       

        /// <summary>
        /// ajoute une balance a un user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="montant"></param>
        /// <returns></returns>
        public async Task<bool> AddBalance(string userId, decimal montant)
        {
            var user = await _context.Users.FindAsync(userId);
            int maxBalance = 1000; // Maximum balance limit
            if (user == null || montant <= 0 || montant + user.Balance > maxBalance)
            {
                return false;
            }
            user.Balance += montant;
            await _context.SaveChangesAsync();
            return true;

        }


    }
}
