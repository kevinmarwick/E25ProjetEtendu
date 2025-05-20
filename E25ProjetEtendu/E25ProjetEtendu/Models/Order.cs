using System.ComponentModel.DataAnnotations.Schema;

namespace E25ProjetEtendu.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }
        public OrderStatus status { get; set; }


        //Navigation properties
        public string BuyerId { get; set; }
        public ApplicationUser Buyer { get; set; }

        public string? DelivererId { get; set; }
        public ApplicationUser? Deliverer { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        public string Location { get; set; }
        

        public enum OrderStatus
        {
            EnAttente = 0,
            EnCours = 1,
            Terminee = 2,
            Annulee = 3
        }
    }
}
