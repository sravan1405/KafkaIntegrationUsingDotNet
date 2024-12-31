using NotificationService.Services;

namespace NotificationService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var notificationServiceConsumer = new NotificationConsumerService();
            notificationServiceConsumer.StartConsuming();
        }
    }
}
