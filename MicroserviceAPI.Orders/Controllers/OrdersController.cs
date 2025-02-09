using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace MicroserviceAPI.Orders.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {

        private readonly ILogger<OrdersController> _logger;
        private readonly HttpClient _httpClient;
        private readonly string _productsApiUrl;

        public OrdersController(ILogger<OrdersController> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
            _productsApiUrl = Environment.GetEnvironmentVariable("PRODUCTS_API_URL") ?? "http://products-api";
        }

        [HttpGet]
        public async Task <Order> Get()
        {
            var response = await _httpClient.GetAsync($"{_productsApiUrl}/products");

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var product = JsonSerializer.Deserialize<ProductDTO>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new ProductDTO("Unknown Product", 0);

            return new Order(product.Title, product.Price);

        }
    }

    public record ProductDTO(string Title, decimal Price);
}
