using Database.Helper;
using Database.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Database.Service;

public class InventoryService : IInventoryService
{
    private readonly ProductDbContext _context;

    public InventoryService(ProductDbContext context)
    {
        _context = context;
    }

    public async Task SeedInventories(int count)
    {
        var inventories = DataGenerator.GenerateInventories(count, [.. _context.Products]);
        await _context.Inventories.AddRangeAsync(inventories);

        await _context.SaveChangesAsync();
    }
}
