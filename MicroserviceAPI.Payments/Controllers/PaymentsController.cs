using Microsoft.AspNetCore.Mvc;

namespace MicroserviceAPI.Payments.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentsController : ControllerBase
    {

        private readonly ILogger<PaymentsController> _logger;

        public PaymentsController(ILogger<PaymentsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task <Payment> Get()
        {
            return new Payment("Liam", "UK", "TEST Barclays");
        }
    }
}
