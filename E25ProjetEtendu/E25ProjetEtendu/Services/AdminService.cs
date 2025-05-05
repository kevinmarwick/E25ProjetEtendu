using E25ProjetEtendu.Data;
using E25ProjetEtendu.Models;
using E25ProjetEtendu.Services.IServices;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<Produit>> GetAllProduits()
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
    }
}
