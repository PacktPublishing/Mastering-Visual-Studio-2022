namespace Database.Helper;

using Bogus;
using Database.Model;
using System.Collections.Generic;

public static class DataGenerator
{
    public static List<Category> GenerateCategories(int count)
    {
        var faker = new Faker<Category>()
            .RuleFor(c => c.Name, f => f.Commerce.Department());

        return faker.Generate(count);
    }

    public static List<Product> GenerateProducts(int count, List<Category> categories)
    {
        var faker = new Faker<Product>()
            .RuleFor(p => p.Name, f => f.Commerce.ProductName())
            .RuleFor(p => p.Price, f => f.Finance.Amount(1, 100))
            .RuleFor(p => p.CategoryId, f => f.PickRandom(categories).Id);

        return faker.Generate(count);
    }

    public static List<Inventory> GenerateInventories(int count, List<Product> products)
    {
        var faker = new Faker<Inventory>()
            .RuleFor(i => i.ProductId, f => f.PickRandom(products).Id)
            .RuleFor(i => i.Quantity, f => f.Random.Number(1, 100));

        return faker.Generate(count);
    }
}
