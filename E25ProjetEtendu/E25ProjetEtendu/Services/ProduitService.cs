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
        public async Task<IEnumerable<Produit>> SearchProductsAsync(string recherche)
        {
            return await _context.produits
                .Where(p => p.EstActif && p.Nom.ToLower().Contains(recherche.ToLower()))
                .OrderBy(p => p.Nom)
                .ToListAsync();
        }
        public async Task<IEnumerable<Produit>> GetProductsPageAsync(int pageNumber, int pageSize)
        {
            return await _context.produits
                .Where(p => p.EstActif)
                .OrderBy(p => p.Nom)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
        public async Task<int> CountActifProductsAsync()
        {
            return await _context.produits.CountAsync(p => p.EstActif);
        }
        public async Task<int> CountSearchResultsAsync(string query)
        {
            return await _context.produits
                .CountAsync(p => p.EstActif && p.Nom.ToLower().Contains(query.ToLower()));
        }
        public async Task<IEnumerable<Produit>> SearchProductsPageAsync(string query, int pageNumber, int pageSize)
        {
            return await _context.produits
                .Where(p => p.EstActif && p.Nom.ToLower().Contains(query.ToLower()))
                .OrderBy(p => p.Nom)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
        public async Task<IEnumerable<Produit>> SortProductsAsync(string sortBy)
        {
            IQueryable<Produit> query = _context.produits.Where(p => p.EstActif);

            switch (sortBy?.ToLower())
            {
                case "prix":
                    query = query.OrderBy(p => p.Prix);
                    break;
                case "note":
                    query = query.OrderByDescending(p => p.Note);
                    break;
                case "popularite":
                    query = query.OrderByDescending(p => p.Qty); // ou autre champ comme 'nbVentes'
                    break;
                default:
                    query = query.OrderBy(p => p.Nom); // tri par nom par défaut
                    break;
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Produit>> SearchSortPaginateAsync(string recherche, string tri, int page, int pageSize)
        {
            var query = _context.produits.AsQueryable();

            query = query.Where(p => p.EstActif);

            if (!string.IsNullOrWhiteSpace(recherche))
            {
                string lower = recherche.ToLower();
                query = query.Where(p => p.Nom.ToLower().Contains(lower));
            }

            switch (tri?.ToLower())
            {
                case "prix":
                    query = query.OrderBy(p => p.Prix);
                    break;
                case "note":
                    query = query.OrderByDescending(p => p.Note);
                    break;
                case "popularite":
                    query = query.OrderByDescending(p => p.Qty);
                    break;
                default:
                    query = query.OrderBy(p => p.Nom);
                    break;
            }

            return await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> CountFilteredProductsAsync(string recherche)
        {
            var query = _context.produits.Where(p => p.EstActif);

            if (!string.IsNullOrWhiteSpace(recherche))
            {
                string lower = recherche.ToLower();
                query = query.Where(p => p.Nom.ToLower().Contains(lower));
            }

            return await query.CountAsync();
        }




    }
}
