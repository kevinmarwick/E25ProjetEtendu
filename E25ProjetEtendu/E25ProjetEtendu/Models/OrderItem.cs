using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Http.Headers;

namespace E25ProjetEtendu.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        //Navigation properties
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int ProductId { get; set; }
        public Produit Product { get; set; }
    }
}
