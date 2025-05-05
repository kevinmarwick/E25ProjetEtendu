using E25ProjetEtendu.Models;

namespace E25ProjetEtendu.Services.IServices
{
    public interface IProduitService
    {
        Task<IEnumerable<Produit>> GetAllActiveProduct();
        Task<Produit?> GetProduitById(int id);
        Task<(List<Produit> produits, int totalProduits)> GetFilteredProductsAsync(string recherche, string tri, int page, int pageSize);
    }
}
