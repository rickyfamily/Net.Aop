using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Net.Aop.Client.Utility
{
    public class CustomerAsyncResultFilterAttribute : Attribute, IAsyncResultFilter
    {
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            Console.WriteLine("CustomerAsyncResultFilterAttribute OnResultExecutionAsync");
            if (context.Result is JsonResult)
            {
                JsonResult result = (JsonResult)context.Result;
                context.Result = new JsonResult(new
                {
                    Data = result.Value,
                    Success = true
                });
            }
            await next.Invoke();
        }
    }
}

