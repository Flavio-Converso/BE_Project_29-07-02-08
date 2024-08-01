using BE_Project_29_07_02_08.Context;
using BE_Project_29_07_02_08.Models;
using BE_Project_29_07_02_08.Services.Carts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BE_Project_29_07_02_08.Controllers
{
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

        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            var cartItems = await _cartService.GetCartItemsAsync();
            var totalAmount = await _cartService.GetTotalAmountAsync();
            ViewBag.TotalAmount = totalAmount;
            return View(cartItems);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout(string address, string additionalNotes)
        {
            var userName = User.Identity.Name;
            var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.Username == userName);
            try
            {
                var order = new Order
                {
                    Address = address,
                    AdditionalNotes = additionalNotes,
                    IdUser = user.IdUser
                };

                await _cartService.CreateOrderAsync(order);

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                return View(await _cartService.GetCartItemsAsync());
            }
        }
    }
}

