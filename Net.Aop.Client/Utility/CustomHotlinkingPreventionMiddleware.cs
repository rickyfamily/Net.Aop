namespace Net.Aop.Client.Utility
{
    public class CustomHotlinkingPreventionMiddleware
    {
        private readonly RequestDelegate next;

        public CustomHotlinkingPreventionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            string url = context.Request.Path.Value;
            if (!url.Contains(".png"))
            {
                await next(context);
                return;
            }
            string urlReferrer = context.Request.Headers["Referer"];
            if (string.IsNullOrWhiteSpace(urlReferrer))
            {
                await this.SetErrorImage(context);
            }
            else if (!urlReferrer.Contains("localhost"))
            {
                await this.SetErrorImage(context);
            }
            else
            {
                await next(context);
            }
        }

        private async Task SetErrorImage(HttpContext context)
        {
            string defaultImagePath = "wwwroot/img/error.png";
            string path = Path.Combine(Directory.GetCurrentDirectory(), defaultImagePath);
            FileStream fs = File.OpenRead(path);
            byte[] bytes = new byte[fs.Length];
            await fs.ReadAsync(bytes, 0, bytes.Length);
            await context.Response.Body.WriteAsync(bytes, 0, bytes.Length);
        }
    }
}
