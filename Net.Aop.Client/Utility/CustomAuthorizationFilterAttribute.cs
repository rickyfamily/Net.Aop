using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Net.Aop.Client.Utility
{
    public class CustomAuthorizationFilterAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            Console.WriteLine($"CustomAuthorizationFilterAttribute OnAuthorization");
            string id = context.HttpContext.Request.Query["id"].ToString();
            if (!string.IsNullOrEmpty(id) && id != "10")
            {
                ViewResult result = new ViewResult { ViewName = "~/Views/Shared/Error.cshtml" };
                context.Result = result;
            }      
        }
    }
}
