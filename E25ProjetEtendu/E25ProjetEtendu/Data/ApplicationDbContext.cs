using E25ProjetEtendu.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace E25ProjetEtendu.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Produit> produits { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Ajout Admin

            modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole { Id = "admin-role-id", Name = "Admin", NormalizedName = "ADMIN" }
            );

            var hasher = new PasswordHasher<ApplicationUser>();
            var adminPassword = hasher.HashPassword(null, "Qwerty123!!");

            modelBuilder.Entity<ApplicationUser>().HasData(
            new ApplicationUser
            {
                Id = "21111111-1111-1111-1111-111111111111", 
                UserName = "admin@example.com",
                FirstName = "Admin",
                LastName = "Admin",
                NormalizedUserName = "ADMIN@EXAMPLE.COM",
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                EmailConfirmed = true,
                PasswordHash = adminPassword,
                SecurityStamp = Guid.NewGuid().ToString()
            }
            );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string> { UserId = "21111111-1111-1111-1111-111111111111", RoleId = "admin-role-id" }
            );
            #endregion


            #region Ajout Produit

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
                    ValeurNutritive = "Calories: 110, Sucres: 27g, Caféine: 80mg, Glucides: 28g, Protéines: 1g",
                    DateAjout = DateTime.Now.AddMonths(-2) // 👴
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
                    ValeurNutritive = "Calories: 190, Lipides: 9g, Glucides: 20g, Protéines: 6g, Sodium: 500mg",
                    DateAjout = DateTime.Now.AddMonths(-2)
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
                    ValeurNutritive = "Calories: 0, Lipides: 0g, Sucres: 0g, Sodium: 0mg",
                    DateAjout = DateTime.Now.AddMonths(-2)
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
                    ValeurNutritive = "Calories: 160, Lipides: 10g, Glucides: 15g, Sucres: 1g, Sodium: 170mg",
                    DateAjout = DateTime.Now.AddMonths(-2)
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
                    ValeurNutritive = "Calories: 200, Lipides: 11g, Glucides: 22g, Sucres: 21g, Protéines: 2g",
                    DateAjout = DateTime.Now.AddMonths(-2)
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
                    ValeurNutritive = "Calories: 100, Lipides: 2g, Glucides: 15g, Sucres: 12g, Protéines: 5g",
                    DateAjout = DateTime.Now.AddMonths(-2)
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
                    ValeurNutritive = "Calories: 350, Lipides: 15g, Glucides: 40g, Sucres: 5g, Protéines: 12g",
                    DateAjout = DateTime.Now.AddMonths(-2)
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
                    ValeurNutritive = "Calories: 190, Lipides: 7g, Glucides: 29g, Sucres: 11g, Protéines: 4g",
                    DateAjout = DateTime.Now.AddMonths(-2)
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
                    ValeurNutritive = "Calories: 140, Sucres: 39g, Glucides: 39g, Sodium: 45mg",
                    DateAjout = DateTime.Now 
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
                    ValeurNutritive = "Calories: 320, Lipides: 12g, Glucides: 30g, Protéines: 18g, Sodium: 780mg",
                    DateAjout = DateTime.Now 
                }
            );
            #endregion

        }
    }
}
