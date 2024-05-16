using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Net.Aop.Client.Utility
{
    public class CustomResultFilterAttribute : Attribute, IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            Console.WriteLine("CustomResultFilterAttribute OnResultExecuting");
            if (context.Result is JsonResult)
            {
                JsonResult result = (JsonResult)context.Result;
                context.Result = new JsonResult(new
                {
                    Data = result.Value,
                    Success = true
                });
            }
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine("CustomResultFilterAttribute OnResultExecuted");
        }
    }
}

