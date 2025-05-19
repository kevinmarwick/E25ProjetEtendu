using E25ProjetEtendu.Models;
using E25ProjetEtendu.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace E25ProjetEtendu.Services.IServices
{
	public interface IOrderService
	{
		Task<Order> CreateOrder(OrderRequestDTO dto, string userId, List<Produit> produits);
		Task<bool> TryCreateOrderFromReservation(string userId);

    }
}
