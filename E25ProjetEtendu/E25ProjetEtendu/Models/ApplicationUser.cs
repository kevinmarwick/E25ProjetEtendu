using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E25ProjetEtendu.Models
{
    public class ApplicationUser :IdentityUser
    {
        [Required(ErrorMessage ="Le prénom est requis")]
        [MaxLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Le nom est requis")]
        [MaxLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
                
        [NotMapped]
        [Display(Name = "Full Name")]
        public string FullName => $"{FirstName} {LastName}";

        [Required]
        [Range(0, 1000, ErrorMessage = "Le solde doit être entre 0 $ et 1 000 $.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Balance { get; set; } = 0;    
        
        //Navigation properties
        public List<Order> BoughtOrders { get; set; }
        public List<Order> DeliveredOrders { get; set; }
    }
}
