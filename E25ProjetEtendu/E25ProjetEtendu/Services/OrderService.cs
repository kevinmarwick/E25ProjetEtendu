using E25ProjetEtendu.Data;
using E25ProjetEtendu.Models.DTOs;
using E25ProjetEtendu.Models;
using E25ProjetEtendu.Services.IServices;
using Microsoft.EntityFrameworkCore;
using E25ProjetEtendu.Enums;

namespace E25ProjetEtendu.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }



        public async Task<bool> EndCompleteOrder(int orderId, string livreurId)
        {
            var commande = await _context.Orders
                .FirstOrDefaultAsync(o => o.OrderId == orderId && o.DelivererId == livreurId);

            if (commande == null || commande.Status != OrderStatus.Delivered)
            {
                return false; // on ne termine que si déjà livrée
            }
                

            commande.Status = OrderStatus.Delivered;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Order> CreateOrder(OrderRequestDTO dto, string userId, List<Produit> products)
        {
            var orderItems = dto.Items.Select(item =>
            {
                var product = products.First(p => p.ProduitId == item.ProductId);
                return new OrderItem
                {
                    ProductId = product.ProduitId,
                    Quantity = item.Quantity,
                    UnitPrice = product.Prix
                };
            }).ToList();

            var totalPrice = orderItems.Sum(oi => oi.Quantity * oi.UnitPrice);

            var order = new Order
            {
                OrderDate = DateTime.Now,
                BuyerId = userId,
                TotalPrice = totalPrice,
                DelivererId = null,
                OrderItems = orderItems,
                Location = dto.Location,
            };

            _context.Orders.Add(order);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("DB ERROR: " + ex.InnerException?.Message ?? ex.Message);
                throw;
            }

            return order;
        }

        public async Task<bool> TryCreateOrderFromReservation(string userId, string location)

        {
            var tenMinutesAgo = DateTime.Now.AddMinutes(-10);

            var reservations = await _context.StockReservations
                .Where(r => r.UserId == userId && r.ReservedAt >= tenMinutesAgo)
                .ToListAsync();

            if (!reservations.Any())
                return false;

            var dto = new OrderRequestDTO
            {
                Items = reservations.Select(r => new CartItemDTO
                {
                    ProductId = r.ProductId,
                    Quantity = r.Quantity
                }).ToList(),
                Location = location ?? "Non spécifiée"

            };

            var produits = await _context.produits
                .Where(p => dto.Items.Select(i => i.ProductId).Contains(p.ProduitId))
                .ToListAsync();

            await CreateOrder(dto, userId, produits);
            return true;
        }

        public async Task<bool> HasActiveOrder(string userId)
        {
            return await _context.Orders
                .AnyAsync(o => o.BuyerId == userId && o.Status != OrderStatus.Delivered);
        }

        public async Task<Order?> GetMostRecentOrder(string userId)
        {
            return await _context.Orders
                .Where(o => o.BuyerId == userId)
                .OrderByDescending(o => o.OrderDate)
                .FirstOrDefaultAsync();
        }

        public async Task<Order?> GetActiveOrder(string userId)
        {
            return await _context.Orders
                 .Where(o => o.BuyerId == userId &&
                             (o.Status == OrderStatus.Pending || o.Status == OrderStatus.InProgress))
                 .OrderByDescending(o => o.OrderDate)
                 .FirstOrDefaultAsync();

        }




    }
}
