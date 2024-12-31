using Confluent.Kafka;
using SharedModels.Models;
using System.Text.Json;

namespace InventoryService.Services
{
    public class InventoryConsumerService
    {
        private readonly ConsumerConfig _config;

        public InventoryConsumerService()
        {
            _config = new ConsumerConfig
            {
                GroupId = "inventory-service",
                BootstrapServers = "localhost:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
        }

        public void StartConsuming()
        {
            using var consumer = new ConsumerBuilder<Null, string>(_config).Build();
            consumer.Subscribe("order-events");

            Console.WriteLine("Inventory Service is running...");
            while (true)
            {
                var result = consumer.Consume();
                var order = JsonSerializer.Deserialize<Order>(result.Message.Value);
                Console.WriteLine($"Order received: {order?.OrderId} and updating Inventory");
            }
        }
    }
}
