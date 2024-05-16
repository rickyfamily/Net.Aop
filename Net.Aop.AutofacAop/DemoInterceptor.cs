using Castle.DynamicProxy;
using Newtonsoft.Json;

namespace Net.Aop.AutofacAop
{
    public class DemoInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            PreAction(invocation);
            invocation.Proceed();
            AfterAction(invocation);
        }

        private void PreAction(IInvocation invocation)
        {
            var method = invocation.Method;
            var arguments = invocation.Arguments;
            Console.WriteLine($"This is {nameof(DemoInterceptor)} Autofac AOP.");
            Console.WriteLine($"The method name is {method.Name}, the augments are {JsonConvert.SerializeObject(arguments)}.");
        }

        private void AfterAction(IInvocation invocation)
        {
            Console.WriteLine("The method is executed. The result is {0}.", invocation.ReturnValue);
        }
    }
}