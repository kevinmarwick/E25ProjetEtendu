using E25ProjetEtendu.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E25ProjetEtendu.Controllers
{
    [Authorize(Roles = "Delivery")]
    public class DeliveryController : Controller
    {
        private readonly IDeliveryService _deliveryService;

        public DeliveryController(IDeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _deliveryService.GetUnassignedOrder();
            return View(orders);
        }
    }

}
