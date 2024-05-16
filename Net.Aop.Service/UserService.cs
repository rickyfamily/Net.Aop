using Net.Aop.Service.Interface;

namespace Net.Aop.Service
{
    public class UserService : IUserService
    {
        public bool Login(string userName, string pwd)
        {
            Console.WriteLine($"This is {nameof(UserService)} Login Invoke.");
            //throw new Exception("There is an exception in view.");
            return true;
        }
    }
}