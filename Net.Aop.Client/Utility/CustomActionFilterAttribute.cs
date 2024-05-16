using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace Net.Aop.Client.Utility
{
    public class CustomActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"CustomActionFilterAttribute OnActionExecuting");
            string url = context.HttpContext.Request.Path.Value;            
            string controllerName = context.Controller.GetType().FullName;
            string actionName = context.ActionDescriptor.DisplayName;
            string actionArguments = JsonConvert.SerializeObject(context.ActionArguments);            
            Console.WriteLine($"url={url}---controllerName={controllerName}---actionName={actionName}---actionArguments={actionArguments}");
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"CustomActionFilterAttribute OnActionExecuted");
        }
    }
}
