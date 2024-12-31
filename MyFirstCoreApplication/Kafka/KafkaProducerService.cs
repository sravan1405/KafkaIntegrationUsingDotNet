using Confluent.Kafka;
using MyFirstCoreApplication.Models;
using SharedModels.Models;
using System.Text.Json;

namespace MyFirstCoreApplication.Kafka
{
    public class KafkaProducerService
    {
        private readonly ProducerConfig _config;

        public KafkaProducerService()
        {
            _config = new ProducerConfig { BootstrapServers = "localhost:9092" };
        }

        public async Task ProduceMessage(Order order)
        {
            using var produce = new ProducerBuilder<Null,string>(_config).Build();
            var message = JsonSerializer.Serialize(order);
            await produce.ProduceAsync("order-events", new Message<Null, string>() { Value = message });
        }
    }
}
