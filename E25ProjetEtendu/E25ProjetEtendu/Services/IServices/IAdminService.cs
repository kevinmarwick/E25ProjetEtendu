using E25ProjetEtendu.Models;
using E25ProjetEtendu.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace E25ProjetEtendu.Services.IServices
{
    public interface IAdminService
    {
        Task<IEnumerable<Produit>> GetAllProducts();
        Task UpdateInventoryAndPrice(int produitId, int qty, decimal prix);        
        Task<Produit> AddProductFromVM(AddProductVM vm);
        Task<Produit> EditProductFromVM(EditProductVM vm);

    }
}
