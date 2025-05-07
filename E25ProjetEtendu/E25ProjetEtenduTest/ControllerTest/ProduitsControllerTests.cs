using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using E25ProjetEtendu.Controllers;
using E25ProjetEtendu.Models;
using E25ProjetEtendu.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using E25ProjetEtendu.ViewModels;
using System.Text.Json;



public class ProduitControllerTests
{
    [Fact]
    public async Task Index_Returns_View_With_Products()
    {
        var mockService = new Mock<IProduitService>();
        mockService.Setup(s => s.GetFilteredProducts(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
                   .ReturnsAsync((new List<Produit> { new Produit { Nom = "Coca-Cola" } }, 1));

        var controller = new ProduitController(mockService.Object);

        var result = await controller.Index("Coca", null, 1);

        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsAssignableFrom<IEnumerable<Produit>>(viewResult.Model);

        Assert.Single(model);
        Assert.Equal("Coca-Cola", model.First().Nom);
    }
    [Fact]
    public async Task AddToCart_ProduitValide()
    {
        //arrange
        var produitServiceMock = new Mock<IProduitService>();
        var controller = new ProduitController(produitServiceMock.Object);
        var tempData = new TempDataDictionary(new DefaultHttpContext(), Mock.Of<ITempDataProvider>());
        controller.TempData = tempData;


        int produitId = 1;
        int quantite = 2;
        //act

        var resultat = await controller.AddToCart(produitId, quantite);
        //assert
        produitServiceMock.Verify(s => s.AddToCart(produitId, quantite), Times.Once);
        var redirectToActionResult = Assert.IsType<RedirectToActionResult>(resultat);
        Assert.Equal("Index", redirectToActionResult.ActionName);
        Assert.Equal("Produit ajouté au panier !", controller.TempData["Success"]);

    }
    [Fact]
    public async Task AddToCart_WhenExceptionOccurs()
    {
        // Arrange
        var produitServiceMock = new Mock<IProduitService>();
        produitServiceMock
            .Setup(s => s.AddToCart(It.IsAny<int>(), It.IsAny<int>()))
            .ThrowsAsync(new System.Exception("Erreur test"));

        var controller = new ProduitController(produitServiceMock.Object);
        var tempData = new TempDataDictionary(new DefaultHttpContext(), Mock.Of<ITempDataProvider>());
        controller.TempData = tempData;
        // Act
        var result = await controller.AddToCart(1, 1);

        // Assert
        var redirectResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Index", redirectResult.ActionName);
        Assert.StartsWith("Erreur :", controller.TempData["Error"].ToString());
    }
    [Fact]
    public void AugmenterProduitAuPannier_ReturnsCorrectJson()
    {
        // Arrange
        var produitServiceMock = new Mock<IProduitService>();
        int productId = 1;

        var cartItems = new List<PannierProduitVM>
        {
        new PannierProduitVM { ProduitId = productId, Prix = 10, Quantite = 2 }
        };

        produitServiceMock.Setup(s => s.GetCartItems()).Returns(cartItems);

        var controller = new ProduitController(produitServiceMock.Object);

        // Act
        var result = controller.AugmenterProduitAuPannier(productId) as JsonResult;

        // Assert
        produitServiceMock.Verify(s => s.AugmenteProduitPannier(productId), Times.Once);
        Assert.NotNull(result);

        var jsonString = JsonSerializer.Serialize(result.Value);
        var json = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(jsonString);

        Assert.NotNull(json);
        Assert.Equal(productId, json["productId"].GetInt32());
        Assert.Equal(2, json["quantity"].GetInt32());
        Assert.Equal(20, json["subtotal"].GetDecimal());
        Assert.Equal(20, json["total"].GetDecimal());
    }
    [Fact]
    public void RetirerProduitDuPannier_ReturnsCorrectJson()
    {
        // Arrange
        var produitServiceMock = new Mock<IProduitService>();
        int productId = 1;

        var cartItems = new List<PannierProduitVM>
    {
        new PannierProduitVM { ProduitId = productId, Prix = 15, Quantite = 1 }
    };

        produitServiceMock.Setup(s => s.GetCartItems()).Returns(cartItems);

        var controller = new ProduitController(produitServiceMock.Object);

        // Act
        var result = controller.RetirerProduitDuPannier(productId) as JsonResult;

        // Assert
        produitServiceMock.Verify(s => s.EnleverProduitPannier(productId), Times.Once);
        Assert.NotNull(result);

        var jsonString = JsonSerializer.Serialize(result.Value);
        var json = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(jsonString);

        Assert.NotNull(json);
        Assert.Equal(productId, json["productId"].GetInt32());
        Assert.Equal(1, json["quantity"].GetInt32());
        Assert.Equal(15, json["subtotal"].GetDecimal());
        Assert.Equal(15, json["total"].GetDecimal());
    }
    [Fact]
    public void ViderPannier_ReturnsJsonSuccessTrue()
    {
        // Arrange
        var produitServiceMock = new Mock<IProduitService>();
        var controller = new ProduitController(produitServiceMock.Object);

        // Act
        var result = controller.ViderPannier() as JsonResult;

        // Assert
        produitServiceMock.Verify(s => s.VidePannier(), Times.Once);
        Assert.NotNull(result);

        var jsonString = JsonSerializer.Serialize(result.Value);
        var json = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(jsonString);

        Assert.NotNull(json);
        Assert.True(json["success"].GetBoolean());
    }




}
