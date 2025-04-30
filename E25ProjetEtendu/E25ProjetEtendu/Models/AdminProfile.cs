namespace E25ProjetEtendu.Models
{
    public class AdminProfile
    {
        public int AdminProfileId { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
