using E25ProjetEtendu.Models;

namespace E25ProjetEtendu.Services.IServices
{
    public interface IProduitService
    {
        Task<IEnumerable<Produit>> GetAllActifProduct();
        Task<IEnumerable<Produit>> SearchProductsAsync(string recherche);
        Task<IEnumerable<Produit>> GetProductsPageAsync(int pageNumber, int pageSize);
        Task<int> CountActifProductsAsync();
        Task<int> CountSearchResultsAsync(string query);
        Task<IEnumerable<Produit>> SearchProductsPageAsync(string query, int pageNumber, int pageSize);
        Task<IEnumerable<Produit>> SortProductsAsync(string sortBy);
        Task<IEnumerable<Produit>> SearchSortPaginateAsync(string recherche, string tri, int page, int pageSize);
        Task<int> CountFilteredProductsAsync(string recherche);
    }
}
