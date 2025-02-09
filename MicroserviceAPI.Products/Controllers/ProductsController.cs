using Microsoft.AspNetCore.Mvc;

namespace MicroserviceAPI.Products.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {

        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task <Product> GetProduct()
        {
            return new Product("TEST Deckchair", 10);
        }
    }
}
