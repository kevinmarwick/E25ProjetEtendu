using E25ProjetEtendu.Data;
using E25ProjetEtendu.Models;
using E25ProjetEtendu.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace E25ProjetEtendu.Services
{
    public class DeliveryService : IDeliveryService
    {
        private readonly ApplicationDbContext _context;

        public DeliveryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Order>> GetOrders()
        {
            return await _context.Orders
                .Include(o => o.Buyer)                
                .ToListAsync();
        }
        public async Task<Order> GetUnassignedOrder()
        {
            return await _context.Orders
                .Include(o => o.Buyer)
                .Include(o => o.OrderItems)
                .ThenInclude(o => o.Product)
                .Where(o => o.DelivererId == null)
                .OrderBy(o => o.OrderDate)
                .FirstOrDefaultAsync();
                
        }
    }

}
