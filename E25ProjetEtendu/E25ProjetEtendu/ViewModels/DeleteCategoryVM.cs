namespace E25ProjetEtendu.ViewModels
{
    public class DeleteCategoryVM
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public bool CanBeDeleted { get; set; }
    }
}
