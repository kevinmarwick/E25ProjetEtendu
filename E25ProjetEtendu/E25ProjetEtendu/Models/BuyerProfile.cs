namespace E25ProjetEtendu.Models
{
    public class BuyerProfile
    {
        public int BuyerProfileId { get; set; }
        public decimal Balance { get; set; }
        
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
