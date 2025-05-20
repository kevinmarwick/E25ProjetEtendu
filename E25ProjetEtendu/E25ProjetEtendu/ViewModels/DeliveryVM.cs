using E25ProjetEtendu.Models;

namespace E25ProjetEtendu.ViewModels
{
    public class DeliveryVM
    {
        public Order? NextOrder { get; set; }
        public List<Order> AssignedOrders { get; set; } = new();
    }

}
