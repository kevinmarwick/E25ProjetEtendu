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
        [MaxLength(30)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Le prénom est requis")]
        [MaxLength(30)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
                
        [NotMapped]
        [Display(Name = "Full Name")]
        public string FullName => $"{FirstName} {LastName}";

        //navigation properties
        [ValidateNever]
        public BuyerProfile? BuyerProfile { get; set; }

        [ValidateNever]
        public DelivererProfile? DelivererProfile { get; set; }

        [ValidateNever]
        public AdminProfile? AdminProfile { get; set; }
    }
}
