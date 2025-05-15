using E25ProjetEtendu.Models;

namespace E25ProjetEtendu.Services.IServices
{
    public interface IDeliveryService
    {
        
        Task<List<Order>> GetOrders();
        Task<Order> GetUnassignedOrder();



    }
}
