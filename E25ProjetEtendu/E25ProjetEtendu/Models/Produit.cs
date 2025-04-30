using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace E25ProjetEtendu.Models
{
    public class Produit
    {
        [Key]
        public int ProduitId { get; set; }

        [Required(ErrorMessage = "Le nom est obligatoire")]
        [StringLength(200, ErrorMessage = "Le nom ne peut pas dépasser 200 caractères")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "La quantité est obligatoire")]
        [Range(1, 10000, ErrorMessage = "La quantité doit être entre 1 et 10000")]
        public int Qty { get; set; }

        [Required(ErrorMessage = "Le prix est obligatoire")]
        [Range(0.01, 10000.00, ErrorMessage = "Le prix doit être supérieur à 0")]
        public decimal Prix { get; set; }

        [StringLength(255, ErrorMessage = "Le nom du fichier image ne peut pas dépasser 255 caractères")]
        public string Image { get; set; }

        public bool EstActif { get; set; }

        [Range(0, 5, ErrorMessage = "La note doit être entre 0 et 5")]
        public int Note { get; set; }
        [Required(ErrorMessage = "Les valeur nutritive son obligatoire")]
        [StringLength(500, ErrorMessage = "Les valeurs ne peut pas dépasser 500 caractères")]
        public string ValeurNutritive { get; set; }

    }
}

