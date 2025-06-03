using E25ProjetEtendu.Data;
using E25ProjetEtendu.Enums;
using E25ProjetEtendu.Hubs;
using E25ProjetEtendu.Models;
using E25ProjetEtendu.Models.DTOs;
using E25ProjetEtendu.Services;
using E25ProjetEtendu.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
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
        private readonly IHubContext<OrderHub> _hubContext;


        public OrderController(ApplicationDbContext context, IOrderService orderService, IDeliveryService deliveryService, UserManager<ApplicationUser> userManager, IHubContext<OrderHub> hubContext)
        {
            _context = context;
            _orderService = orderService;
            _deliveryService = deliveryService;
            _userManager = userManager;
            _hubContext = hubContext;
        }

        /// <summary>
        /// Display the order details and allow the deliverer to end the order.
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles ="Deliverer")]
        [Route("Order/EndOrder/{orderId:int}")]
        public async Task<IActionResult> EndOrder(int orderId)
        {            
            try
            {
                Order? order = await _orderService.GetOrderById(orderId);
                ApplicationUser? user = await _userManager.GetUserAsync(User);
                if (user.Id != order.DelivererId)
                {
                    return Forbid();
                }
                if (order == null)
                {
                    return NotFound();
                }
                return View(order);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving order or user: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }            
        }

        /// <summary>
        /// Set the order status to "Delivered"
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Deliverer")]        
        public async Task<IActionResult> TerminateOrder(int orderId)
        {
            try
            {
                var order = await _orderService.GetOrderById(orderId);
                if (order == null)
                {
                    return NotFound();
                }

                var user = await _userManager.GetUserAsync(User);
                if (order.DelivererId != user?.Id)
                    return Forbid();

                await _orderService.EndCompleteOrder(orderId, order.DelivererId);
                return RedirectToAction("EndOrder", new { orderId });
            }
            catch
            (Exception ex)
            {
                Console.WriteLine($"Error terminating order: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
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
        /// <summary>
        /// Displays the current order status for the logged-in user.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Cancels an order as a buyer.
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> CancelAsBuyer(int orderId, string? returnUrl = null)
        {
            var userId = _userManager.GetUserId(User);
            var result = await _orderService.CancelOrder(orderId, userId, CancellationActor.Buyer, returnInventory: true);

            if (result != null)
            {
                TempData["Error"] = result;
            }
            else
            {
                TempData["Success"] = "Votre commande a été annulée avec succès.";
            }
            return returnUrl != null ? Redirect(returnUrl) : RedirectToAction("OrderStatus");
        }

        /// <summary>
        /// Cancels an order as a deliverer.
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="returnInventory"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Deliverer")]
        public async Task<IActionResult> CancelAsDeliverer(int orderId, bool returnInventory = true, string? returnUrl = null)
        {
            var userId = _userManager.GetUserId(User);
            var result = await _orderService.CancelOrder(orderId, userId, CancellationActor.Deliverer, returnInventory);

            if (result != null)
            {
                TempData["Error"] = result;
            }
            else
            {
                TempData["Success"] = "La commande a été annulée avec succès.";
            }
            return returnUrl != null ? Redirect(returnUrl) : RedirectToAction("Index", "Delivery");
        }

        /// <summary>
        /// Cancels an order as the delivery station.
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "DeliveryStation")]
        public async Task<IActionResult> CancelAsStation(int orderId, string? returnUrl = null)
        {
            var userId = _userManager.GetUserId(User)!;
            var result = await _orderService.CancelOrder(orderId, userId, CancellationActor.DeliveryStation, returnInventory: true);

            if (result != null)
            {
                TempData["Error"] = result;
            }
            else
            {
                TempData["Success"] = "La commande a été annulée par le poste de livraison.";
            }

            return returnUrl != null ? Redirect(returnUrl) : RedirectToAction("Index", "Admin");
        }
    }
}
