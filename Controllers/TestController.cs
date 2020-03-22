using KafkaDemo.Helpers;
using KafkaDemo.Inputs;
using Microsoft.AspNetCore.Mvc;

namespace KafkaDemo.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IKafkaProducer<Input> _producer;

        public TestController(IKafkaProducer<Input> producer)
        {
            _producer = producer;
        }

        [HttpPost]
        public string SendMessage([FromBody] Input input)
        {
            return _producer.SendMessage(input)
                ? "Send message to QUEUE successfully!!"
                : "Send message to QUEUE failed. Please try again!!";
        }
    }
}