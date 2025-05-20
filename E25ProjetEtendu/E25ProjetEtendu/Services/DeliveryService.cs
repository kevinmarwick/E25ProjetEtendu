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
        /// <summary>
        /// permet d'avoir toute les commandes 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Order>> GetOrders()
        {
            return await _context.Orders
                .Include(o => o.Buyer)                
                .ToListAsync();
        }
        /// <summary>
        /// méthode qui permet d'assigner une commande au livreur identifié
        /// </summary>
        /// <param name="orderId">le ID de la commande</param>
        /// <param name="userId">le ID du User qui veux s'assigner la commande </param>
        /// <returns></returns>
        public async Task<bool> AssignerCommandeAuLivreur(int orderId, string userId)
        {
            var order = await _context.Orders.FindAsync(orderId);

            if (order == null || order.DelivererId != null)
                return false; // commande inexistante ou déjà prise

            order.DelivererId = userId;

            await _context.SaveChangesAsync();
            return true;
        }
        /// <summary>
        /// Récupere tout les commandes non accepter par un livreur
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Récupére les derniere commande accepter
        /// </summary>
        /// <returns></returns>
        public async Task<List<Order>> GetAssignedOrders()
        {
            return await _context.Orders
                .Include(o => o.Buyer)
                .Include(o => o.Deliverer)
                .Where(o => o.DelivererId != null)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();
        }

    }

}
