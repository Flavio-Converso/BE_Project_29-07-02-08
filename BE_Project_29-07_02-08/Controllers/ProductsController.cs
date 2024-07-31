using BE_Project_29_07_02_08.Models;
using BE_Project_29_07_02_08.Models.ViewModels;
using BE_Project_29_07_02_08.Services.Products;
using Microsoft.AspNetCore.Mvc;

namespace BE_Project_29_07_02_08.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("Products/CreateProducts")]
        public async Task<IActionResult> CreateProducts()
        {
            var ingredients = await _productService.GetAllIngredientsAsync();
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

        [HttpPost("Products/CreateProducts")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProducts(ProductCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var product = await _productService.CreateProductwIngredientsAsync(viewModel);
                return RedirectToAction("ProductsList");
            }
            return View(viewModel);
        }

        [HttpGet("Products/ProductsList")]
        public async Task<IActionResult> ProductsList()
        {
            var products = await _productService.GetAllProductswIngredientsAsync();
            return View(products);
        }
    }
}
