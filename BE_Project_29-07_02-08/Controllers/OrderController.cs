using BE_Project_29_07_02_08.Context;
using BE_Project_29_07_02_08.Services.Orders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BE_Project_29_07_02_08.Controllers
{

    //todo: authorize /policy
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
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrders();
            return View(orders);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IsProcessed(int idOrder)
        {
            await _orderService.IsProcessed(idOrder);
            return RedirectToAction("GetAllOrders");
        }

        [HttpGet]
        public async Task<IActionResult> GetProcessedOrdersCount()
        {
            var processedOrdersCount = await _dataContext.Orders.CountAsync(o => o.IsProcessed == true);

            return Ok(processedOrdersCount);
        }

        [HttpGet]
        public async Task<IActionResult> GetTotalIncome()
        {
            var totalIncome = await _dataContext.Orders
                .Where(o => o.IsProcessed == true) //remove if you want to get total income of all orders (not only processed)
                .SumAsync(o => o.TotalAmount);
            return Ok(totalIncome);
        }
    }
}

