using Xunit;
using Microsoft.EntityFrameworkCore;
using E25ProjetEtendu.Services;
using E25ProjetEtendu.Data;
using System.Threading.Tasks;
using System.Linq;

public class ProduitServiceTests
{
    private ApplicationDbContext GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(Guid.NewGuid().ToString()) // ✅ unique DB per test
           .Options;

        var context = new ApplicationDbContext(options);

        // Seed
        context.produits.Add(new E25ProjetEtendu.Models.Produit { ProduitId = 1, Nom = "Coca-Cola", EstActif = true, Prix = 2, Note = 4, ValeurNutritive= "", Image="" });
        context.produits.Add(new E25ProjetEtendu.Models.Produit { ProduitId = 2, Nom = "Red Bull", EstActif = true, Prix = 3, Note = 5, ValeurNutritive = "", Image = "" });
        context.produits.Add(new E25ProjetEtendu.Models.Produit { ProduitId = 3, Nom = "Pogo", EstActif = true, Prix = 1, Note = 2, ValeurNutritive = "", Image = "" });
        context.SaveChanges();

        return context;
    }

    [Fact]
    public async Task GetFilteredProducts_Returns_Filtered_By_Search()
    {
        var context = GetInMemoryDbContext();
        var service = new ProduitService(context, null);

        var (produits, total) = await service.GetFilteredProducts("Coca", null, 1, 10);

        Assert.Single(produits);  // should return only Coca-Cola
        Assert.Equal("Coca-Cola", produits.First().Nom);
        Assert.Equal(1, total);
    }

    [Fact]
    public async Task GetFilteredProducts_Returns_Sorted_By_Price_Descending()
    {
        var context = GetInMemoryDbContext();
        var service = new ProduitService(context, null);

        var (produits, _) = await service.GetFilteredProducts(null, "prix_desc", 1, 10);

        Assert.Equal(3, produits.Count);
        Assert.Equal("Red Bull", produits.First().Nom);  // Highest price first
    }
    [Fact]
    public async Task GetFilteredProducts_Returns_Sorted_By_Price_()
    {
        var context = GetInMemoryDbContext();
        var service = new ProduitService(context, null);

        var (produits, _) = await service.GetFilteredProducts(null, "prix", 1, 10);

        Assert.Equal(3, produits.Count);
        Assert.Equal("Pogo", produits.First().Nom);  // lowest price first
    }
    [Fact]
    public async Task GetFilteredProducts_Returns_Sorted_By_Note_Descending()
    {
        var context = GetInMemoryDbContext();
        var service = new ProduitService(context, null);

        var (produits, _) = await service.GetFilteredProducts(null, "note_desc", 1, 10);

        Assert.Equal(3, produits.Count);
        Assert.Equal("Red Bull", produits.First().Nom);  // Highest Note first
    }
    [Fact]
    public async Task GetFilteredProducts_Returns_Sorted_By_Note()
    {
        var context = GetInMemoryDbContext();
        var service = new ProduitService(context, null);

        var (produits, _) = await service.GetFilteredProducts(null, "note", 1, 10);

        Assert.Equal(3, produits.Count);
        Assert.Equal("Pogo", produits.First().Nom);  // lowest Note first
    }
    [Fact]
    public async Task GetFilteredProducts_Returns_Paged_Correctly()
    {
        var context = GetInMemoryDbContext();
        var service = new ProduitService(context, null);

        var (produitsPage1, _) = await service.GetFilteredProducts(null, null, 1, 2);
        var (produitsPage2, _) = await service.GetFilteredProducts(null, null, 2, 2);

        Assert.Equal(2, produitsPage1.Count); // First 2
        Assert.Single(produitsPage2);        // Last 1
    }

   
}
