using E25ProjetEtendu.Models;

namespace E25ProjetEtendu.Services.IServices
{
    public interface IAdminService
    {
        Task<IEnumerable<Produit>> GetAllProduitsAsync();
    }
}
