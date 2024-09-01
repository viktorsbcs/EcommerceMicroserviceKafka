using Ecommerce.Model;
using Ecommerce.OrderService.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderDbContext _orderDbContext;

        public OrdersController(OrderDbContext orderDbContext)
        {
            _orderDbContext = orderDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await (
                from order in _orderDbContext.Orders
                join orderProduct in _orderDbContext.OrderProducts
                on order.Id equals orderProduct.OrderId
                into ordersProducts
                select new Order()
                {
                    Id = order.Id,
                    CustomerEmail = order.CustomerEmail,
                    OrderDate = order.OrderDate,
                    OrderProducts = ordersProducts.ToList()
                }).ToListAsync();

            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(Guid id)
        {
            //var order = await _orderDbContext.Orders.FirstOrDefaultAsync(o => o.Id == id);

            var foundOrder = await (
                from order in _orderDbContext.Orders
                where order.Id == id
                join orderProduct in _orderDbContext.OrderProducts
                on order.Id equals orderProduct.OrderId
                into ordersProducts
                select new Order()
                {
                    Id = order.Id,
                    CustomerEmail = order.CustomerEmail,
                    OrderDate = order.OrderDate,
                    OrderProducts = ordersProducts.ToList()
                }).ToListAsync();

            return Ok(foundOrder);
        }
    }
}
