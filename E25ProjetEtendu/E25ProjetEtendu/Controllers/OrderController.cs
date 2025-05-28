using E25ProjetEtendu.Data;
using E25ProjetEtendu.Enums;
using E25ProjetEtendu.Models;
using E25ProjetEtendu.Models.DTOs;
using E25ProjetEtendu.Services;
using E25ProjetEtendu.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;

namespace E25ProjetEtendu.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IOrderService _orderService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IDeliveryService _deliveryService;


        public OrderController(ApplicationDbContext context, IOrderService orderService, IDeliveryService deliveryService, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _orderService = orderService;
            _deliveryService = deliveryService;
            _userManager = userManager;
        }




        [HttpGet]
        [Authorize]
        public async Task<IActionResult> EndOrder(int orderId)

        {
            Order? order = await _orderService.GetOrderById(orderId);
            ApplicationUser? user = await _userManager.GetUserAsync(User); 
            if(user.Id != order.DelivererId)
            {
                return Forbid();
            }
            if(order == null)
            {
                return NotFound();
            }
            return View(order);
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> TerminateOrder(int orderId)
        {
            var order = await _orderService.GetOrderById(orderId);
            if(order == null)
            {
                return NotFound();
            }
            order.Status = OrderStatus.Delivered;            
            await _context.SaveChangesAsync();
            return RedirectToAction("EndOrder", new { orderId });

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
				//Find User
				var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                //Empty Cart
                if (dto.Items == null || !dto.Items.Any())
                    return BadRequest("Le panier est vide.");

                //Fill Products List
                var produits = await _context.produits
                    .Where(p => dto.Items.Select(i => i.ProductId).Contains(p.ProduitId))
                    .ToListAsync();

                //Invalid Product
                if (produits.Count != dto.Items.Count)
                    return BadRequest("Un ou plusieurs produits sont invalides.");

                //Create Order
                var order = await _orderService.CreateOrder(dto, userId, produits);

                return Ok(new { message = "Commande enregistrée", orderId = order.OrderId });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

		[Authorize]
		public async Task<IActionResult> CurrentOrderStatus(int? id)
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			Order? order;

			if (id.HasValue)
			{
				order = await _context.Orders
					.Include(o => o.OrderItems).ThenInclude(oi => oi.Product)
					.Include(o => o.Deliverer)
					.FirstOrDefaultAsync(o => o.OrderId == id && o.BuyerId == userId);
			}
			else
			{
				order = await _context.Orders
					.Where(o => o.BuyerId == userId && o.Status != OrderStatus.Delivered)
					.Include(o => o.OrderItems).ThenInclude(oi => oi.Product)
					.Include(o => o.Deliverer)
					.OrderByDescending(o => o.OrderDate)
					.FirstOrDefaultAsync();
			}

			if (order == null)
				return RedirectToAction("Index", "Home");

			if (order.Status == OrderStatus.Cancelled)
			{
				HttpContext.Session.SetString("CancelledOrderSeen", "true");
			}
			if (order.Status == OrderStatus.Delivered)
			{
				HttpContext.Session.SetString("DeliveredOrderSeen", "true");
			}


			return View(order);
		}

	}
}
