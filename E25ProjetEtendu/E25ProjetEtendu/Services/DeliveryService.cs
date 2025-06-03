using E25ProjetEtendu.Data;
using E25ProjetEtendu.Enums;
using E25ProjetEtendu.Hubs;
using E25ProjetEtendu.Models;
using E25ProjetEtendu.Services.IServices;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace E25ProjetEtendu.Services
{
    public class DeliveryService : IDeliveryService
    {
        private readonly ApplicationDbContext _context;
		private readonly IHubContext<OrderHub> _hubContext;
		public DeliveryService(ApplicationDbContext context, IHubContext<OrderHub> hubContext)
        {
            _context = context;
			_hubContext = hubContext;
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
            order.Status = Enums.OrderStatus.InProgress;

            await _context.SaveChangesAsync();
			// ✅ Envoie la notification SignalR à l'utilisateur concerné
			await _hubContext.Clients.Group(order.BuyerId)
			.SendAsync("ReceiveOrderStatusUpdate", order.OrderId, order.Status.ToString());
			return true;
        }
        /// <summary>
        /// Récupere tout les commandes non accepter par un livreur
        /// </summary>
        /// <returns></returns>
        public async Task<Order> GetUnassignedOrder()
        {
            var order = await _context.Orders
                .Include(o => o.Buyer)
                .Include(o => o.OrderItems)
                .ThenInclude(o => o.Product)
                .Where(o => o.DelivererId == null)
                .Where(o => o.Status == Enums.OrderStatus.Pending)                 
                .OrderBy(o => o.OrderDate)
                .FirstOrDefaultAsync();

            return order;
                
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

        /// <summary>
        /// Returns true if the user has an active delivery (order in progress) assigned to them as a deliverer.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<bool> HasActiveDelivery(string userId)
        {
            return await _context.Orders
                .AnyAsync(o => o.DelivererId == userId && o.Status == OrderStatus.InProgress);
        }

    }

}
