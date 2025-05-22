using Xunit;
using Microsoft.EntityFrameworkCore;
using E25ProjetEtendu.Services;
using E25ProjetEtendu.Data;
using System.Threading.Tasks;
using System.Linq;
using E25ProjetEtendu.Models.DTOs;
using E25ProjetEtendu.Models;
using System.Collections.Generic;

public class ProduitServiceTests
{
    private ApplicationDbContext GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(Guid.NewGuid().ToString())
           .Options;

        var context = new ApplicationDbContext(options);

        context.produits.Add(new Produit { ProduitId = 1, Nom = "Coca-Cola", InventoryQuantity = 10, EstActif = true, Prix = 2, Note = 4, Image = "test.jpg", ValeurNutritive = "Test" });
        context.produits.Add(new Produit { ProduitId = 2, Nom = "Red Bull", InventoryQuantity = 15, EstActif = true, Prix = 3, Note = 5, Image = "test.jpg", ValeurNutritive = "Test" });
        context.produits.Add(new Produit { ProduitId = 3, Nom = "Pogo", InventoryQuantity = 5, EstActif = true, Prix = 1, Note = 2, Image = "test.jpg", ValeurNutritive = "Test" });
        context.SaveChanges();

        return context;
    }

    [Fact]
    public async Task GetFilteredProducts_Returns_Filtered_By_Search()
    {
        var context = GetInMemoryDbContext();
        var service = new ProduitService(context, null);

        var (produits, total) = await service.GetFilteredProducts("Coca", null, 1, 10);

        Assert.Single(produits);
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
        Assert.Equal("Red Bull", produits.First().Nom);
    }

    [Fact]
    public async Task GetFilteredProducts_Returns_Sorted_By_Price_()
    {
        var context = GetInMemoryDbContext();
        var service = new ProduitService(context, null);

        var (produits, _) = await service.GetFilteredProducts(null, "prix", 1, 10);

        Assert.Equal(3, produits.Count);
        Assert.Equal("Pogo", produits.First().Nom);
    }

    [Fact]
    public async Task GetFilteredProducts_Returns_Sorted_By_Note_Descending()
    {
        var context = GetInMemoryDbContext();
        var service = new ProduitService(context, null);

        var (produits, _) = await service.GetFilteredProducts(null, "note_desc", 1, 10);

        Assert.Equal(3, produits.Count);
        Assert.Equal("Red Bull", produits.First().Nom);
    }

    [Fact]
    public async Task GetFilteredProducts_Returns_Sorted_By_Note()
    {
        var context = GetInMemoryDbContext();
        var service = new ProduitService(context, null);

        var (produits, _) = await service.GetFilteredProducts(null, "note", 1, 10);

        Assert.Equal(3, produits.Count);
        Assert.Equal("Pogo", produits.First().Nom);
    }

    [Fact]
    public async Task GetFilteredProducts_Returns_Paged_Correctly()
    {
        var context = GetInMemoryDbContext();
        var service = new ProduitService(context, null);

        var (produitsPage1, _) = await service.GetFilteredProducts(null, null, 1, 2);
        var (produitsPage2, _) = await service.GetFilteredProducts(null, null, 2, 2);

        Assert.Equal(2, produitsPage1.Count);
        Assert.Single(produitsPage2);
    }

    [Fact]
    public async Task GetProduitsSimilairesAsync_Returns_Similar_Products_By_Note_Or_Price()
    {
        var context = GetInMemoryDbContext();
        var service = new ProduitService(context, null);

        var produitRef = new Produit { ProduitId = 99, Nom = "ProduitRef", Prix = 2, Note = 5 };

        var similaires = await service.GetProduitsSimilairesAsync(produitRef);

        Assert.NotNull(similaires);
        Assert.Equal(2, similaires.Count);
        Assert.Contains(similaires, p => p.Nom == "Coca-Cola");
        Assert.Contains(similaires, p => p.Nom == "Red Bull");
    }

    [Fact]
    public async Task HasSufficientStock_ShouldReturnTrue_WhenEnoughStockAvailable()
    {
        var context = GetInMemoryDbContext();
        var service = new ProduitService(context, null);

        var items = new List<CartItemDTO> { new CartItemDTO { ProductId = 1, Quantity = 5 } };

        var result = await service.HasSufficientStock(items);
        Assert.True(result);
    }

    [Fact]
    public async Task HasSufficientStock_ShouldReturnFalse_WhenStockTooLow()
    {
        var context = GetInMemoryDbContext();
        var service = new ProduitService(context, null);

        var items = new List<CartItemDTO> { new CartItemDTO { ProductId = 3, Quantity = 10 } };

        var result = await service.HasSufficientStock(items);
        Assert.False(result);
    }

    [Fact]
    public async Task ReserveStock_ShouldReturnTrue_WhenStockIsSufficient()
    {
        var context = GetInMemoryDbContext();
        var service = new ProduitService(context, null);

        var items = new List<CartItemDTO> { new CartItemDTO { ProductId = 2, Quantity = 4 } };

        var result = await service.ReserveStock(items, "user1");
        Assert.True(result);

        var reservations = context.StockReservations.Where(r => r.UserId == "user1").ToList();
        Assert.Single(reservations);
    }

    [Fact]
    public async Task ReserveStock_ShouldReturnFalse_WhenProductDoesNotExist()
    {
        var context = GetInMemoryDbContext();
        var service = new ProduitService(context, null);

        var items = new List<CartItemDTO> { new CartItemDTO { ProductId = 999, Quantity = 1 } };

        var result = await service.ReserveStock(items, "user2");
        Assert.False(result);
    }

    [Fact]
    public async Task FinalizeReservation_ShouldDeductStock()
    {
        var context = GetInMemoryDbContext();
        var service = new ProduitService(context, null);

        await context.StockReservations.AddAsync(new StockReservation { ProductId = 1, Quantity = 3, UserId = "user3", ReservedAt = DateTime.Now });
        await context.SaveChangesAsync();

        await service.FinalizeReservation("user3");
        var updatedProduit = await context.produits.FindAsync(1);

        Assert.Equal(7, updatedProduit.InventoryQuantity);
        Assert.Empty(context.StockReservations.ToList());
    }

    [Fact]
    public async Task CancelReservation_ShouldRemoveReservationsOnly()
    {
        var context = GetInMemoryDbContext();
        var service = new ProduitService(context, null);

        await context.StockReservations.AddAsync(new StockReservation { ProductId = 2, Quantity = 2, UserId = "user4", ReservedAt = DateTime.Now });
        await context.SaveChangesAsync();

        await service.CancelReservation("user4");
        Assert.Empty(context.StockReservations.ToList());
    }

    [Fact]
    public async Task CleanupExpiredReservations_ShouldRemoveOldEntries()
    {
        var context = GetInMemoryDbContext();
        var service = new ProduitService(context, null);

        await context.StockReservations.AddRangeAsync(new List<StockReservation>
        {
            new StockReservation { ProductId = 1, Quantity = 1, UserId = "user5", ReservedAt = DateTime.Now.AddMinutes(-11) },
            new StockReservation { ProductId = 1, Quantity = 1, UserId = "user5", ReservedAt = DateTime.Now }
        });
        await context.SaveChangesAsync();

        await service.CleanupExpiredReservations();

        var remaining = context.StockReservations.ToList();
        Assert.Single(remaining);
        Assert.True(remaining[0].ReservedAt > DateTime.Now.AddMinutes(-10));
    }

    [Fact]
    public async Task ReserveStock_ShouldAllowMultipleUsersIfStockAllows()
    {
        var context = GetInMemoryDbContext();
        var service = new ProduitService(context, null);

        var item = new CartItemDTO { ProductId = 1, Quantity = 5 };
        var result1 = await service.ReserveStock(new List<CartItemDTO> { item }, "userA");
        var result2 = await service.ReserveStock(new List<CartItemDTO> { item }, "userB");

        Assert.True(result1);
        Assert.True(result2);
        Assert.Equal(2, context.StockReservations.Count());
    }

    [Fact]
    public async Task FinalizeReservation_WithNoReservations_ShouldNotThrow()
    {
        var context = GetInMemoryDbContext();
        var service = new ProduitService(context, null);

        var exception = await Record.ExceptionAsync(() => service.FinalizeReservation("no-user"));

        Assert.Null(exception);
    }

    [Fact]
    public async Task CleanupExpiredReservations_WithNoExpired_ShouldNotThrow()
    {
        var context = GetInMemoryDbContext();
        var service = new ProduitService(context, null);

        await context.StockReservations.AddAsync(new StockReservation { ProductId = 2, Quantity = 1, UserId = "active-user", ReservedAt = DateTime.Now });
        await context.SaveChangesAsync();

        var beforeCount = context.StockReservations.Count();
        var exception = await Record.ExceptionAsync(() => service.CleanupExpiredReservations());

        var afterCount = context.StockReservations.Count();
        Assert.Null(exception);
        Assert.Equal(beforeCount, afterCount);
    }

    [Fact]
    public async Task HasSufficientStock_ShouldIgnoreExpiredReservations()
    {
        var context = GetInMemoryDbContext();
        var service = new ProduitService(context, null);

        await context.StockReservations.AddAsync(new StockReservation { ProductId = 2, Quantity = 10, UserId = "old-user", ReservedAt = DateTime.Now.AddMinutes(-20) });
        await context.SaveChangesAsync();

        var items = new List<CartItemDTO> { new CartItemDTO { ProductId = 2, Quantity = 10 } };
        var result = await service.HasSufficientStock(items);

        Assert.True(result);
    }

    [Fact]
    public async Task ReserveStock_ShouldReturnFalse_WhenStockIsInsufficientDueToActiveReservations()
    {
        var context = GetInMemoryDbContext();
        var service = new ProduitService(context, null);

        await context.StockReservations.AddAsync(new StockReservation { ProductId = 3, Quantity = 4, UserId = "blocker", ReservedAt = DateTime.Now });
        await context.SaveChangesAsync();

        var items = new List<CartItemDTO> { new CartItemDTO { ProductId = 3, Quantity = 3 } }; // Only 1 available
        var result = await service.ReserveStock(items, "another-user");

        Assert.False(result);
    }
}
