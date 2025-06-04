using System.ComponentModel.DataAnnotations;

namespace E25ProjetEtendu.ViewModels
{
    public class AddCategoryVM
    {       
            [Required(ErrorMessage = "Le nom est obligatoire")]
            [StringLength(200, ErrorMessage = "Le nom ne peut pas dépasser 200 caractères")]
            public string Name { get; set; }       

    }
}
