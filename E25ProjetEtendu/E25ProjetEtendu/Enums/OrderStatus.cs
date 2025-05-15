using System.ComponentModel.DataAnnotations;

namespace E25ProjetEtendu.Enums
{
    public enum OrderStatus
    {
        [Display(Name = "En attente")]
        Pending,

        [Display(Name = "En cours")]
        InProgress,

        [Display(Name = "Livrée")]
        Delivered,

        [Display(Name = "Annulée")]
        Cancelled
    }
}
