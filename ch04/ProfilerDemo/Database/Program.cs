using Database.Infrastructure;
using Database.Model;
using Database.Service;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
    .EnableSensitiveDataLogging());

builder.Services.AddScoped<ICategorieService, CategorieService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IInventoryService, InventoryService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/seed-categories", async (ICategorieService service) =>
{
    await service.SeedCategories(20);
    return Results.Ok("Catories seeded successfully");
})
.WithName("seed-categories")
.WithOpenApi();

app.MapPost("/seed-products", (IProductService service) =>
{
    service.SeedProduts(200);
    return Results.Ok("Products seeded successfully");
})
.WithName("seed-products")
.WithOpenApi();

app.MapPost("/seed-inventories", async (IInventoryService service) =>
{
    await service.SeedInventories(50);
    return Results.Ok("Inventories seeded successfully");
})
.WithName("seed-inventories")
.WithOpenApi();

app.MapPost("/add-categories", async (ICategorieService service) =>
{
    await service.SeedCategories(20);
    return Results.Ok("Catories added successfully");
})
.WithName("add-categories")
.WithOpenApi();

app.MapPost("/update-categories", async (ICategorieService service) =>
{
    await service.UpdateCategories();
    return Results.Ok("Products updated successfully");
})
.WithName("update-categories")
.WithOpenApi();

app.MapPost("/update-categories-bulk", async (ICategorieService service) =>
{
    await service.UpdateCategories();
    return Results.Ok("Products updated successfully");
})
.WithName("update-categories-bulk")
.WithOpenApi();

app.MapGet("/get-products-by-random-category", (IProductService service) =>
   {
       List<Product> products = service.GetProducts();
       products = service.GetProductsADO();
       return Results.Ok(service.GetProducts());
    }
);


app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
