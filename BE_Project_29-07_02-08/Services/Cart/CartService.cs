using BE_Project_29_07_02_08.Models.ViewModels;
using BE_Project_29_07_02_08.Services.Products;

namespace BE_Project_29_07_02_08.Services.Carts
{
    public class CartService : ICartService
    {
        private readonly IProductService _productService;
        private static List<CartItem> _temporaryCart = new List<CartItem>();

        public CartService(IProductService productService)
        {
            _productService = productService;
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
                        Quantity = quantity,
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
    }
}
