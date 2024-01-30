using P09.IOC_Container_DI_Using_Attribute.Interfaces;

namespace P09.IOC_Container_DI_Using_Attribute.Services
{
    public class AuthServiceImpl : IAuthService
    {
        public bool CheckToken()
        {
            Console.WriteLine("check token");
            return true;
        }
    }
}
