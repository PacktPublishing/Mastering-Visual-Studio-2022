using Microsoft.EntityFrameworkCore;

namespace Sandbox.Market;

public class StockContext : DbContext
{
    public StockContext(DbContextOptions<StockContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }
}
