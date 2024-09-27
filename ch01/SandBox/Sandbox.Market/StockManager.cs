namespace Sandbox.Market;

using System;
using System.Collections.Generic;

public class StockManager
{
    private readonly StockContext _context;

    public StockManager(StockContext context)
    {
        _context = context;
    }

    public void AddProduct(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public void DisplayProducts()
    {
        var products = _context.Products.ToList();
        foreach (var product in products)
        {
            Console.WriteLine($"Name: {product.Name}, Quantity In Stock: {product.QuantityInStock}, Price: {product.Price}");
        }
    }
    public void UpdateProductQuantity(int productId, int newQuantity)
    {
        var product = _context.Products.Find(productId);
        if (product != null)
        {
            product.QuantityInStock = newQuantity;
            _context.SaveChanges();
        }
    }

    public void RemoveProduct(int productId)
    {
        var product = _context.Products.Find(productId);
        if (product != null)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }

    public List<Product> SearchProducts(string searchTerm)
    {
        return _context.Products
        .Where(p => p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
        .ToList();
    }

    public int CountProduct() { return _context.Products.Count(); }

}