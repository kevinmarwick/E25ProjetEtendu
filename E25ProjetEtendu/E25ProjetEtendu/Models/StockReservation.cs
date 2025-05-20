namespace E25ProjetEtendu.Models
{
    public class StockReservation
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public DateTime ReservedAt { get; set; } = DateTime.Now;

        public Produit Product { get; set; }
    }
}
