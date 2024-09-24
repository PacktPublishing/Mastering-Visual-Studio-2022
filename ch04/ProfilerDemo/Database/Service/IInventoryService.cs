
namespace Database.Service;

public interface IInventoryService
{
    Task SeedInventories(int count);
}