using E25ProjetEtendu.Models;
using E25ProjetEtendu.ViewModels;

namespace E25ProjetEtendu.Services.IServices
{
    public interface IProduitService
    {
        Task<IEnumerable<Produit>> GetAllActiveProduct();        
        Task<(List<Produit> produits, int totalProduits)> GetFilteredProducts(string recherche, string tri, int page, int pageSize);
        Task AddToCart(int productId, int quantity);
        List<PannierProduitVM> GetCartItems();
        void EnleverProduitPannier(int productId);
        void AugmenteProduitPannier(int productId);
        void VidePannier();
    }
}
