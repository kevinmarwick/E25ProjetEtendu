using E25ProjetEtendu.Configuration;
using E25ProjetEtendu.Data;
using E25ProjetEtendu.Enums;
using E25ProjetEtendu.Models;
using E25ProjetEtendu.Services;
using E25ProjetEtendu.Services.IServices;
using E25ProjetEtendu.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Stripe.Climate;

namespace E25ProjetEtendu.Controllers
{
	[Authorize(Roles = "DeliveryStation")]
	public class DeliveryController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly IDeliveryService _deliveryService;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly SmsService _smsService;
		private readonly IEmailSender _emailSender;
		private readonly IOptions<AdminSettings> _adminSettings;
		private readonly IOrderService _orderService;


		public DeliveryController(ApplicationDbContext context, IDeliveryService deliveryService, UserManager<ApplicationUser> userManager,
								  SignInManager<ApplicationUser> signInManager, ApplicationDbContext dbContext, SmsService smsService,
								  IEmailSender emailSender, IOptions<AdminSettings> adminSettings, IOrderService orderService)
		{
			_context = context;
			_deliveryService = deliveryService;
			_userManager = userManager;
			_signInManager = signInManager;
			_smsService = smsService;
			_emailSender = emailSender;
			_adminSettings = adminSettings;
			_orderService = orderService;
		}

		/// <summary>
		/// Shows the dashboard for the delivery station, displaying pending orders, in-progress orders, and order history.
		/// </summary>
		/// <param name="pendingPage"></param>
		/// <param name="historyPage"></param>
		/// <returns></returns>
		[Authorize(Roles = "DeliveryStation")]
		public async Task<IActionResult> Index(int pendingPage = 1, int historyPage = 1)
		{
			const int pageSize = 5;

            List<Models.Order> pendingOrders = await _context.Orders
				.Include(o => o.OrderItems).ThenInclude(oi => oi.Product)
				.Include(o => o.Buyer)
				.Where(o => o.DelivererId == null && o.Status == OrderStatus.Pending)
				.OrderBy(o => o.OrderDate)
				.Skip((pendingPage - 1) * pageSize)
				.Take(pageSize)
				.ToListAsync();

            List<Models.Order> inProgressOrders = await _context.Orders
				.Include(o => o.OrderItems).ThenInclude(oi => oi.Product)
				.Include(o => o.Buyer)
				.Include(o => o.Deliverer)
				.Where(o => o.Status == OrderStatus.InProgress)
				.OrderByDescending(o => o.OrderDate)
				.ToListAsync();

            List<Models.Order> historyOrders = await _context.Orders
				.Include(o => o.OrderItems).ThenInclude(oi => oi.Product)
				.Include(o => o.Buyer)
				.Include(o => o.Deliverer)
				.OrderByDescending(o => o.OrderDate)
				.ToListAsync();

            int totalPending = await _context.Orders.CountAsync(o => o.DelivererId == null && o.Status == OrderStatus.Pending);
            int totalInProgress = await _context.Orders.CountAsync(o => o.Status == OrderStatus.InProgress);
            int totalHistory = await _context.Orders.CountAsync(o => o.Status == OrderStatus.Delivered || o.Status == OrderStatus.Cancelled);

			var vm = new DeliveryVM
			{
				PendingOrders = pendingOrders,
				InProgressOrders = inProgressOrders,
				OrderHistory = historyOrders,
				CurrentPendingPage = pendingPage,
				CurrentHistoryPage = historyPage,
				PendingPageCount = (int)Math.Ceiling((double)totalPending / pageSize),
				HistoryPageCount = (int)Math.Ceiling((double)totalHistory / pageSize),
				TotalPending = totalPending,
				TotalInProgress = totalInProgress				
			};

			return View(vm);
		}


        [Authorize(Roles = "DeliveryStation")]
        public async Task<IActionResult> OrdersHistory()
        {
            var orders = await _orderService.GetOrdersHistory();
            return View(orders);
        }

        [HttpPost]
		public async Task<IActionResult> ConfirmDelivery(int orderId, string email, string password)
		{
			var user = await _userManager.FindByEmailAsync(email);
			var timestamp = DateTime.Now.ToString("f");

			//User null
			if (user == null)
			{
				TempData["Error"] = "Utilisateur non trouvé ou mot de passe invalide.";
				await _emailSender.SendEmailAsync(
					_adminSettings.Value.Email,
					$"Tentative de connexion avec utilisateur inconnu : {email}",
					$@"
                        <p>Une tentative de connexion a échoué. Aucun utilisateur trouvé pour l'adresse : <strong>{email}</strong>.</p>
                        <p><strong>Commande :</strong> #{orderId}</p>
                        <p style='margin-top:15px; color:gray;'>Tentative enregistrée le {timestamp}</p>"
				);

				return RedirectToAction("Index");
			}

			//Check Credentials
			var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
			if (!result.Succeeded)
			{
				TempData["Error"] = "Utilisateur non trouvé ou mot de passe invalide.";
				await _emailSender.SendEmailAsync(
					_adminSettings.Value.Email,
					$"Échec d'authentification: {email}",
					$@"
                        <p>Échec d'authentification pour <strong>{email}</strong> ({user.FullName}, ID : {user.Id}) — mot de passe invalide.</p>
                        <p><strong>Commande :</strong> #{orderId}</p>
                        <p style='margin-top:15px; color:gray;'>Tentative enregistrée le {timestamp}</p>"
				);


				return RedirectToAction("Index");
			}

			//Check if user is deliverer
			var isDeliverer = await _userManager.IsInRoleAsync(user, "Deliverer");
			if (!isDeliverer)
			{
				TempData["Error"] = "Vous n'avez pas les permissions pour accepter des livraisons.";
				await _emailSender.SendEmailAsync(
					_adminSettings.Value.Email,
					$"Tentative de livraison non autorisée par {email}",
					$@"
                        <p>L'utilisateur <strong>{email}</strong> ({user.FullName}, ID : {user.Id}) a été authentifié avec succès, mais <strong>n'a pas le rôle 'Livreur'</strong>.</p>
                        <p><strong>Commande :</strong> #{orderId}</p>
                        <p style='margin-top:15px; color:gray;'>Tentative enregistrée le {timestamp}</p>"
				);

				return RedirectToAction("Index");
			}

			//Check if user has an active order
			var hasActiveOrder = await _deliveryService.HasActiveDelivery(user.Id);
			if (hasActiveOrder)
			{
				TempData["Error"] = "Vous avez déjà une commande en cours. Veuillez terminer la livraison actuelle avant d'en accepter une nouvelle.";

				return RedirectToAction("Index");
			}

			//Assign Order
			var assignationReussie = await _deliveryService.AssignerCommandeAuLivreur(orderId, user.Id);
			if (!assignationReussie)
			{
				TempData["Error"] = "La commande n'est plus disponible.";
				return RedirectToAction("Index");
			}

			//Order Assigned successfully
			TempData["Success"] = "Commande acceptée avec succès.";
			await _smsService.EnvoyerLienConfirmationAuLivreur(user.PhoneNumber!, orderId);
			return RedirectToAction("Index");
		}
	}
}
