
namespace Database.Service;

public interface ICategorieService
{
    Task AddCategories();
    Task ExcuteUpdateCategories();
    Task SeedCategories(int count);
    Task UpdateCategories();
}