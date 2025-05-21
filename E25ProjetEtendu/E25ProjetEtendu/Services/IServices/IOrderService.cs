using E25ProjetEtendu.Models;
using E25ProjetEtendu.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace E25ProjetEtendu.Services.IServices
{
	public interface IOrderService
	{
		Task<Order> CreateOrder(OrderRequestDTO dto, string userId, List<Produit> produits);
		Task<bool> TryCreateOrderFromReservation(string userId);
		Task<bool> HasActiveOrder(string userId);
		Task<Order?> GetMostRecentOrder(string userId);
		Task<Order?> GetActiveOrder(string userId);
		Task<bool> EndCompleteOrder(int orderId, string livreurId);
		Task<Order?> GetOrderById(int orderId);



	}
}
