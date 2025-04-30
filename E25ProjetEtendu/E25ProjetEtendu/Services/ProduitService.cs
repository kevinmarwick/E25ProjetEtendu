using E25ProjetEtendu.Data;
using E25ProjetEtendu.Models;
using E25ProjetEtendu.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace E25ProjetEtendu.Services
{
    public class ProduitService : IProduitService
    {
        private readonly ApplicationDbContext _context;

        public ProduitService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Produit>> GetAllActifProduct()
        {
            return await _context.produits.Where(p => p.EstActif)
                                          .OrderBy(p => p.Nom)
                                          .ToListAsync();
        }    
                 
        public async Task<(List<Produit> produits, int totalProduits)> GetFilteredProductsAsync(string recherche, string tri, int page, int pageSize)
        {
            IQueryable<Produit> query = _context.produits.Where(p => p.EstActif);

            if (!string.IsNullOrWhiteSpace(recherche))
            {
                query = query.Where(p => p.Nom.ToLower().Contains(recherche.ToLower()));
            }

            // tri
            query = tri?.ToLower() switch
            {
                "prix" => query.OrderBy(p => p.Prix),
                "note" => query.OrderByDescending(p => p.Note),
                "popularite" => query.OrderByDescending(p => p.Qty),
                _ => query.OrderBy(p => p.Nom)
            };

            int totalProduits = await query.CountAsync();

            var produits = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (produits, totalProduits);
        }



    }
}
