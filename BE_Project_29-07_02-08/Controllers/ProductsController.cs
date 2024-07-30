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
        public IActionResult CreateProducts(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.CreateProduct(product);
                return RedirectToAction("ProductsList");
            }
            return View(product);
        }

        [HttpGet("Products/GetProductsJson")]
        public ActionResult<List<Product>> GetProductsJson()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("Products/ProductsList")]
        public IActionResult ProductsList()
        {
            return View();
        }
    }
}
