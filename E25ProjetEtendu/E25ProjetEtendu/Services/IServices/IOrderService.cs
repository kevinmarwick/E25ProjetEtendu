using E25ProjetEtendu.Models;
using E25ProjetEtendu.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace E25ProjetEtendu.Services.IServices
{
	public interface IOrderService
	{
		Task<Order> CreateOrderAsync(OrderRequestDTO dto, string userId, List<Produit> produits);
	}
}
