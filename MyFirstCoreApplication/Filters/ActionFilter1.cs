using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace MyFirstCoreApplication.Filters
{
    public class ActionFilter1: IActionFilter
    {
        private Stopwatch _stopwatch;
        public void OnActionExecuting(ActionExecutingContext context)
        {
            {
                List<string> messages = new List<string> { "PUT", "POST", "DELETE" };
                if (messages.Contains(context.HttpContext.Request.Method))
                {
                    return;
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _stopwatch.Stop();
            Console.WriteLine($"Action {context.ActionDescriptor.DisplayName} executed in {_stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
