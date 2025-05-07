using System.ComponentModel.DataAnnotations;

namespace E25ProjetEtendu.ViewModels
{
    public class UpdateProductVM
    {
        public int ProduitId { get; set; }

        [Range(1, 10000, ErrorMessage = "La quantité doit être entre 1 et 10000")]
        public int Qty { get; set; }

        [Range(0.01, 10000.00, ErrorMessage = "Le prix doit être entre 0,01 et 10 000")]
        public decimal Prix { get; set; }
    }
}
