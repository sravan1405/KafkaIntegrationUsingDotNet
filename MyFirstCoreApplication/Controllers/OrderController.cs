using Microsoft.AspNetCore.Mvc;
using MyFirstCoreApplication.Kafka;
using SharedModels.Models;

namespace MyFirstCoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private KafkaProducerService _producerService;

        public OrderController(KafkaProducerService producerService)
        {
            _producerService = producerService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] Order order)
        {
            if (order == null) { return BadRequest("Invalid Order"); }

            await _producerService.ProduceMessage(order);
            return Ok(new { message = "Order placed successfully!" });
        }
    }
}
