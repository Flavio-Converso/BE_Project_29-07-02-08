using BE_Project_29_07_02_08.Context;
using BE_Project_29_07_02_08.Services.Carts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BE_Project_29_07_02_08.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly DataContext _dataContext;

        public CartController(ICartService cartService, DataContext dataContext)
        {
            _cartService = cartService;
            _dataContext = dataContext;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart(int productId, int quantity)
        {
            await _cartService.AddToCartAsync(productId, quantity);
            return RedirectToAction("ProductsList", "Products");
        }

        [HttpGet]
        public async Task<IActionResult> RiepilogoOrdine()
        {
            var (cartItems, totalAmount) = await _cartService.GetOrderSummaryAsync();
            ViewBag.TotalAmount = totalAmount;
            return View(cartItems);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveFromCart(int productId)
        {
            await _cartService.RemoveFromCartAsync(productId);
            return RedirectToAction("RiepilogoOrdine");
        }

        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            var (cartItems, totalAmount) = await _cartService.GetOrderSummaryAsync();
            ViewBag.TotalAmount = totalAmount;
            return View(cartItems);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout(string address, string additionalNotes)
        {
            var userName = User.Identity!.Name;
            var isCheckoutSuccessful = await _cartService.ProcessCheckoutAsync(userName, address, additionalNotes);

            if (isCheckoutSuccessful)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(await _cartService.GetCartItemsAsync());
            }
        }
    }
}
