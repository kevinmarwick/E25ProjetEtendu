using E25ProjetEtendu.Data;
using E25ProjetEtendu.Models.DTOs;
using E25ProjetEtendu.Models;
using E25ProjetEtendu.Services.IServices;

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
				OrderItems = orderItems
			};

			_context.Orders.Add(order);

			//Save
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
	}
}
