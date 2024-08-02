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
        public async Task<CreateProductViewModel> GetCreateProductViewModelAsync()
        {
            var ingredients = await _dataContext.Ingredients.ToListAsync();
            var viewModel = new CreateProductViewModel
            {
                Product = new Product
                {
                    Name = "",
                    Price = 0.0m,
                    DeliveryTimeMin = 0
                },
                Ingredients = ingredients
            };

            return viewModel;
        }
        public async Task<Product> CreateProductwIngredientsAsync(CreateProductViewModel viewModel)
        {
            var product = viewModel.Product;

            if (viewModel.Image != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await viewModel.Image.CopyToAsync(memoryStream);
                    product.Image = memoryStream.ToArray();
                }
            }

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

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            var productById = await _dataContext.Products.FirstOrDefaultAsync(p => p.IdProduct == productId);
            return productById;
        }

        public async Task DeleteProductAsync(int productId)
        {
            var product = await _dataContext.Products.FirstOrDefaultAsync(p => p.IdProduct == productId);
            if (product != null)
            {
                _dataContext.Products.Remove(product);
                await _dataContext.SaveChangesAsync();
                return;
            }
        }
    }
}
