using BE_Project_29_07_02_08.Context;
using BE_Project_29_07_02_08.Models;

namespace BE_Project_29_07_02_08.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly DataContext _dataContext;

        public ProductService(DataContext context)
        {
            _dataContext = context;
        }

        public Product CreateProduct(Product product)
        {
            _dataContext.Products.Add(product);
            _dataContext.SaveChanges();
            return product;
        }

        public List<Product> GetAllProducts()
        {
            return _dataContext.Products.ToList();
        }
    }
}
