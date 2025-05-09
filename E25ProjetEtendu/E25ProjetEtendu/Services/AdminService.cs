using E25ProjetEtendu.Data;
using E25ProjetEtendu.Models;
using E25ProjetEtendu.Services.IServices;
using E25ProjetEtendu.ViewModels;
using Microsoft.AspNetCore.Mvc;
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



        public async Task<IEnumerable<Produit>> GetAllProducts()
        {
            return await _context.produits.OrderBy(p => p.Nom)
                                          .ToListAsync();
        }

        public async Task UpdateInventoryAndPrice(int produitId, int qty, decimal prix)
        {
            Produit produit = await _produitService.GetProduitById(produitId);
            if (produit == null)
                throw new Exception("Produit non trouvé");

            produit.Qty = qty;
            produit.Prix = prix;

            await _context.SaveChangesAsync();
        }

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

      
        public async Task<Produit> AddProductFromVM(AddProductVM vm)
        {
            var fileName = await SaveImage(vm.ImageFile);

            var product = new Produit
            {
                Nom = vm.Nom,
                Qty = vm.Qty,
                Prix = vm.Prix,
                ValeurNutritive = vm.ValeurNutritive,
                EstActif = vm.EstActif,
                Image = fileName
            };

            _context.produits.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<EditProductVM?> GetEditProductVM(int id)
        {
            var produit = await _produitService.GetProduitById(id);
            if (produit == null) return null;

            return new EditProductVM
            {
                ProduitId = produit.ProduitId,
                Nom = produit.Nom,
                ValeurNutritive = produit.ValeurNutritive,
                CurrentImage = produit.Image
            };
        }

        public async Task<Produit> EditProductFromVM(EditProductVM vm)
        {
            var product = await _produitService.GetProduitById(vm.ProduitId);
            if (product == null)
                throw new Exception("Produit non trouvé");

            product.Nom = vm.Nom;
            product.ValeurNutritive = vm.ValeurNutritive;

            if (vm.NewImageFile != null && vm.NewImageFile.Length > 0)
            {
                var fileName = await SaveImage(vm.NewImageFile);
                product.Image = fileName;
            }

            await _context.SaveChangesAsync();
            return product;
        }

    }
}
