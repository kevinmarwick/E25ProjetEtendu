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
            #region Ajout Utilisateur Standard

            // Ajout du rôle "User"
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "user-role-id", Name = "User", NormalizedName = "USER" }
            );

            var userPassword = hasher.HashPassword(null, "Test123!!"); // mot de passe pour la démo

            // Ajout d’un utilisateur standard
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "32222222-2222-2222-2222-222222222222",
                    UserName = "user@example.com",
                    FirstName = "Jean",
                    LastName = "Utilisateur",
                    NormalizedUserName = "USER@EXAMPLE.COM",
                    Email = "user@example.com",
                    NormalizedEmail = "USER@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = userPassword,
                    SecurityStamp = Guid.NewGuid().ToString()
                }
            );

            // Associer le rôle "User"
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = "32222222-2222-2222-2222-222222222222",
                    RoleId = "user-role-id"
                }
            );

            #endregion




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
                },
                new Produit { ProduitId = 11, Nom = "Café Starbucks", Qty = 90, Prix = 4, Image = "starbucks.jpg", EstActif = true, Note = 4, ValeurNutritive = "Calories: 150, Sucres: 20g, Caféine: 95mg" },
                new Produit { ProduitId = 12, Nom = "Déodorant Axe", Qty = 50, Prix = 6, Image = "axe.jpg", EstActif = true, Note = 5, ValeurNutritive = "Sans calories" },
                new Produit { ProduitId = 13, Nom = "Shampooing Head & Shoulders", Qty = 60, Prix = 7, Image = "headshoulders.jpg", EstActif = true, Note = 4, ValeurNutritive = "Sans calories" },
                new Produit { ProduitId = 14, Nom = "Crème glacée Ben & Jerry's", Qty = 40, Prix = 8, Image = "benjerry.jpg", EstActif = true, Note = 5, ValeurNutritive = "Calories: 270, Lipides: 14g, Sucres: 26g" },
                new Produit { ProduitId = 15, Nom = "Pain tranché", Qty = 120, Prix = 3, Image = "pain.jpg", EstActif = true, Note = 3, ValeurNutritive = "Calories: 80, Glucides: 15g, Protéines: 3g" },
                new Produit { ProduitId = 16, Nom = "Fromage cheddar", Qty = 100, Prix = 5, Image = "cheddar.jpg", EstActif = true, Note = 4, ValeurNutritive = "Calories: 110, Lipides: 9g, Protéines: 7g" },
                new Produit { ProduitId = 17, Nom = "Yaourt grec", Qty = 130, Prix = 4, Image = "yaourt.jpg", EstActif = true, Note = 4, ValeurNutritive = "Calories: 120, Protéines: 10g, Sucres: 8g" },
                new Produit { ProduitId = 18, Nom = "Crackers Ritz", Qty = 80, Prix = 3, Image = "ritz.jpg", EstActif = true, Note = 3, ValeurNutritive = "Calories: 160, Lipides: 8g, Glucides: 20g" },
                new Produit { ProduitId = 19, Nom = "Soupe Campbell", Qty = 70, Prix = 2, Image = "soupe.jpg", EstActif = true, Note = 4, ValeurNutritive = "Calories: 90, Sodium: 480mg" },
                new Produit { ProduitId = 20, Nom = "Jus d'orange Tropicana", Qty = 150, Prix = 3, Image = "tropicana.jpg", EstActif = true, Note = 4, ValeurNutritive = "Calories: 110, Sucres: 23g" },
                new Produit { ProduitId = 21, Nom = "Brosse à dents Colgate", Qty = 200, Prix = 2, Image = "colgate.jpg", EstActif = true, Note = 4, ValeurNutritive = "Sans calories" },
                new Produit { ProduitId = 22, Nom = "Dentifrice Sensodyne", Qty = 150, Prix = 5, Image = "sensodyne.jpg", EstActif = true, Note = 5, ValeurNutritive = "Sans calories" },
                new Produit { ProduitId = 23, Nom = "Savon Dove", Qty = 180, Prix = 2, Image = "dove.jpg", EstActif = true, Note = 4, ValeurNutritive = "Sans calories" },
                new Produit { ProduitId = 24, Nom = "Boisson Gatorade", Qty = 110, Prix = 3, Image = "gatorade.jpg", EstActif = true, Note = 4, ValeurNutritive = "Calories: 80, Sucres: 21g" },
                new Produit { ProduitId = 25, Nom = "Chocolat Kinder", Qty = 100, Prix = 2, Image = "kinder.jpg", EstActif = true, Note = 5, ValeurNutritive = "Calories: 120, Sucres: 12g" },
                new Produit { ProduitId = 26, Nom = "Céréales Cheerios", Qty = 90, Prix = 4, Image = "cheerios.jpg", EstActif = true, Note = 4, ValeurNutritive = "Calories: 110, Glucides: 20g, Protéines: 3g" },
                new Produit { ProduitId = 27, Nom = "Biscuit Oreo", Qty = 130, Prix = 3, Image = "oreo.jpg", EstActif = true, Note = 4, ValeurNutritive = "Calories: 160, Sucres: 14g" },
                new Produit { ProduitId = 28, Nom = "Beurre d'arachide", Qty = 70, Prix = 5, Image = "beurre.jpg", EstActif = true, Note = 4, ValeurNutritive = "Calories: 190, Lipides: 16g, Protéines: 7g" },
                new Produit { ProduitId = 29, Nom = "Eau gazeuse Perrier", Qty = 200, Prix = 2, Image = "perrier.jpg", EstActif = true, Note = 4, ValeurNutritive = "Calories: 0" },
                new Produit { ProduitId = 30, Nom = "Muffin aux bleuets", Qty = 60, Prix = 3, Image = "muffin.jpg", EstActif = true, Note = 5, ValeurNutritive = "Calories: 380, Lipides: 16g, Sucres: 28g" },
                new Produit { ProduitId = 31, Nom = "BandAid", Qty = 0, Prix = 3, Image = "Aid.jpg", EstActif = true, Note = 5, ValeurNutritive = "Calories: 0" }
            );
        }
    }
}
