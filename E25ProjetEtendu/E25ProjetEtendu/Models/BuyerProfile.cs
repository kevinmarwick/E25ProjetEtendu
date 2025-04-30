using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace E25ProjetEtendu.Models
{
    public class BuyerProfile
    {
        [Key]
        public int BuyerProfileId { get; set; }

        [Required]       
        public decimal Balance { get; set; }

        //Navigation properties
        [ValidateNever]
        public string ApplicationUserId { get; set; }

        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }
    }
}
