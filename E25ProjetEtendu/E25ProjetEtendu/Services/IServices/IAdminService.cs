using E25ProjetEtendu.Models;

namespace E25ProjetEtendu.Services.IServices
{
    public interface IAdminService
    {
        Task<IEnumerable<Produit>> GetAllProduits();
        Task UpdateInventoryAndPrice(int produitId, int qty, decimal prix);
        Task<Produit> AddProduct(Produit produit);
    }
}
