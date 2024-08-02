using BE_Project_29_07_02_08.Context;
using BE_Project_29_07_02_08.Services.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BE_Project_29_07_02_08.Controllers
{

    [Authorize(Policy = "AdminPolicy")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly DataContext _dataContext;
        public OrderController(IOrderService orderService, DataContext dataContext)
        {
            _orderService = orderService;
            _dataContext = dataContext;
        }
        [HttpGet]
        public async Task<IActionResult> ManageOrders()
        {
            var orders = await _orderService.GetAllOrders();
            return View(orders);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IsProcessed(int idOrder)
        {
            await _orderService.IsProcessed(idOrder);
            return RedirectToAction("ManageOrders");
        }

        [HttpGet]
        public async Task<IActionResult> GetProcessedOrdersCount()
        {
            var processedOrdersCount = await _dataContext.Orders.CountAsync(o => o.IsProcessed == true);

            return Ok(processedOrdersCount);
        }

        [HttpGet]
        public async Task<IActionResult> GetTotalIncome(DateTime date)
        {
            var totalIncome = await _dataContext.Orders
                .Where(
                o => o.IsProcessed == true  //remove if you want to get total income of all orders
                && o.OrderDate.Date == date.Date
                    )
                .SumAsync(o => o.TotalAmount);

            return Ok(totalIncome);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteOrder(int idOrder)
        {
            await _orderService.DeleteOrderAsync(idOrder);
            return RedirectToAction("ProductsList", "Products");
        }
    }
}

