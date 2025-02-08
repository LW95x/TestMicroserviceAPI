using Microsoft.AspNetCore.Mvc;

namespace MicroserviceAPI.Orders.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {

        private readonly ILogger<OrdersController> _logger;

        public OrdersController(ILogger<OrdersController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task <Order> Get()
        {
            return new Order("Order #1", 10);

        }
    }
}
