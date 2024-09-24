using Database.Helper;
using Database.Infrastructure;
using Database.Model;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Database.Service;

public class ProductService : IProductService
{
    private readonly ProductDbContext _context;

    public ProductService(ProductDbContext context)
    {
        _context = context;
    }

    public void SeedProduts(int count)
    {
        var products = DataGenerator.GenerateProducts(count, [.. _context.Categories]);
        _context.Products.AddRange(products);
        _context.SaveChanges();
    }

    public List<Product> GetProducts()
    {
        return [.. _context.Products];
    }

    public List<Product> GetProductsADO()
    {
        string connectionString = "Data Source=product.db";
        string queryString = "SELECT ID, Name, Price FROM Products";

        List<Product> products = [];
        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            using var command = new SqliteCommand(queryString, connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"ProductID: {reader.GetInt32(0)}, ProductName: {reader.GetString(1)}, Price: {reader.GetDecimal(2)}");
                }
            }
        }

        return products;
    }
}
