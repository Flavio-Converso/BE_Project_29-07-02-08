using BE_Project_29_07_02_08.Services.Carts;
using Microsoft.AspNetCore.Mvc;

namespace BE_Project_29_07_02_08.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart(int productId, int quantity)
        {
            await _cartService.AddToCartAsync(productId, quantity);
            return RedirectToAction("ProductsList", "Products");
        }

        [HttpGet]
        public async Task<IActionResult> ViewCart()
        {
            var cartItems = await _cartService.GetCartItemsAsync();
            var totalAmount = await _cartService.GetTotalAmountAsync();
            ViewBag.TotalAmount = totalAmount;
            return View(cartItems);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveFromCart(int productId)
        {
            await _cartService.RemoveFromCartAsync(productId);
            return RedirectToAction("ViewCart");
        }
    }
}
