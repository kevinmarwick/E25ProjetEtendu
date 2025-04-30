namespace E25ProjetEtendu.Models
{
    public class DelivererProfile
    {
        public int DelivererProfileId { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
