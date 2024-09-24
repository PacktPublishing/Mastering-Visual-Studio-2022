using Database.Helper;
using Database.Infrastructure;
using Database.Model;
using Microsoft.EntityFrameworkCore;

namespace Database.Service;

public class CategorieService : ICategorieService
{
    private readonly ProductDbContext _context;

    public CategorieService(ProductDbContext context)
    {
        _context = context;
    }

    public async Task SeedCategories(int count)
    {
        var categories = DataGenerator.GenerateCategories(count);
        await _context.Categories.AddRangeAsync(categories);

        await _context.SaveChangesAsync();
    }

    public async Task AddCategories()
    {
        var category = DataGenerator.GenerateCategories(1).FirstOrDefault();
        _context.Categories.Add(category);

        await _context.SaveChangesAsync();
    }

    public async Task UpdateCategories()
    {
        var categories = _context.Categories;
        foreach (var category in categories)
        {
            category.Name = $"{category.Name} - updated";
        }

        _context.Categories.UpdateRange(categories);

        await _context.SaveChangesAsync();
    }

    public async Task ExcuteUpdateCategories()
    {
        var categories = _context.Categories;
        foreach (var category in categories)
        {
            category.Name = $"{category.Name} - Excute";
        }

        _context.Categories.UpdateRange(categories);

        await _context.SaveChangesAsync();
    }
}
