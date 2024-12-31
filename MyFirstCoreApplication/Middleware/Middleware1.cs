using MyFirstCoreApplication.Kafka;

namespace MyFirstCoreApplication.Middleware
{
    public class Middleware1
    {
        private readonly RequestDelegate _next;
        //private readonly KafkaProducerService _service1;

        public Middleware1(RequestDelegate next)
        {
            _next = next;
            //_service1 = service1;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // Log the request details
                Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");
                Console.WriteLine($"Request Data: {context.Request.Body}");
                List<string> messages = new List<string>{ "PUT", "POST", "DELETE" };
                //authen
                if (context.Request.Headers["role"] == "clerk")
                {
                    if (messages.Contains(context.Request.Method))
                    {
                        return;
                    }
                }

                //_service1.ProduceMessage(new SharedModels.Models.Order());
                // Pass the request to the next middleware in the pipeline
                await _next(context);

                // Log the response details
                Console.WriteLine($"Response: {context.Response.StatusCode}");
            }
            catch (Exception ex)
            {

            }
        }
    }
}
