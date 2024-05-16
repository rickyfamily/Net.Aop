using Autofac.Extras.DynamicProxy;
using Net.Aop.AutofacAop;

namespace Net.Aop.Service.Interface
{
    [Intercept(typeof(DemoInterceptor))]
    public interface IUserService
    {
        bool Login(string userName, string pwd);
    }
}