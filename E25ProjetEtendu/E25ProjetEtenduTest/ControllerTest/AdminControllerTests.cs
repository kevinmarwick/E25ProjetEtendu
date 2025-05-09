using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using E25ProjetEtendu.Controllers;
using E25ProjetEtendu.Models;
using E25ProjetEtendu.Services.IServices;
using E25ProjetEtendu.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

public class AdminControllerTests
{
    private readonly Mock<IAdminService> _adminServiceMock;
    private readonly Mock<IProduitService> _produitServiceMock;
    private readonly AdminController _controller;

    public AdminControllerTests()
    {
        _adminServiceMock = new Mock<IAdminService>();
        _produitServiceMock = new Mock<IProduitService>();
        _controller = new AdminController(_adminServiceMock.Object, _produitServiceMock.Object);
    }

    [Fact]
    public void Dashboard_ReturnsView()
    {
        var result = _controller.Dashboard();
        Assert.IsType<ViewResult>(result);
    }

    [Fact]
    public async Task EditProduct_Get_ReturnsNotFound_WhenProductIsNull()
    {
        _adminServiceMock.Setup(s => s.GetEditProductVM(It.IsAny<int>()))
                         .ReturnsAsync((EditProductVM)null);

        var result = await _controller.EditProduct(99);

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task EditProduct_Get_ReturnsView_WhenProductFound()
    {
        var vm = new EditProductVM { ProduitId = 1, Nom = "Test" };
        _adminServiceMock.Setup(s => s.GetEditProductVM(1)).ReturnsAsync(vm);

        var result = await _controller.EditProduct(1);

        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.Equal(vm, viewResult.Model);
    }

    [Fact]
    public async Task EditProduct_Post_InvalidModelState_ReturnsView()
    {
        var vm = new EditProductVM();
        _controller.ModelState.AddModelError("Nom", "Required");

        var result = await _controller.EditProduct(vm);

        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.Equal(vm, viewResult.Model);
    }

    

    [Fact]
    public async Task IndexProduits_ReturnsProductList()
    {
        var produits = new List<Produit>
        {
            new Produit { ProduitId = 1, Nom = "A", Image = "", ValeurNutritive = "Valeur A" },
            new Produit { ProduitId = 2, Nom = "B", Image = "", ValeurNutritive = "Valeur B" }
        };

        _adminServiceMock.Setup(s => s.GetAllProducts()).ReturnsAsync(produits);

        var result = await _controller.IndexProduits();

        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsAssignableFrom<IEnumerable<Produit>>(viewResult.Model);
        Assert.Equal(2, model.Count());
    }

    [Fact]
    public async Task UpdateInventoryAndPrice_InvalidModelState_ReturnsBadRequest()
    {
        var model = new UpdateProductVM();
        _controller.ModelState.AddModelError("Qty", "Required");

        var result = await _controller.UpdateInventoryAndPrice(model);

        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public async Task UpdateInventoryAndPrice_ValidModel_ReturnsOk()
    {
        var model = new UpdateProductVM { ProduitId = 1, Qty = 10, Prix = 9.99m };

        var result = await _controller.UpdateInventoryAndPrice(model);

        _adminServiceMock.Verify(s => s.UpdateInventoryAndPrice(model.ProduitId, model.Qty, model.Prix), Times.Once);
        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public async Task AddProduct_Get_ReturnsView()
    {
        var result = await _controller.AddProduct();
        Assert.IsType<ViewResult>(result);
    }

    [Fact]
    public async Task AddProduct_Post_InvalidModelState_ReturnsView()
    {
        var vm = new AddProductVM();
        _controller.ModelState.AddModelError("Nom", "Required");

        var result = await _controller.AddProduct(vm);

        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.Equal(vm, viewResult.Model);
    }

    
}
