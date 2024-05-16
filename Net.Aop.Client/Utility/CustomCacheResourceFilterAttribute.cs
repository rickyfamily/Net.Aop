using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Net.Aop.Client.Utility
{
    public class CustomCacheResourceFilterAttribute : Attribute, IResourceFilter
    {
        private static Dictionary<string, object> _CacheDictionary = new Dictionary<string, object>(); 

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine($"CustomCacheResourceFilterAttribute OnResourceExecuted");
            string key = context.HttpContext.Request.Path;
            _CacheDictionary[key] = context.Result; 
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine($"CustomCacheResourceFilterAttribute OnResourceExecuting");
            string key = context.HttpContext.Request.Path;
            if (_CacheDictionary.ContainsKey(key))
            {
                context.Result = _CacheDictionary[key] as IActionResult;
            }
        }
    }
}
