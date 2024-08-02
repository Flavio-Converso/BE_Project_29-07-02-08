using BE_Project_29_07_02_08.Models;
using BE_Project_29_07_02_08.Models.ViewModels;

namespace BE_Project_29_07_02_08.Services.Carts
{
    public interface ICartService
    {
        Task AddToCartAsync(int productId, int quantity);

        Task<List<CartItem>> GetCartItemsAsync();

        Task RemoveFromCartAsync(int productId);

        Task<decimal> GetTotalAmountAsync();

        Task<List<CartItem>> ClearCartAsync();

        Task CreateOrderAsync(Order order);

        Task<(List<CartItem> CartItems, decimal TotalAmount)> GetOrderSummaryAsync();

        Task<bool> ProcessCheckoutAsync(string userName, string address, string additionalNotes);
    }
}
