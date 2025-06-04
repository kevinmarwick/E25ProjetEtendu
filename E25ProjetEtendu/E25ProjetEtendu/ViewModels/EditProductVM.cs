using Microsoft.AspNetCore.Mvc.Rendering;
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
        [Required(ErrorMessage = "Le SKU est requises")]
        [StringLength(20, MinimumLength = 6)]
        public string SKU { get;set; }

        public IFormFile? NewImageFile { get; set; }
       
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem>? Categories { get; set; } 
    }
}
