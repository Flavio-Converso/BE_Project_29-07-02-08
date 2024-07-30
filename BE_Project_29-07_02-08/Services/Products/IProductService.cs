using BE_Project_29_07_02_08.Models;

namespace BE_Project_29_07_02_08.Services.Products
{
    public interface IProductService
    {
        Task<Product> CreateProductAsync(Product product);
        Task<List<Product>> GetAllProductsAsync();
    }
}
