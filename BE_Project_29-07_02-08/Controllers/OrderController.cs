using BE_Project_29_07_02_08.Services.Orders;
using Microsoft.AspNetCore.Mvc;

namespace BE_Project_29_07_02_08.Controllers
{

    //todo: authorize /policy
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
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
    }
}
