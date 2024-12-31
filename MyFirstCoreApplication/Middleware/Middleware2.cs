using MyFirstCoreApplication.Kafka;

namespace MyFirstCoreApplication.Middleware
{
    public class Middleware2
    {
        private readonly RequestDelegate _next;
        //private readonly KafkaProducerService _service1;

        public Middleware2(RequestDelegate next)
        {
            _next = next;
            //_service1 = service1;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                //authen
                if (context.Request.Headers["isAdmin"] == "true")
                {
                    //_service1.ProduceMessage(new SharedModels.Models.Order());
                    // Pass the request to the next middleware in the pipeline
                    await _next(context);
                }
                else
                {
                    return;
                }
                // Log the response details
                Console.WriteLine($"Response: {context.Response.StatusCode}");
            }
            catch (Exception ex)
            {

            }
        }
    }
}
