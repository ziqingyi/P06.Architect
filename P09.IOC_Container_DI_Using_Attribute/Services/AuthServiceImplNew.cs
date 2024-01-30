using P09.IOC_Container_DI_Using_Attribute.CustomAttributes;
using P09.IOC_Container_DI_Using_Attribute.Interfaces;

namespace P09.IOC_Container_DI_Using_Attribute.Services
{
    [Autowired(typeof(IAuthServiceNew))]
    public class AuthServiceImplNew: IAuthServiceNew
    {
        public bool CheckToken()
        {
            Console.WriteLine("check token");
            return true;
        }
    }
}
