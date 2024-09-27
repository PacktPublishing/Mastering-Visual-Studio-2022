using Microsoft.EntityFrameworkCore;
using Sandbox.Market;

namespace StockManagementTests;

public class StockManagerTests
{
    [Fact]
    public void AddProduct_ShouldAddProductToDatabase()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<StockContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        using (var context = new StockContext(options))
        {
            var stockManager = new StockManager(context);
            var product = new Product { Name = "Test Product", QuantityInStock = 10, Price = 1.99m };

            // Act
            stockManager.AddProduct(product);

            // Assert
            Assert.Single(context.Products);
            Assert.Equal(product.Name, context.Products.Single().Name);
        }
    }

    [Fact]
    public void UpdateProductQuantity_ShouldUpdateProductQuantity()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<StockContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        using (var context = new StockContext(options))
        {
            var stockManager = new StockManager(context);
            var product = new Product { Name = "Test Product", QuantityInStock = 10, Price = 1.99m };
            stockManager.AddProduct(product);

            // Act
            stockManager.UpdateProductQuantity(product.Id, 20);

            // Assert
            Assert.Equal(20, context.Products.Single().QuantityInStock);
        }
    }

    [Fact]
    public void RemoveProduct_ShouldRemoveProductFromDatabase()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<StockContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        using (var context = new StockContext(options))
        {
            var stockManager = new StockManager(context);
            var product = new Product { Name = "Test Product", QuantityInStock = 10, Price = 1.99m };
            stockManager.AddProduct(product);

            // Act
            stockManager.RemoveProduct(product.Id);

            // Assert
            Assert.Empty(context.Products);
        }
    }

    [Fact]
    public void SearchProducts_ShouldReturnMatchingProducts()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<StockContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        using (var context = new StockContext(options))
        {
            var stockManager = new StockManager(context);
            var product1 = new Product { Name = "Apple", QuantityInStock = 10, Price = 1.99m };
            var product2 = new Product { Name = "Orange", QuantityInStock = 20, Price = 2.99m };
            stockManager.AddProduct(product1);
            stockManager.AddProduct(product2);

            // Act
            var searchResults = stockManager.SearchProducts("Apple");

            // Assert
            Assert.Single(searchResults);
            Assert.Equal("Apple", searchResults.Single().Name);
        }
    }
}