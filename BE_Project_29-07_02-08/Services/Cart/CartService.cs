using BE_Project_29_07_02_08.Context;
using BE_Project_29_07_02_08.Models;
using BE_Project_29_07_02_08.Models.ViewModels;
using BE_Project_29_07_02_08.Services.Products;
using Microsoft.EntityFrameworkCore;

namespace BE_Project_29_07_02_08.Services.Carts
{
    //todo salva cart localstorage / session
    public class CartService : ICartService
    {
        private readonly IProductService _productService;
        private readonly DataContext _dataContext;

        private static List<CartItem> _temporaryCart = new List<CartItem>();

        public CartService(IProductService productService, DataContext dataContext)
        {
            _productService = productService;
            _dataContext = dataContext;
        }

        public async Task AddToCartAsync(int productId, int quantity)
        {
            var product = await _productService.GetProductByIdAsync(productId);
            if (product != null)
            {
                var existingCartItem = _temporaryCart.FirstOrDefault(c => c.ProductId == productId);
                if (existingCartItem != null)
                {
                    existingCartItem.Quantity += quantity;
                }
                else
                {
                    var newCartItem = new CartItem
                    {
                        ProductId = product.IdProduct,
                        ProductName = product.Name,
                        Price = product.Price,
                        Quantity = quantity
                    };
                    _temporaryCart.Add(newCartItem);
                }
            }
        }

        public Task<List<CartItem>> GetCartItemsAsync()
        {
            return Task.FromResult(_temporaryCart);
        }

        public Task RemoveFromCartAsync(int productId)
        {
            var itemToRemove = _temporaryCart.FirstOrDefault(c => c.ProductId == productId);
            if (itemToRemove != null)
            {
                _temporaryCart.Remove(itemToRemove);
            }
            return Task.CompletedTask;
        }

        public Task<decimal> GetTotalAmountAsync()
        {
            var totalAmount = _temporaryCart.Sum(c => c.Price * c.Quantity);
            return Task.FromResult(totalAmount);
        }

        public Task<List<CartItem>> ClearCartAsync()
        {
            _temporaryCart.Clear();
            return Task.FromResult(_temporaryCart);
        }

        public async Task CreateOrderAsync(Order o)
        {
            var cartItems = await GetCartItemsAsync();

            var order = new Order
            {
                Address = o.Address,
                AdditionalNotes = o.AdditionalNotes,
                IsProcessed = false,
                OrderDate = DateTime.Now,
                TotalAmount = await GetTotalAmountAsync(),
                IdUser = o.IdUser,
            };

            _dataContext.Orders.Add(order);
            await _dataContext.SaveChangesAsync();

            foreach (var cartItem in cartItems)
            {
                var orderedProduct = new OrderedProduct
                {
                    IdOrder = order.IdOrder,
                    IdProduct = cartItem.ProductId,
                    Quantity = cartItem.Quantity
                };

                _dataContext.OrderedProducts.Add(orderedProduct);
            }

            await _dataContext.SaveChangesAsync();

            await ClearCartAsync();
        }

        public async Task<(List<CartItem> CartItems, decimal TotalAmount)> GetOrderSummaryAsync()
        {
            var cartItems = await GetCartItemsAsync();
            var totalAmount = await GetTotalAmountAsync();
            return (cartItems, totalAmount);
        }

        public async Task<bool> ProcessCheckoutAsync(string userName, string address, string additionalNotes)
        {
            try
            {
                var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.Username == userName);
                if (user == null)
                {
                    return false;
                }

                var order = new Order
                {
                    Address = address,
                    AdditionalNotes = additionalNotes,
                    IdUser = user.IdUser
                };

                await CreateOrderAsync(order);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
