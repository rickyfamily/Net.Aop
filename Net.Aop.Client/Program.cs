using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using Net.Aop.AutofacAop;
using Net.Aop.Client.Utility;
using Net.Aop.Service;
using Net.Aop.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<CustomExceptionFilterAttribute>();
}).AddRazorRuntimeCompilation();

builder.Services.AddTransient<CustomActionWithParamFilterAttribute>();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterType<UserService>().As<IUserService>().EnableInterfaceInterceptors();
    containerBuilder.RegisterType<DemoInterceptor>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStatusCodePages();

app.UseMiddleware<CustomExceptionHandlerMiddleware>();

//app.UseMiddleware<CustomHotlinkingPreventionMiddleware>();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
