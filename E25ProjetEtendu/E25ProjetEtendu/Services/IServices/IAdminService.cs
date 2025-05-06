using E25ProjetEtendu.Models;
using Microsoft.AspNetCore.Mvc;

namespace E25ProjetEtendu.Services.IServices
{
    public interface IAdminService
    {
        Task<IEnumerable<Produit>> GetAllProducts();
        Task UpdateInventoryAndPrice(int produitId, int qty, decimal prix);
        Task EditProduct(Produit product, IFormFile imageFile);



	}
}
