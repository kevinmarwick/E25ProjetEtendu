using E25ProjetEtendu.Controllers;
using E25ProjetEtendu.Models;
using E25ProjetEtendu.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E25ProjetEtenduTest.ControllerTest
{
    public class ProduitsControllerTests
    {
        [Fact]
        public async Task Index_ReturnsCorrectView_WithSearchAndSort()
        {
            // Arrange
            var mockService = new Mock<IProduitService>();
            mockService
                .Setup(s => s.GetFilteredProductsAsync("test", "note_desc", 1, 5))
                .ReturnsAsync((new List<Produit>
                {
                new Produit { ProduitId = 1, Nom = "Test", Note = 5, EstActif = true }
                }, 1));

            var controller = new ProduitController(mockService.Object);

            // Act
            var result = await controller.Index("test", 1, "note_desc") as ViewResult;

            // Assert
            Assert.NotNull(result);
            var model = result.Model as IEnumerable<Produit>;
            Assert.Single(model);
        }
    }

}
