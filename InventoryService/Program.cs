using InventoryService.Services;

namespace InventoryService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var inventoryConsumerService = new InventoryConsumerService();
            inventoryConsumerService.StartConsuming();
        }
    }
}
