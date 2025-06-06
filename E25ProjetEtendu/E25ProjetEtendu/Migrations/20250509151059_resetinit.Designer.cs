﻿// <auto-generated />
using System;
using E25ProjetEtendu.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace E25ProjetEtendu.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250509151059_resetinit")]
    partial class resetinit
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("E25ProjetEtendu.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "21111111-1111-1111-1111-111111111111",
                            AccessFailedCount = 0,
                            Balance = 0m,
                            ConcurrencyStamp = "b094cf43-82dc-44eb-96db-020547d3f776",
                            Email = "admin@example.com",
                            EmailConfirmed = true,
                            FirstName = "Admin",
                            LastName = "Admin",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@EXAMPLE.COM",
                            NormalizedUserName = "ADMIN@EXAMPLE.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEK5DBW34bAZxyef9Zv7tUat8nXQ5lymzZMnzheruQPniCzyzJalGAHseSPqD21dYJw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "68014b63-da07-4401-8380-f99f8c890d76",
                            TwoFactorEnabled = false,
                            UserName = "admin@example.com"
                        });
                });

            modelBuilder.Entity("E25ProjetEtendu.Models.Produit", b =>
                {
                    b.Property<int>("ProduitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProduitId"));

                    b.Property<bool>("EstActif")
                        .HasColumnType("bit");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("Note")
                        .HasColumnType("int");

                    b.Property<decimal>("Prix")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.Property<string>("ValeurNutritive")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("ProduitId");

                    b.ToTable("produits");

                    b.HasData(
                        new
                        {
                            ProduitId = 1,
                            EstActif = true,
                            Image = "redbull.png",
                            Nom = "Red Bull",
                            Note = 4,
                            Prix = 3m,
                            Qty = 120,
                            ValeurNutritive = "Calories: 110, Sucres: 27g, Caféine: 80mg, Glucides: 28g, Protéines: 1g"
                        },
                        new
                        {
                            ProduitId = 2,
                            EstActif = true,
                            Image = "pogo.jpg",
                            Nom = "Pogo",
                            Note = 3,
                            Prix = 2m,
                            Qty = 200,
                            ValeurNutritive = "Calories: 190, Lipides: 9g, Glucides: 20g, Protéines: 6g, Sodium: 500mg"
                        },
                        new
                        {
                            ProduitId = 3,
                            EstActif = true,
                            Image = "eau.jpg",
                            Nom = "Bouteille d'eau",
                            Note = 5,
                            Prix = 1m,
                            Qty = 300,
                            ValeurNutritive = "Calories: 0, Lipides: 0g, Sucres: 0g, Sodium: 0mg"
                        },
                        new
                        {
                            ProduitId = 4,
                            EstActif = true,
                            Image = "chips.jpg",
                            Nom = "Chips Lay’s",
                            Note = 4,
                            Prix = 2m,
                            Qty = 100,
                            ValeurNutritive = "Calories: 160, Lipides: 10g, Glucides: 15g, Sucres: 1g, Sodium: 170mg"
                        },
                        new
                        {
                            ProduitId = 5,
                            EstActif = true,
                            Image = "nutella.jpg",
                            Nom = "Nutella",
                            Note = 5,
                            Prix = 5m,
                            Qty = 80,
                            ValeurNutritive = "Calories: 200, Lipides: 11g, Glucides: 22g, Sucres: 21g, Protéines: 2g"
                        },
                        new
                        {
                            ProduitId = 6,
                            EstActif = true,
                            Image = "activia.jpg",
                            Nom = "Yogourt Activia",
                            Note = 4,
                            Prix = 3m,
                            Qty = 150,
                            ValeurNutritive = "Calories: 100, Lipides: 2g, Glucides: 15g, Sucres: 12g, Protéines: 5g"
                        },
                        new
                        {
                            ProduitId = 7,
                            EstActif = true,
                            Image = "pizza.jpg",
                            Nom = "Pizza congelée",
                            Note = 4,
                            Prix = 6m,
                            Qty = 60,
                            ValeurNutritive = "Calories: 350, Lipides: 15g, Glucides: 40g, Sucres: 5g, Protéines: 12g"
                        },
                        new
                        {
                            ProduitId = 8,
                            EstActif = true,
                            Image = "granola.jpg",
                            Nom = "Barre de granola",
                            Note = 4,
                            Prix = 2m,
                            Qty = 180,
                            ValeurNutritive = "Calories: 190, Lipides: 7g, Glucides: 29g, Sucres: 11g, Protéines: 4g"
                        },
                        new
                        {
                            ProduitId = 9,
                            EstActif = true,
                            Image = "coca.jpg",
                            Nom = "Coca-Cola",
                            Note = 3,
                            Prix = 2m,
                            Qty = 220,
                            ValeurNutritive = "Calories: 140, Sucres: 39g, Glucides: 39g, Sodium: 45mg"
                        },
                        new
                        {
                            ProduitId = 10,
                            EstActif = true,
                            Image = "sandwich.jpg",
                            Nom = "Sandwich jambon-fromage",
                            Note = 4,
                            Prix = 4m,
                            Qty = 75,
                            ValeurNutritive = "Calories: 320, Lipides: 12g, Glucides: 30g, Protéines: 18g, Sodium: 780mg"
                        },
                        new
                        {
                            ProduitId = 11,
                            EstActif = true,
                            Image = "starbucks.jpg",
                            Nom = "Café Starbucks",
                            Note = 4,
                            Prix = 4m,
                            Qty = 90,
                            ValeurNutritive = "Calories: 150, Sucres: 20g, Caféine: 95mg"
                        },
                        new
                        {
                            ProduitId = 12,
                            EstActif = true,
                            Image = "axe.jpg",
                            Nom = "Déodorant Axe",
                            Note = 5,
                            Prix = 6m,
                            Qty = 50,
                            ValeurNutritive = "Sans calories"
                        },
                        new
                        {
                            ProduitId = 13,
                            EstActif = true,
                            Image = "headshoulders.jpg",
                            Nom = "Shampooing Head & Shoulders",
                            Note = 4,
                            Prix = 7m,
                            Qty = 60,
                            ValeurNutritive = "Sans calories"
                        },
                        new
                        {
                            ProduitId = 14,
                            EstActif = true,
                            Image = "benjerry.jpg",
                            Nom = "Crème glacée Ben & Jerry's",
                            Note = 5,
                            Prix = 8m,
                            Qty = 40,
                            ValeurNutritive = "Calories: 270, Lipides: 14g, Sucres: 26g"
                        },
                        new
                        {
                            ProduitId = 15,
                            EstActif = true,
                            Image = "pain.jpg",
                            Nom = "Pain tranché",
                            Note = 3,
                            Prix = 3m,
                            Qty = 120,
                            ValeurNutritive = "Calories: 80, Glucides: 15g, Protéines: 3g"
                        },
                        new
                        {
                            ProduitId = 16,
                            EstActif = true,
                            Image = "cheddar.jpg",
                            Nom = "Fromage cheddar",
                            Note = 4,
                            Prix = 5m,
                            Qty = 100,
                            ValeurNutritive = "Calories: 110, Lipides: 9g, Protéines: 7g"
                        },
                        new
                        {
                            ProduitId = 17,
                            EstActif = true,
                            Image = "yaourt.jpg",
                            Nom = "Yaourt grec",
                            Note = 4,
                            Prix = 4m,
                            Qty = 130,
                            ValeurNutritive = "Calories: 120, Protéines: 10g, Sucres: 8g"
                        },
                        new
                        {
                            ProduitId = 18,
                            EstActif = true,
                            Image = "ritz.jpg",
                            Nom = "Crackers Ritz",
                            Note = 3,
                            Prix = 3m,
                            Qty = 80,
                            ValeurNutritive = "Calories: 160, Lipides: 8g, Glucides: 20g"
                        },
                        new
                        {
                            ProduitId = 19,
                            EstActif = true,
                            Image = "soupe.jpg",
                            Nom = "Soupe Campbell",
                            Note = 4,
                            Prix = 2m,
                            Qty = 70,
                            ValeurNutritive = "Calories: 90, Sodium: 480mg"
                        },
                        new
                        {
                            ProduitId = 20,
                            EstActif = true,
                            Image = "tropicana.jpg",
                            Nom = "Jus d'orange Tropicana",
                            Note = 4,
                            Prix = 3m,
                            Qty = 150,
                            ValeurNutritive = "Calories: 110, Sucres: 23g"
                        },
                        new
                        {
                            ProduitId = 21,
                            EstActif = true,
                            Image = "colgate.jpg",
                            Nom = "Brosse à dents Colgate",
                            Note = 4,
                            Prix = 2m,
                            Qty = 200,
                            ValeurNutritive = "Sans calories"
                        },
                        new
                        {
                            ProduitId = 22,
                            EstActif = true,
                            Image = "sensodyne.jpg",
                            Nom = "Dentifrice Sensodyne",
                            Note = 5,
                            Prix = 5m,
                            Qty = 150,
                            ValeurNutritive = "Sans calories"
                        },
                        new
                        {
                            ProduitId = 23,
                            EstActif = true,
                            Image = "dove.jpg",
                            Nom = "Savon Dove",
                            Note = 4,
                            Prix = 2m,
                            Qty = 180,
                            ValeurNutritive = "Sans calories"
                        },
                        new
                        {
                            ProduitId = 24,
                            EstActif = true,
                            Image = "gatorade.jpg",
                            Nom = "Boisson Gatorade",
                            Note = 4,
                            Prix = 3m,
                            Qty = 110,
                            ValeurNutritive = "Calories: 80, Sucres: 21g"
                        },
                        new
                        {
                            ProduitId = 25,
                            EstActif = true,
                            Image = "kinder.jpg",
                            Nom = "Chocolat Kinder",
                            Note = 5,
                            Prix = 2m,
                            Qty = 100,
                            ValeurNutritive = "Calories: 120, Sucres: 12g"
                        },
                        new
                        {
                            ProduitId = 26,
                            EstActif = true,
                            Image = "cheerios.jpg",
                            Nom = "Céréales Cheerios",
                            Note = 4,
                            Prix = 4m,
                            Qty = 90,
                            ValeurNutritive = "Calories: 110, Glucides: 20g, Protéines: 3g"
                        },
                        new
                        {
                            ProduitId = 27,
                            EstActif = true,
                            Image = "oreo.jpg",
                            Nom = "Biscuit Oreo",
                            Note = 4,
                            Prix = 3m,
                            Qty = 130,
                            ValeurNutritive = "Calories: 160, Sucres: 14g"
                        },
                        new
                        {
                            ProduitId = 28,
                            EstActif = true,
                            Image = "beurre.jpg",
                            Nom = "Beurre d'arachide",
                            Note = 4,
                            Prix = 5m,
                            Qty = 70,
                            ValeurNutritive = "Calories: 190, Lipides: 16g, Protéines: 7g"
                        },
                        new
                        {
                            ProduitId = 29,
                            EstActif = true,
                            Image = "perrier.jpg",
                            Nom = "Eau gazeuse Perrier",
                            Note = 4,
                            Prix = 2m,
                            Qty = 200,
                            ValeurNutritive = "Calories: 0"
                        },
                        new
                        {
                            ProduitId = 30,
                            EstActif = true,
                            Image = "muffin.jpg",
                            Nom = "Muffin aux bleuets",
                            Note = 5,
                            Prix = 3m,
                            Qty = 60,
                            ValeurNutritive = "Calories: 380, Lipides: 16g, Sucres: 28g"
                        },
                        new
                        {
                            ProduitId = 31,
                            EstActif = true,
                            Image = "Aid.jpg",
                            Nom = "BandAid",
                            Note = 5,
                            Prix = 3m,
                            Qty = 0,
                            ValeurNutritive = "Calories: 0"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "admin-role-id",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "21111111-1111-1111-1111-111111111111",
                            RoleId = "admin-role-id"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("E25ProjetEtendu.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("E25ProjetEtendu.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E25ProjetEtendu.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("E25ProjetEtendu.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
