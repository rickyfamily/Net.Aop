using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace Net.Aop.Client.Utility
{
    public class CustomActionWithParamFilterAttribute : Attribute, IActionFilter
    {
        private readonly ILogger<CustomActionWithParamFilterAttribute> _logger;
        public CustomActionWithParamFilterAttribute(ILogger<CustomActionWithParamFilterAttribute> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"CustomActionWithParamFilterAttribute OnActionExecuted");
            _logger.LogInformation(JsonConvert.SerializeObject(context.Result));
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"CustomActionWithParamFilterAttribute OnActionExecuting");
            _logger.LogInformation(JsonConvert.SerializeObject(context.HttpContext.Request.QueryString));
        }
    }
}
