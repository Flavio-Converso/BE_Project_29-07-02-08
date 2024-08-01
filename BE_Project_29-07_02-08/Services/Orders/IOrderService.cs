using BE_Project_29_07_02_08.Models;

namespace BE_Project_29_07_02_08.Services.Orders
{
    public interface IOrderService
    {
        public Task<List<Order>> GetAllOrders();
        public Task<Order> IsProcessed(int idOrder);
    }
}
