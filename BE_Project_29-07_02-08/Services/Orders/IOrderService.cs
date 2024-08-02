using BE_Project_29_07_02_08.Models;

namespace BE_Project_29_07_02_08.Services.Orders
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllOrders();
        Task<Order> IsProcessed(int idOrder);
        Task DeleteOrderAsync(int idOrder);
    }
}
