using E25ProjetEtendu.Data;
using E25ProjetEtendu.Models;
using E25ProjetEtendu.Services.IServices;
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

        public Task<Produit> AddProduct(Produit produit)
        {
            throw new NotImplementedException();
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
		public async Task EditProduct(Produit product, IFormFile imageFile)
		{
			var dbProduit = await _produitService.GetProduitById(product.ProduitId);
			if (dbProduit == null)
				throw new Exception("Produit non trouvé");

			dbProduit.Nom = product.Nom;
			dbProduit.ValeurNutritive = product.ValeurNutritive;

			if (imageFile != null && imageFile.Length > 0)
			{
				var fileName = Path.GetFileName(imageFile.FileName);
				var uploadsDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");

				if (!Directory.Exists(uploadsDir))
					Directory.CreateDirectory(uploadsDir);

				var filePath = Path.Combine(uploadsDir, fileName);
				using (var stream = new FileStream(filePath, FileMode.Create))
				{
					await imageFile.CopyToAsync(stream);
				}

				dbProduit.Image = fileName;
			}

			await _context.SaveChangesAsync();
		}
	}
}
