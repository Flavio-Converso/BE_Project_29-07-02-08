using BE_Project_29_07_02_08.Models;

namespace BE_Project_29_07_02_08.Services.Products
{
    public interface IProductService
    {
        Product CreateProduct(Product product);
        public List<Product> GetAllProducts();
    }
}
