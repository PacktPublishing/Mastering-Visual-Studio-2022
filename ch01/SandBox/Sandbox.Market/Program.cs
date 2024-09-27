









using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sandbox.Market;

var serviceProvider = new ServiceCollection()
           .AddDbContext<StockContext>(options =>
               options.UseInMemoryDatabase("StockDatabase"))
           .AddTransient<StockManager>()
           .BuildServiceProvider();

var stockManager = serviceProvider.GetService<StockManager>();

//var apple = new Product {
//    Name = "Apple", 
//    QuantityInStock = 100, 
//    Price = 0.5m 
//};

//stockManager?.AddProduct(apple);

//stockManager.UpdateProductQuantity(apple.Id, 150);

var searchResults = stockManager.SearchProducts("Apple");
foreach (var result in searchResults)
{
    Console.WriteLine(
        $"Found product: {result.Name}, " +
        $"Quantity In Stock: {result.QuantityInStock}, " +
        $"Price: {result.Price}"
        );
}

//stockManager.RemoveProduct(apple.Id);

var productFaker = new Faker<Product>()
           .RuleFor(p => p.Name, f => f.Commerce.ProductName())
           .RuleFor(p => p.QuantityInStock, f => f.Random.Number(1, 100))
           .RuleFor(p => p.Price, f => f.Finance.Random.Decimal(0.1m, 10.0m));

var fakeProducts = productFaker.Generate(1500);
var apple = new Product
{
    Name = "Apple",
    QuantityInStock = 100,
    Price = 0.5m
};

foreach (var product in fakeProducts)
{
    stockManager?.AddProduct(product);
}








