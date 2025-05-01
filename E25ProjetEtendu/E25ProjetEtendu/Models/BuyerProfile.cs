using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E25ProjetEtendu.Models
{
    public class BuyerProfile
    {
        [Key]
        public int BuyerProfileId { get; set; }

        [Required]
        [Range(0, 1000, ErrorMessage = "Le solde doit être entre 0 $ et 1 000 $.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Balance { get; set; }

        //Navigation properties
        [ValidateNever]
        public string ApplicationUserId { get; set; }

        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }
    }
}
