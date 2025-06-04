using E25ProjetEtendu.Models;
using E25ProjetEtendu.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E25ProjetEtendu.Services.IServices
{
    public interface IAdminService
    {
        Task<IEnumerable<Produit>> GetAllProducts();
        Task UpdateInventoryAndPrice(int produitId, int qty, decimal prix);        
        Task<Produit> AddProductFromVM(AddProductVM vm);
        Task<EditProductVM?> GetEditProductVM(int id);
        Task<Produit> EditProductFromVM(EditProductVM vm);
        Task<bool> AddBalance(string userId, decimal montant);
        Task<IEnumerable<SelectListItem>> GetCategoriesSelectList();
        Task<Category> AddCategoryFromVM(AddCategoryVM vm);
        Task<(bool Success, string? ErrorMessage)> EditCategoryFromVM(EditCategoryVM vm);
        Task<IEnumerable<Category>> GetAllCategory();
        Task<EditCategoryVM> GetEditCategory(int id);
        
    }
}
