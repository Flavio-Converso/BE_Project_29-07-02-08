using BE_Project_29_07_02_08.Models.ViewModels;
using BE_Project_29_07_02_08.Services.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BE_Project_29_07_02_08.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("Products/CreateProducts")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> CreateProducts()
        {
            var viewModel = await _productService.GetCreateProductViewModelAsync();
            return View(viewModel);
        }


        [HttpPost("Products/CreateProducts")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> CreateProducts(CreateProductViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                var product = await _productService.CreateProductwIngredientsAsync(viewModel);
                return RedirectToAction("ProductsList");
            }
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            await _productService.DeleteProductAsync(productId);
            return RedirectToAction("ProductsList");
        }


        [HttpGet("Products/ProductsList")]
        public async Task<IActionResult> ProductsList()
        {
            var products = await _productService.GetAllProductswIngredientsAsync();
            return View(products);
        }
    }
}