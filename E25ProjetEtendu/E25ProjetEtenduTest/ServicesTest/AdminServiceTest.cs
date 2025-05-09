using Xunit;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E25ProjetEtendu.Services;
using E25ProjetEtendu.Services.IServices;
using E25ProjetEtendu.Models;
using E25ProjetEtendu.Data;
using E25ProjetEtendu.ViewModels;
using Microsoft.AspNetCore.Http;
using System.IO;

public class AdminServiceTests
{
    private ApplicationDbContext GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: System.Guid.NewGuid().ToString())
            .Options;

        return new ApplicationDbContext(options);
    }

    [Fact]
    public async Task GetAllProducts_Returns_OrderedList()
    {
        using var context = GetInMemoryDbContext();
        context.produits.AddRange(
            new Produit { Nom = "B", Image = "", ValeurNutritive = "100 cal" },
            new Produit { Nom = "A", Image = "", ValeurNutritive = "200 cal" }
        );
        await context.SaveChangesAsync();

        var produitServiceMock = new Mock<IProduitService>();
        var service = new AdminService(context, produitServiceMock.Object);

        var result = await service.GetAllProducts();

        Assert.Equal(2, result.Count());
        Assert.Equal("A", result.First().Nom);
    }

    [Fact]
    public async Task UpdateInventoryAndPrice_Updates_Product()
    {
        using var context = GetInMemoryDbContext();

        var produit = new Produit { ProduitId = 1, Nom = "Test", Qty = 5, Prix = 10, Image = "", ValeurNutritive = "Test" };
        context.produits.Add(produit);
        await context.SaveChangesAsync();

        var produitServiceMock = new Mock<IProduitService>();
        produitServiceMock.Setup(p => p.GetProduitById(1)).ReturnsAsync(produit);

        var service = new AdminService(context, produitServiceMock.Object);

        await service.UpdateInventoryAndPrice(1, 20, 19.99m);

        var updated = context.produits.First();
        Assert.Equal(20, updated.Qty);
        Assert.Equal(19.99m, updated.Prix);
    }

    [Fact]
    public async Task AddProductFromVM_Adds_Product_With_Image()
    {
        using var context = GetInMemoryDbContext();

        var produitServiceMock = new Mock<IProduitService>();
        var service = new AdminService(context, produitServiceMock.Object);

        var vm = new AddProductVM
        {
            Nom = "Produit",
            Prix = 5.00m,
            Qty = 10,
            EstActif = true,
            ValeurNutritive = "Info",
            ImageFile = null // image null = filename will be null
        };

        var result = await service.AddProductFromVM(vm);

        Assert.Single(context.produits);
        Assert.Equal("Produit", result.Nom);
        Assert.Equal("Info", result.ValeurNutritive);
        Assert.Null(result.Image);
    }

    [Fact]
    public async Task GetEditProductVM_Returns_VM_IfProductExists()
    {
        using var context = GetInMemoryDbContext();

        var produit = new Produit { ProduitId = 1, Nom = "Produit", Image = "img.jpg", ValeurNutritive = "Nutri" };
        context.produits.Add(produit);
        await context.SaveChangesAsync();

        var produitServiceMock = new Mock<IProduitService>();
        produitServiceMock.Setup(p => p.GetProduitById(1)).ReturnsAsync(produit);

        var service = new AdminService(context, produitServiceMock.Object);

        var vm = await service.GetEditProductVM(1);

        Assert.NotNull(vm);
        Assert.Equal("Produit", vm.Nom);
        Assert.Equal("img.jpg", vm.CurrentImage);
    }

    [Fact]
    public async Task EditProductFromVM_Updates_Fields_And_Image()
    {
        using var context = GetInMemoryDbContext();

        var produit = new Produit { ProduitId = 1, Nom = "Old", Image = "old.jpg", ValeurNutritive = "Old" };
        context.produits.Add(produit);
        await context.SaveChangesAsync();

        var produitServiceMock = new Mock<IProduitService>();
        produitServiceMock.Setup(p => p.GetProduitById(1)).ReturnsAsync(produit);

        var service = new AdminService(context, produitServiceMock.Object);

        var vm = new EditProductVM
        {
            ProduitId = 1,
            Nom = "New",
            ValeurNutritive = "New Info",
            NewImageFile = null // image non modifiée
        };

        var updated = await service.EditProductFromVM(vm);

        Assert.Equal("New", updated.Nom);
        Assert.Equal("New Info", updated.ValeurNutritive);
        Assert.Equal("old.jpg", updated.Image); // inchangé
    }
}
