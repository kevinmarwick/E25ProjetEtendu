using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace E25ProjetEtendu.Models
{
    public class AdminProfile
    {
        [Key]
        public int AdminProfileId { get; set; }


        //Navigation properties
        [ValidateNever]
        public string ApplicationUserId { get; set; }
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }
    }
}
