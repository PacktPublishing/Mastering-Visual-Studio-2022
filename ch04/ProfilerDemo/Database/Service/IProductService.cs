
using Database.Model;

namespace Database.Service;

public interface IProductService
{
    List<Product> GetProductsADO();
    List<Product> GetProducts();
    void SeedProduts(int count);
}