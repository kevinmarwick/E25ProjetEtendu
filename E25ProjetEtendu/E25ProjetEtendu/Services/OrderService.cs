using E25ProjetEtendu.Data;
using E25ProjetEtendu.Models.DTOs;
using E25ProjetEtendu.Models;
using E25ProjetEtendu.Services.IServices;
using Microsoft.EntityFrameworkCore;
using E25ProjetEtendu.Enums;
using Microsoft.AspNetCore.SignalR;
using E25ProjetEtendu.Hubs;
using Microsoft.AspNetCore.Identity;
using E25ProjetEtendu.Configuration;
using Microsoft.AspNetCore.Identity.UI.Services;
using E25ProjetEtendu.Utils;
using Microsoft.CodeAnalysis.CSharp.Syntax;



namespace E25ProjetEtendu.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHubContext<OrderHub> _hubContext;
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IProduitService _produitService;
        private readonly EmailSender _emailSender;
        private readonly AdminSettings _adminSettings;

        public OrderService(ApplicationDbContext context, IHubContext<OrderHub> hubContext, IUserService userService, UserManager<ApplicationUser> userManager, IProduitService produitService, EmailSender emailSender, AdminSettings adminSettings)
        {
            _context = context;
            _hubContext = hubContext;
            _userService = userService;
            _userManager = userManager;
            _produitService = produitService;
            _emailSender = emailSender;
            _adminSettings = adminSettings;
        }

        public async Task<Order?> GetOrderById(int orderId)
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                  .ThenInclude(oi => oi.Product)
                .Include(o => o.Buyer)
                .Include(o => o.Deliverer)
                .FirstOrDefaultAsync(o => o.OrderId == orderId);
        }

        public async Task<bool> EndCompleteOrder(int orderId, string livreurId)
        {
            Order? commande = await _context.Orders
                .FirstOrDefaultAsync(o => o.OrderId == orderId && o.DelivererId == livreurId);

            commande.Status = OrderStatus.Delivered;
            await _context.SaveChangesAsync();
            await NotifierClientCommandeTermineeAsync(commande);

            return true;
        }

        public async Task NotifierClientCommandeTermineeAsync(Order order)
        {
            if (order?.BuyerId != null)
            {
                await _hubContext.Clients
                    .User(order.BuyerId)
                    .SendAsync("CommandeTerminee", order.OrderId);
            }
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

            var subtotal = orderItems.Sum(oi => oi.Quantity * oi.UnitPrice);
            var tps = subtotal * TaxConstants.TPS;
            var tvq = subtotal * TaxConstants.TVQ;
            var totalPrice = subtotal + tps + tvq;

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

        #region Order Cancellation

        /// <summary>
        /// Cancels an order based on the actor type (Buyer, Deliverer, or Delivery Station).
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="actorId"></param>
        /// <param name="actorType"></param>
        /// <param name="returnInventory"></param>
        /// <returns></returns>
        public async Task<string?> CancelOrder(int orderId, string actorId, CancellationActor actorType, bool returnInventory = true)
        {
            // Check if order exists and get user details
            Order? order = await GetOrderById(orderId);
            ApplicationUser? user = await _userService.GetUserById(actorId);

            // If user not found, return error message
            if (user == null)
                return "Utilisateur introuvable pour l'annulation de la commande.";
            // If order not found or already delivered/cancelled, return appropriate message
            if (order == null)
                return "Commande introuvable.";
            if (order.Status == OrderStatus.Cancelled)
                return "Commande déjà annulée";
            if (order.Status == OrderStatus.Delivered)
                return "Commande déjà livrée";

            // Check access rights based on actor type
            switch (actorType)
            {
                // Cancellation by Buyer
                case CancellationActor.Buyer:
                    /// Check access rights
                    if (order.BuyerId != actorId)
                        return "Accès refusé.";
                    if (order.Status == OrderStatus.InProgress)
                        return "Commande déjà en cours de livraison.";
                    break;

                //Cancellation by Deliverer
                case CancellationActor.Deliverer:
                    ///Check access rights
                    if (order.DelivererId != actorId)
                        return "Accès refusé.";
                    // If returnInventory is false, we notify admin
                    if (returnInventory == false)
                        await _emailSender.SendEmailAsync(
                            _adminSettings.Email,
                            $"Non retour de produits lors d'une commande annulée par le livreur {order.Deliverer.FullName}",
                            $"La commande #{order.OrderId} a été annulée par le livreur {order.Deliverer.FullName} ID:{order.DelivererId}. L'inventaire n'a pas été restockée." +
                            $"Veuillez vérifier les raisons de l'annulation avec le livreur et ajuster l'inventaire manuellement si nécessaire."
                    );
                    break;

                // Cancellation by Delivery Station
                case CancellationActor.DeliveryStation:
                    /// No ID check for station, assumed trusted role                   
                    break;
            }

            // **** Refund user ****
            string? refundResult = await RefundUser(order);

            // If refund failed, notify admin and buyer
            if (refundResult != null)
            {
                await _emailSender.SendEmailAsync(
                        order.Buyer.Email!,
                        $"Erreur lors du remboursement de la commande #{order.OrderId}",
                        $"La commande #{order.OrderId} a été annulé, mais le remboursement a peut-être rencontré un problème.  Veuillez vérifier, et contacter l'ADEPT au besoin.",
                        order
                    );
                await _emailSender.SendEmailAsync(
                       _adminSettings.Email,
                       $"Erreur lors du remboursement de la commande #{order.OrderId} de {order.Buyer.FullName}",
                       $"La commande #{order.OrderId} effectuée par {order.Buyer.FullName} ID:{order.BuyerId} a été annulé, mais le remboursement a peut-être rencontré un problème.  Veuillez vérifier et ajuster le solde de {order.Buyer.FirstName} au besoin",
                       order
                   );
            }
            // If refund was successful and actor is buyer
            else if (refundResult == null && actorType == CancellationActor.Buyer)
            {
                await _emailSender.SendEmailAsync(
                    order.Buyer.Email!,
                    "Remboursement de votre commande",
                    $"Votre commande #{order.OrderId} a bien été annulée et un remboursement a été effectué. Le montant de {order.TotalPrice}$ a été crédité sur votre compte.",
                    order
                );
            }
            // If refund was successful and actor is not buyer
            else if (refundResult == null && actorType != CancellationActor.Buyer)
            {
                await _emailSender.SendEmailAsync(
                    order.Buyer.Email!,
                    $"Remboursement de la commande #{order.OrderId} de {order.Buyer.FullName}",
                    $"Votre commande #{order.OrderId} a été annulée et un remboursement a été effectué. Le montant de {order.TotalPrice}$ a été crédité sur le compte de l'utilisateur. Nous sommes désolés des inconvénients, veuillez contacter l'ADEPT pour plus d'informations",
                    order
                );
            }
            
            // **** Replenish Inventory if needed ****
            bool restockResult = returnInventory;            
            if (returnInventory)
            {
                restockResult = await RestockInventory(order);
            }

            // If restock failed, notify admin
            if (!restockResult && actorType == CancellationActor.Deliverer)
            {
                await _emailSender.SendEmailAsync(
                    _adminSettings.Email,
                    $"Erreur de réapprovisionnement de l'inventaire pour la commande #{order.OrderId}",
                    $"La commande #{order.OrderId} a été annulé, mais le réapprovisionnement de l'inventaire a échoué. Veuillez vérifier que le livreur {order.Deliverer!.FullName} a bien retourné les produits, et ajustez l'inventaire en conséquence.",
                    order
                );
            }
            else if (!restockResult && actorType == CancellationActor.Buyer)
            {
                await _emailSender.SendEmailAsync(
                    _adminSettings.Email,
                    $"Erreur de réapprovisionnement de l'inventaire pour la commande #{order.OrderId}",
                    $"La commande #{order.OrderId} a été annulé, mais le réapprovisionnement de l'inventaire a échoué. Veuillez vérifier et ajuster l'inventaire en conséquence."
                    , order
                );
            }
            else if (!restockResult && actorType == CancellationActor.DeliveryStation)
            {
                await _emailSender.SendEmailAsync(
                    _adminSettings.Email,
                    $"Erreur de réapprovisionnement de l'inventaire pour la commande #{order.OrderId}",
                    $"La commande #{order.OrderId} a été annulé par le poste de livraison, mais le réapprovisionnement de l'inventaire a échoué. Veuillez vérifier et ajuster l'inventaire en conséquence."
                    , order
                );
            }

            // **** Update Order Status ****
            order.Status = OrderStatus.Cancelled;
            order.CancellingUserId = actorId;
            order.CancellationActor = actorType;
            order.CancellationDate = DateTime.UtcNow;

            // Save changes to the database
            await _context.SaveChangesAsync();

            return null; /// null = success
        }

        /// <summary>
        /// Refund the user by adding the order total to their balance. Returns null if successful, or an error message if there was an issue.
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        private async Task<string?> RefundUser(Order order)
        {
            ApplicationUser? user = await _userService.GetUserById(order.BuyerId);
            if (user == null)
                return "Utilisateur introuvable pour le remboursement.";

            user.Balance += order.TotalPrice;
            try
            {
                await _context.SaveChangesAsync();
                return null;
            }
            catch (Exception ex)
            {
                return $"Erreur lors du remboursement de l'utilisateur : {ex.Message}";
            }
        }

        /// <summary>
        /// Restock the inventory for each product in the order. Returns true if all products were successfully restocked, false if any product was not found.
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        private async Task<bool> RestockInventory(Order order)
        {
            // Return true if there are no order items to restock
            if (order.OrderItems == null || !order.OrderItems.Any())
                return true;

            // Loop through each order item and restock the inventory
            foreach (var item in order.OrderItems)
            {
                var produit = await _produitService.GetProduitById(item.ProductId);
                if (produit != null)
                {
                    produit.InventoryQuantity += item.Quantity;
                }
                else
                {
                    // Return false if any product is not found.   
                    return false;                                       /// Later, instead of returning false, we should pass a list of products to manually restock, and restock the rest. 
                }
            }

            // Save changes to the database if no errors
            await _context.SaveChangesAsync();
            return true;
        }

        #endregion
    }
}
