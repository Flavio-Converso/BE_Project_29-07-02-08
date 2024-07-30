using BE_Project_29_07_02_08.Context;
using BE_Project_29_07_02_08.Models;
using BE_Project_29_07_02_08.Models.ViewModels;
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

        public async Task<List<Ingredient>> GetAllIngredientsAsync()
        {
            return await _dataContext.Ingredients.ToListAsync();
        }

        public async Task<Product> CreateProductAsync(ProductCreateViewModel viewModel)
        {
            var product = viewModel.Product;

            product.Ingredients = await _dataContext.Ingredients
                .Where(i => viewModel.SelectedIngredientIds.Contains(i.IdIngredient))
                .ToListAsync();

            await _dataContext.Products.AddAsync(product);
            await _dataContext.SaveChangesAsync();

            return product;
        }

        public async Task<List<Product>> GetAllProductswIngredientsAsync()
        {
            return await _dataContext.Products
                .Include(p => p.Ingredients)
                .ToListAsync();
        }
    }
}
