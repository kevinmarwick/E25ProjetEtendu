using E25ProjetEtendu.Data;
using E25ProjetEtendu.Models;
using E25ProjetEtendu.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Moq;


namespace E25ProjetEtenduTest.ServicesTest
{
    public class ProduitServiceTests
    {
        private ApplicationDbContext GetInMemoryDbContext()
        {
            DbContextOptions<ApplicationDbContext> options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            ApplicationDbContext context = new ApplicationDbContext(options);

            // Seed
            context.produits.AddRange(
                new Produit { ProduitId = 1, Nom = "Pomme", Qty = 10 ,Image = "",ValeurNutritive = "calorie: 2" ,EstActif = true, Prix = 1, Note = 5 },
                new Produit { ProduitId = 2, Nom = "Banane", Qty = 10, Image = "", ValeurNutritive = "calorie: 2",  EstActif = false, Prix = 2, Note = 3 },
                new Produit { ProduitId = 3, Nom = "Coca", Qty = 10, Image = "", ValeurNutritive = "calorie: 2", EstActif = false, Prix = 1, Note = 4 }
            );
            context.SaveChanges();

            return context;
        }

        [Fact]
        public async Task GetFilteredProductsAsync_ShouldFilterAndSortCorrectly()
        {
            // Arrange
            ApplicationDbContext db = GetInMemoryDbContext();

            var mockHttpContextAccessor = new Mock<IHttpContextAccessor>();
            mockHttpContextAccessor.Setup(x => x.HttpContext).Returns((HttpContext)null); // pas besoin d'implémenter pour ce test

            ProduitService service = new ProduitService(db, mockHttpContextAccessor.Object);

            // Act
            (List<Produit> produits, int total) = await service.GetFilteredProductsAsync("pomme", "note", 1, 10);

            // Assert
            Assert.Single(produits);
            Assert.Equal("pomme", produits[0].Nom, ignoreCase: true);
            Assert.Equal(1, total);
        }

    }

}
