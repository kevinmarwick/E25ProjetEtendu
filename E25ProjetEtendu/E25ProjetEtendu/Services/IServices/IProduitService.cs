using E25ProjetEtendu.Models;
using E25ProjetEtendu.Models.DTOs;
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
        Task<List<Produit>> GetProduitsSimilairesAsync(Produit produit, int max = 3);
        Task<Produit?> GetProduitById(int id);
        Task<bool> HasSufficientStock(List<CartItemDTO> items);
        Task<bool> ReserveStock(List<CartItemDTO> items, string userId);
        Task<bool> FinalizeReservation(string userId);
        Task CleanupExpiredReservations();
        Task CancelReservation(string userId);

    }
}
