using E25ProjetEtendu.Models;
using E25ProjetEtendu.ViewModels;

namespace E25ProjetEtendu.Services.IServices
{
    public interface IProduitService
    {
        Task<IEnumerable<Produit>> GetAllActifProduct();        
        Task<(List<Produit> produits, int totalProduits)> GetFilteredProductsAsync(string recherche, string tri, int page, int pageSize);
        Task AddToCartAsync(int productId, int quantity);        
        List<PannierProduitVM> GetCartItems();
        void EnleverProduitPannier(int productId);
        void AugmenteProduitPannier(int productId);
        void VidePannier();
    }
}
