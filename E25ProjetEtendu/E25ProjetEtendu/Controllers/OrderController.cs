using E25ProjetEtendu.Data;
using E25ProjetEtendu.Models.DTOs;
using E25ProjetEtendu.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace E25ProjetEtendu.Controllers
{
	[Authorize]
	[ApiController]
	[Route("api/[controller]")]
	public class OrderController : ControllerBase
	{
		private readonly ApplicationDbContext _context;
		private readonly IOrderService _orderService;

		public OrderController(ApplicationDbContext context, IOrderService orderService)
		{
			_context = context;
			_orderService = orderService;
		}

		[HttpPost("create")]
		public async Task<IActionResult> Create([FromBody] OrderRequestDTO dto)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					foreach (var entry in ModelState)
					{
						foreach (var error in entry.Value.Errors)
						{
							Console.WriteLine($"Field: {entry.Key} - Error: {error.ErrorMessage}");
						}
					}
					return BadRequest(ModelState);
				}

				var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

				if (dto.Items == null || !dto.Items.Any())
					return BadRequest("Le panier est vide.");

				var produits = await _context.produits
					.Where(p => dto.Items.Select(i => i.ProductId).Contains(p.ProduitId))
					.ToListAsync();

				if (produits.Count != dto.Items.Count)
					return BadRequest("Un ou plusieurs produits sont invalides.");

				var order = await _orderService.CreateOrderAsync(dto, userId, produits);

				return Ok(new { message = "Commande enregistrée", orderId = order.OrderId });
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}
	}
}
