using BE_Project_29_07_02_08.Context;
using BE_Project_29_07_02_08.Models;
using BE_Project_29_07_02_08.Models.ViewModels;
using BE_Project_29_07_02_08.Services.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace BE_Project_29_07_02_08.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly DataContext _dataContext;

        public ProductsController(IProductService productService, DataContext dataContext)
        {
            _productService = productService;
            _dataContext = dataContext;
        }
        //todo: move to service
        //todo: handle img
        [HttpGet("Products/CreateProducts")]
        public async Task<IActionResult> CreateProducts()
        {
            var ingredients = await _productService.GetAllIngredientsAsync(); // Fetch ingredients
            var viewModel = new ProductCreateViewModel
            {
                Product = new Product
                {
                    Name = "",
                    Price = 0.0m,
                    DeliveryTimeMin = 0
                },
                Ingredients = ingredients
            };
            return View(viewModel);
        }
        //todo: move to service
        //todo: handle img
        [HttpPost("Products/CreateProducts")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProducts(ProductCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var product = viewModel.Product;
                var selectedIngredients = await _dataContext.Ingredients
                    .Where(i => viewModel.SelectedIngredientIds.Contains(i.IdIngredient))
                    .ToListAsync();

                product.Ingredients = selectedIngredients;

                await _productService.CreateProductAsync(product);
                return RedirectToAction("ProductsList");
            }

            var ingredients = await _productService.GetAllIngredientsAsync();
            viewModel.Ingredients = ingredients;
            return View(viewModel);
        }


        [HttpGet("Products/GetProductsJson")]
        public async Task<ActionResult<List<Product>>> GetProductsJson()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("Products/ProductsList")]
        public IActionResult ProductsList()
        {
            return View();
        }
    }
}
