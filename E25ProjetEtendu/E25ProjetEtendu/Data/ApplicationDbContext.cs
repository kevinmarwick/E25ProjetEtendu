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
                    id = 1,
                    nom = "Red Bull",
                    Qty = 120,
                    prix = 3,
                    Image = "redbull.jpg",
                    estActif = true,
                    note = 4,
                    valeurNutritive = "Calories: 110, Sucres: 27g, Caféine: 80mg, Glucides: 28g, Protéines: 1g"
                },
    new Produit
    {
        id = 2,
        nom = "Pogo",
        Qty = 200,
        prix = 2,
        Image = "pogo.jpg",
        estActif = true,
        note = 3,
        valeurNutritive = "Calories: 190, Lipides: 9g, Glucides: 20g, Protéines: 6g, Sodium: 500mg"
    },
    new Produit
    {
        id = 3,
        nom = "Bouteille d'eau",
        Qty = 300,
        prix = 1,
        Image = "eau.jpg",
        estActif = true,
        note = 5,
        valeurNutritive = "Calories: 0, Lipides: 0g, Sucres: 0g, Sodium: 0mg"
    },
    new Produit
    {
        id = 4,
        nom = "Chips Lay’s",
        Qty = 100,
        prix = 2,
        Image = "chips.jpg",
        estActif = true,
        note = 4,
        valeurNutritive = "Calories: 160, Lipides: 10g, Glucides: 15g, Sucres: 1g, Sodium: 170mg"
    },
    new Produit
    {
        id = 5,
        nom = "Nutella",
        Qty = 80,
        prix = 5,
        Image = "nutella.jpg",
        estActif = true,
        note = 5,
        valeurNutritive = "Calories: 200, Lipides: 11g, Glucides: 22g, Sucres: 21g, Protéines: 2g"
    },
    new Produit
    {
        id = 6,
        nom = "Yogourt Activia",
        Qty = 150,
        prix = 3,
        Image = "activia.jpg",
        estActif = true,
        note = 4,
        valeurNutritive = "Calories: 100, Lipides: 2g, Glucides: 15g, Sucres: 12g, Protéines: 5g"
    },
    new Produit
    {
        id = 7,
        nom = "Pizza congelée",
        Qty = 60,
        prix = 6,
        Image = "pizza.jpg",
        estActif = true,
        note = 4,
        valeurNutritive = "Calories: 350, Lipides: 15g, Glucides: 40g, Sucres: 5g, Protéines: 12g"
    },
    new Produit
    {
        id = 8,
        nom = "Barre de granola",
        Qty = 180,
        prix = 2,
        Image = "granola.jpg",
        estActif = true,
        note = 4,
        valeurNutritive = "Calories: 190, Lipides: 7g, Glucides: 29g, Sucres: 11g, Protéines: 4g"
    },
    new Produit
    {
        id = 9,
        nom = "Coca-Cola",
        Qty = 220,
        prix = 2,
        Image = "coca.jpg",
        estActif = true,
        note = 3,
        valeurNutritive = "Calories: 140, Sucres: 39g, Glucides: 39g, Sodium: 45mg"
    },
    new Produit
    {
        id = 10,
        nom = "Sandwich jambon-fromage",
        Qty = 75,
        prix = 4,
        Image = "sandwich.jpg",
        estActif = true,
        note = 4,
        valeurNutritive = "Calories: 320, Lipides: 12g, Glucides: 30g, Protéines: 18g, Sodium: 780mg"
    }
               
            );
        }
    }
}
