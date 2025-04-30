namespace E25ProjetEtendu.ViewModels
{
    public class PannierVM
    {
        public List<PannierProduitVM> Produits { get; set; } = new();

        public decimal Total => Produits.Sum(i => i.Prix * i.Quantite);
    }
}
