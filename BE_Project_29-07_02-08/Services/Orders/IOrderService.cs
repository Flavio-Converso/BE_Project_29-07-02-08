using BE_Project_29_07_02_08.Models;

namespace BE_Project_29_07_02_08.Services.Orders
{
    public interface IOrderService
    {
        public List<Order> GetAllOrders();
        Order CreateOrder(Order order);
    }
}
