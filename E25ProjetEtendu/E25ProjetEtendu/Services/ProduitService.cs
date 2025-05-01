using E25ProjetEtendu.Data;
using E25ProjetEtendu.Extensions;
using E25ProjetEtendu.Models;
using E25ProjetEtendu.Services.IServices;
using E25ProjetEtendu.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace E25ProjetEtendu.Services
{
    public class ProduitService : IProduitService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProduitService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<IEnumerable<Produit>> GetAllActifProduct()
        {
            return await _context.produits.Where(p => p.EstActif)
                                          .OrderBy(p => p.Nom)
                                          .ToListAsync();
        }    
            
        /// <summary>
        /// cette méthode sers a gérer la recherche de produit et faire la pagination
        /// </summary>
        /// <param name="recherche">le mots clé mis dans la barre de recherche</param>
        /// <param name="tri">les differents options de tri pour la recherche</param>
        /// <param name="page">la pagination</param>
        /// <param name="pageSize">le nombre de produit accepter dans une page</param>
        /// <returns></returns>
        public async Task<(List<Produit> produits, int totalProduits)> GetFilteredProductsAsync(string recherche, string tri, int page, int pageSize)
        {
            IQueryable<Produit> query = _context.produits.Where(p => p.EstActif);

            if (!string.IsNullOrWhiteSpace(recherche) && recherche.Length > 200)
            {
                recherche = recherche.Substring(0, 200); // tronque à 200 caractères max
                query = query.Where(p => p.Nom.ToLower().Contains(recherche.ToLower()));
            }

            // tri
            query = tri?.ToLower() switch
            {
                "prix" => query.OrderBy(p => p.Prix),
                "prix_desc" => query.OrderByDescending(p => p.Prix),
                "note" => query.OrderBy(p => p.Note),
                "note_desc" => query.OrderByDescending(p => p.Note),
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
        public List<PannierProduitVM> GetCartItems()
        {
            var cart = _httpContextAccessor.HttpContext.Request.Cookies.GetObject<List<PannierProduitVM>>("panier") ?? new List<PannierProduitVM>();
            return cart;
        }

        public async Task AddToCartAsync(int productId, int quantity)
        {
            var produit = await _context.produits.FindAsync(productId);

            if (produit == null || produit.Qty < quantity)
                throw new Exception("Produit non disponible ou stock insuffisant.");


            var cart = _httpContextAccessor.HttpContext.Request.Cookies.GetObject<List<PannierProduitVM>>("panier") ?? new List<PannierProduitVM>();


            var item = cart.FirstOrDefault(i => i.ProduitId == productId);
            if (item != null)
            {
                item.Quantite += quantity;
            }
            else
            {
                cart.Add(new PannierProduitVM
                {
                    ProduitId = produit.ProduitId,
                    Nom = produit.Nom,
                    Prix = produit.Prix,
                    Quantite = quantity,
                    Image = produit.Image
                });
            }

            _httpContextAccessor.HttpContext.Response.Cookies.SetObject("panier", cart);


            
        }

        //public async Task ReserveProduitAsync(int productId, int quantity)
        //{
        //    var produit = await _context.produits.FindAsync(productId);

        //    if (produit == null)
        //        throw new Exception("Produit introuvable.");

        //    produit.Qty -= quantity;

        //    if (produit.Qty < 0)
        //        throw new Exception("Stock insuffisant.");

        //    _context.produits.Update(produit);
        //    await _context.SaveChangesAsync();
        //}
        public void EnleverPrduitPannier(int productId)
        {
            var cart = _httpContextAccessor.HttpContext.Request.Cookies.GetObject<List<PannierProduitVM>>("panier")
                       ?? new List<PannierProduitVM>();

            var item = cart.FirstOrDefault(i => i.ProduitId == productId);
            if (item != null)
            {
                if (item.Quantite > 1)
                {
                    item.Quantite--;
                }
                else
                {
                    cart.Remove(item);
                }

                _httpContextAccessor.HttpContext.Response.Cookies.SetObject("panier", cart);
            }
        }

        public void VidePannier()
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Delete("panier");
        }





    }
}
