using BE_Project_29_07_02_08.Models;
using BE_Project_29_07_02_08.Services.Products;
using Microsoft.AspNetCore.Mvc;

namespace BE_Project_29_07_02_08.Controllers
{
    [ApiController]
    [Route("Products")]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.CreateProduct(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [HttpGet("api/products")]
        public ActionResult<List<Product>> GetProductsJson()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("list")]
        public IActionResult ListProducts()
        {
            var products = _productService.GetAllProducts();
            return View(products);
        }
    }
}
