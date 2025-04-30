using E25ProjetEtendu.Models;
using Microsoft.EntityFrameworkCore;

namespace E25ProjetEtendu.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Produit> produits { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // important à garder

            modelBuilder.Entity<Produit>().HasData(
                new Produit
                {
                    ProduitId = 1,
                    Nom = "Red Bull",
                    Qty = 120,
                    Prix = 3,
                    Image = "redbull.png",
                    EstActif = true,
                    Note = 4,
                    ValeurNutritive = "Calories: 110, Sucres: 27g, Caféine: 80mg, Glucides: 28g, Protéines: 1g"
                },
    new Produit
    {
        ProduitId = 2,
        Nom = "Pogo",
        Qty = 200,
        Prix = 2,
        Image = "pogo.jpg",
        EstActif = true,
        Note = 3,
        ValeurNutritive = "Calories: 190, Lipides: 9g, Glucides: 20g, Protéines: 6g, Sodium: 500mg"
    },
    new Produit
    {
        ProduitId = 3,
        Nom = "Bouteille d'eau",
        Qty = 300,
        Prix = 1,
        Image = "eau.jpg",
        EstActif = true,
        Note = 5,
        ValeurNutritive = "Calories: 0, Lipides: 0g, Sucres: 0g, Sodium: 0mg"
    },
    new Produit
    {
        ProduitId = 4,
        Nom = "Chips Lay’s",
        Qty = 100,
        Prix = 2,
        Image = "chips.jpg",
        EstActif = true,
        Note = 4,
        ValeurNutritive = "Calories: 160, Lipides: 10g, Glucides: 15g, Sucres: 1g, Sodium: 170mg"
    },
    new Produit
    {
        ProduitId = 5,
        Nom = "Nutella",
        Qty = 80,
        Prix = 5,
        Image = "nutella.jpg",
        EstActif = true,
        Note = 5,
        ValeurNutritive = "Calories: 200, Lipides: 11g, Glucides: 22g, Sucres: 21g, Protéines: 2g"
    },
    new Produit
    {
        ProduitId = 6,
        Nom = "Yogourt Activia",
        Qty = 150,
        Prix = 3,
        Image = "activia.jpg",
        EstActif = true,
        Note = 4,
        ValeurNutritive = "Calories: 100, Lipides: 2g, Glucides: 15g, Sucres: 12g, Protéines: 5g"
    },
    new Produit
    {
        ProduitId = 7,
        Nom = "Pizza congelée",
        Qty = 60,
        Prix = 6,
        Image = "pizza.jpg",
        EstActif = true,
        Note = 4,
        ValeurNutritive = "Calories: 350, Lipides: 15g, Glucides: 40g, Sucres: 5g, Protéines: 12g"
    },
    new Produit
    {
        ProduitId = 8,
        Nom = "Barre de granola",
        Qty = 180,
        Prix = 2,
        Image = "granola.jpg",
        EstActif = true,
        Note = 4,
        ValeurNutritive = "Calories: 190, Lipides: 7g, Glucides: 29g, Sucres: 11g, Protéines: 4g"
    },
    new Produit
    {
        ProduitId = 9,
        Nom = "Coca-Cola",
        Qty = 220,
        Prix = 2,
        Image = "coca.jpg",
        EstActif = true,
        Note = 3,
        ValeurNutritive = "Calories: 140, Sucres: 39g, Glucides: 39g, Sodium: 45mg"
    },
    new Produit
    {
        ProduitId = 10,
        Nom = "Sandwich jambon-fromage",
        Qty = 75,
        Prix = 4,
        Image = "sandwich.jpg",
        EstActif = true,
        Note = 4,
        ValeurNutritive = "Calories: 320, Lipides: 12g, Glucides: 30g, Protéines: 18g, Sodium: 780mg"
    }
               
            );
        }
    }
}
