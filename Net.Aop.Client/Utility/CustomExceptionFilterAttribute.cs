using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Net.Aop.Client.Utility
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            Console.WriteLine($"The exception is tracted in {nameof(CustomExceptionFilterAttribute)}");
            if (!context.ExceptionHandled)
            {
                ViewResult result = new ViewResult { ViewName = "~/Views/Shared/Error.cshtml" };
                context.Result = result;
                context.ExceptionHandled = true;
            }
        }
    }
}
