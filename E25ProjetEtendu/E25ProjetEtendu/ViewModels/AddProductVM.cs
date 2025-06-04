using E25ProjetEtendu.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace E25ProjetEtendu.ViewModels
{
    public class AddProductVM
    {
        [Required(ErrorMessage = "Le nom est requis")]
        [StringLength(200)]
        public string Nom { get; set; }

        [Required(ErrorMessage = "La quantité est requise")]
        [Range(1, 10000)]
        public int Qty { get; set; }

        [Required(ErrorMessage = "Le prix est requis")]
        [Range(0.01, 10000)]
        public decimal Prix { get; set; }

        [Required(ErrorMessage = "Une image est requise")]
        public IFormFile ImageFile { get; set; }

        [Required(ErrorMessage = "Les valeurs nutritives sont requises")]
        [StringLength(500)]
        public string ValeurNutritive { get; set; }

        public bool EstActif { get; set; } = true;
        [Required(ErrorMessage = "Le SKU est requises")]
        [StringLength(20, MinimumLength = 6)]
        public string SKU { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem>? Categories { get; set; }

    }


}
