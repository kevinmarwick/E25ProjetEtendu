using System.ComponentModel.DataAnnotations;

namespace E25ProjetEtendu.Models.DTOs
{
	public class OrderRequestDTO
	{
		[Required]
		public List<CartItemDTO> Items { get; set; }

		public string Location { get; set; }
	}
}
