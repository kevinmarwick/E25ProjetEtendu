using System.ComponentModel.DataAnnotations;

namespace E25ProjetEtendu.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Le nom est obligatoire")]
        [StringLength(200, ErrorMessage = "Le nom ne peut pas dépasser 200 caractères")]
        public string Name { get; set; }
        //propriété de navigation
        public List<Produit> Produits { get; set; }

    }
}
