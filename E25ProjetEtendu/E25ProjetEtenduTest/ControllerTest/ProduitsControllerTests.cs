using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using E25ProjetEtendu.Controllers;
using E25ProjetEtendu.Models;
using E25ProjetEtendu.Services.IServices;

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
}
