using Microsoft.AspNetCore.Identity;

namespace E25ProjetEtendu.Models
{
    public class ApplicationUser :IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //navigation
        public BuyerProfile? BuyerProfile { get; set; }
        public DelivererProfile? DelivererProfile { get; set; }
        public AdminProfile? AdminProfile { get; set; }
    }
}
