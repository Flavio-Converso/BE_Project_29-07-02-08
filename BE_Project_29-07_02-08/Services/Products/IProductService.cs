using BE_Project_29_07_02_08.Models;
using BE_Project_29_07_02_08.Models.ViewModels;

namespace BE_Project_29_07_02_08.Services.Products
{
    public interface IProductService
    {
        Task<List<Ingredient>> GetAllIngredientsAsync();
        Task<Product> CreateProductwIngredientsAsync(CreateProductViewModel viewModel);
        Task<List<Product>> GetAllProductswIngredientsAsync();
        Task<Product> GetProductByIdAsync(int IdProduct);
        Task<CreateProductViewModel> GetCreateProductViewModelAsync();
        Task DeleteProductAsync(int IdProduct);
    }
}
