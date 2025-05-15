using System.ComponentModel.DataAnnotations;

namespace E25ProjetEtendu.Models.DTOs
{
	public class CartItemDTO
	{
			[Required]
			public int ProductId { get; set; }

			[Range(1, int.MaxValue, ErrorMessage = "Quantité doit être au moins 1")]
			public int Quantity { get; set; }		
	}
}
