using BE_Project_29_07_02_08.Context;
using BE_Project_29_07_02_08.Models;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace BE_Project_29_07_02_08.Services.Orders
{

    public class OrderService : IOrderService
    {
        private readonly DataContext _dataContext;

        public OrderService(DataContext context)
        {
            _dataContext = context;
        }



        public async Task<List<Order>> GetAllOrders()
        {
            var orders = await _dataContext.Orders.ToListAsync();
            return orders;
        }

        public async Task<Order> IsProcessed(int idOrder)
        {
            var order = _dataContext.Orders.FirstOrDefault(o => o.IdOrder == idOrder);
            if (order.IsProcessed == false)
            {
                order.IsProcessed = true;
                await _dataContext.SaveChangesAsync();
            }
            else
            {
                order.IsProcessed = false;
                await _dataContext.SaveChangesAsync();
            }

            return order;
        }
        public async Task DeleteOrderAsync(int idOrder)
        {
            var order = await _dataContext.Orders.FirstOrDefaultAsync(o => o.IdOrder == idOrder);
            if (order != null)
            {
                _dataContext.Orders.Remove(order);
                await _dataContext.SaveChangesAsync();
                return;
            }
        }
    }
}
