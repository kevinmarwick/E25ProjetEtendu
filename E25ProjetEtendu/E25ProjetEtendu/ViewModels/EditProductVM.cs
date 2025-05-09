using System.ComponentModel.DataAnnotations;

namespace E25ProjetEtendu.ViewModels
{
    public class EditProductVM
    {
        public int ProduitId { get; set; }

        [Required(ErrorMessage = "Le nom est obligatoire")]
        [StringLength(200)]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Les valeurs nutritives sont obligatoires")]
        [StringLength(500)]
        public string ValeurNutritive { get; set; }

        public string? CurrentImage { get; set; }

        public IFormFile? NewImageFile { get; set; }
    }
}
