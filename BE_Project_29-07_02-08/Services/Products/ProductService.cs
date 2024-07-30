using BE_Project_29_07_02_08.Context;
using BE_Project_29_07_02_08.Models;
using Microsoft.EntityFrameworkCore;


namespace BE_Project_29_07_02_08.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly DataContext _dataContext;

        public ProductService(DataContext context)
        {
            _dataContext = context;
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            await _dataContext.Products.AddAsync(product);
            await _dataContext.SaveChangesAsync();
            return product;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _dataContext.Products
        .Include(p => p.Ingredients) // Include the related ingredients
        .ToListAsync();
        }
    }
}
