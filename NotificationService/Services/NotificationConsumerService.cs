using Confluent.Kafka;
using SharedModels.Models;
using System.Text.Json;

namespace NotificationService.Services
{
    public class NotificationConsumerService
    {
        private readonly ConsumerConfig _config;

        public NotificationConsumerService()
        {
            _config = new ConsumerConfig
            {
                GroupId = "notification-service",
                BootstrapServers = "localhost:9092",
                AutoOffsetReset = AutoOffsetReset.Latest
            };
        }

        public void StartConsuming()
        {
            using var consumer = new ConsumerBuilder<Null, string>(_config).Build();
            consumer.Subscribe("order-events");

            Console.WriteLine("Notification Service is running...");
            while (true)
            {
                var result = consumer.Consume();
                var order = JsonSerializer.Deserialize<Order>(result.Message.Value);
                Console.WriteLine($"Order received: {order?.OrderId}, sending confirmation");
            }
        }
    }
}
