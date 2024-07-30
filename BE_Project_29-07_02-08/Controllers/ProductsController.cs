using BE_Project_29_07_02_08.Models;
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
        public IActionResult CreateProducts()
        {
            return View();
        }

        [HttpPost("Products/Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProducts(Product product)
        {
            if (ModelState.IsValid)
            {
                await _productService.CreateProductAsync(product);
                return RedirectToAction("ProductsList");
            }
            return View(product);
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
