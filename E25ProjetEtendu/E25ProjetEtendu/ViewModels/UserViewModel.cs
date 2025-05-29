using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace E25ProjetEtendu.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> Roles { get; set; }
        [Required]
        [Range(0, 1000, ErrorMessage = "Le solde doit être entre 0 $ et 1 000 $.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Balance { get; set; }
    }

}
