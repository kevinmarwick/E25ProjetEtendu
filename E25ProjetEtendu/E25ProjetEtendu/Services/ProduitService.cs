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
        #region Methode de recherche & liste de produit
        /// <summary>
        /// Permet d'Afficher toute les produits actif a l'utilisateur
        /// </summary>
        /// <returns>retourne une list de produit actif</returns>
        public async Task<IEnumerable<Produit>> GetAllActiveProduct()
        {
            return await _context.produits.FirstOrDefaultAsync(p => p.ProduitId == produitId); 
        }

        /// <summary>
        /// Returns a list of all active products
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Produit>> GetAllActiveProduct()
        {
            return await _context.produits.Where(p => p.EstActif)
                                          .OrderBy(p => p.Nom)
                                          .ToListAsync();
        }
        public async Task<Produit?> GetByIdAsync(int id)
        {
            return await _context.produits.FindAsync(id);
        }

        /// <summary>
        /// Returns a list of products using filters in parameters
        /// </summary>
        /// <param name="recherche">le mots clé mis dans la barre de recherche</param>
        /// <param name="tri">les differents options de tri pour la recherche</param>
        /// <param name="page">la pagination</param>
        /// <param name="pageSize">le nombre de produit accepter dans une page</param>
        /// <returns></returns>
        public async Task<(List<Produit> produits, int totalProduits)> GetFilteredProducts(string recherche, string tri, int page, int pageSize)
        {
            IQueryable<Produit> query = _context.produits.Where(p => p.EstActif);

            if (!string.IsNullOrEmpty(recherche) && recherche.Length > 200)
            {
                recherche = recherche.Substring(0, 200);
            }

            if (!string.IsNullOrEmpty(recherche))
            {
                query = query.Where(p => p.Nom.Contains(recherche));
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

        public async Task<List<Produit>> GetProduitsSimilairesAsync(Produit produit, int max = 3)
        {
            return await _context.produits
                .Where(p => p.ProduitId != produit.ProduitId &&
                           (p.Note == produit.Note || p.Prix == produit.Prix))
                .Take(max)
                .ToListAsync();
        }

        #endregion
        #region Methode de gestion de cart 
        /// <summary>
        /// permet de récuperer les produits du cart
        /// </summary>
        /// <returns>retourne un liste de pannierProduitVM</returns>
        public List<PannierProduitVM> GetCartItems()
        {
            var cart = _httpContextAccessor.HttpContext.Request.Cookies.GetObject<List<PannierProduitVM>>("panier") ?? new List<PannierProduitVM>();
            return cart;
        }
        /// <summary>
        /// Permet d'ajouter au pannier un produit
        /// </summary>
        /// <param name="productId">l'id du produit</param>
        /// <param name="quantity">la quantité du produit dans le panier </param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task AddToCart(int productId, int quantity)
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

        /// <summary>
        /// permet la suppression d'un produit au pannier.
        /// point important le produit est seulement enlever du pannier et non de la bd
        /// </summary>
        /// <param name="productId">le id du produit que l'utilisateur veux retirer du panier </param>
        public void EnleverProduitPannier(int productId)
        {
            var cart = _httpContextAccessor.HttpContext.Request.Cookies.GetObject<List<PannierProduitVM>>("panier")
               ?? new List<PannierProduitVM>();

            var item = cart.FirstOrDefault(i => i.ProduitId == productId);
            if (item != null)
            {
                if (item.Quantite > 1)
                {
                    item.Quantite--;  // ✅ décrémente la quantité
                }
                else
                {
                    cart.Remove(item); // ✅ supprime si quantité = 1
                }

                _httpContextAccessor.HttpContext.Response.Cookies.SetObject("panier", cart);
            }
        }
        /// <summary>
        /// permet l'ajout d'un produit au pannier.        
        /// <summary>
        /// <param name="productId">le id du produit que l'utilisateur veux augmenter du panier</param>
        public void AugmenteProduitPannier(int productId)
        {
            var cart = _httpContextAccessor.HttpContext.Request.Cookies.GetObject<List<PannierProduitVM>>("panier")
                       ?? new List<PannierProduitVM>();

            var item = cart.FirstOrDefault(i => i.ProduitId == productId);
            if (item != null)
            {
                item.Quantite++;  // ✅ incrémente
            }
            else
            {
                cart.Add(new PannierProduitVM
                {
                    ProduitId = productId,
                    Quantite = 1
                    // autres champs si besoin
                });
            }

            _httpContextAccessor.HttpContext.Response.Cookies.SetObject("panier", cart);
        }
        /// <summary>
        /// Permet de vider le panier d'un coup
        /// </summary>
        public void VidePannier()
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Delete("panier");
        }
        #endregion
    }
}
