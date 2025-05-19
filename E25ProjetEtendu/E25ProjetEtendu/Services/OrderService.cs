using E25ProjetEtendu.Data;
using E25ProjetEtendu.Models.DTOs;
using E25ProjetEtendu.Models;
using E25ProjetEtendu.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace E25ProjetEtendu.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
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

        public async Task<bool> TryCreateOrderFromReservation(string userId)
        {
            var reservations = await _context.StockReservations
                .Where(r => r.UserId == userId && (DateTime.Now - r.ReservedAt).TotalMinutes < 10)
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
                Location = "Non spécifiée"
            };

            var produits = await _context.produits
                .Where(p => dto.Items.Select(i => i.ProductId).Contains(p.ProduitId))
                .ToListAsync();

            await CreateOrder(dto, userId, produits);
            return true;
        }
    }
}
