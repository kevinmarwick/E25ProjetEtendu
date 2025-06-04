using E25ProjetEtendu.Models;

namespace E25ProjetEtendu.ViewModels
{
	public class DeliveryVM
	{
		public List<Order> PendingOrders { get; set; } = new();
		public List<Order> InProgressOrders { get; set; } = new();
		public List<Order> OrderHistory { get; set; } = new();
        
        public int PendingPageCount { get; set; }
		public int HistoryPageCount { get; set; }
		public int CurrentPendingPage { get; set; } = 1;
		public int CurrentHistoryPage { get; set; } = 1;
        public int TotalPending { get; set; }
        public int TotalInProgress { get; set; } = 0;
	}
}
