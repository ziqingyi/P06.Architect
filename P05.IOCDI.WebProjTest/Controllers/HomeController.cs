using Microsoft.AspNetCore.Mvc;
using P05.IOCDI.ServiceInterface;

namespace P05.IOCDI.WebProjTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITestServiceA _iTestServiceA;
        private readonly ITestServiceB _iTestServiceB;
        private readonly ITestServiceC _iTestServiceC;
        private readonly ITestServiceD _iTestServiceD;
        private readonly ITestServiceE _iTestServiceE;

        private static ITestServiceB _iTestServiceB2;
        private static ITestServiceD _iTestServiceD2;


        public HomeController(
            ITestServiceA testServiceA
            , ITestServiceA testServiceA2
            , ITestServiceB testServiceB
            , ITestServiceB testServiceB2
            , ITestServiceC testServiceC
            , ITestServiceD testServiceD
            , ITestServiceD testServiceD2
            , ITestServiceE testServiceE)
        {

            this._iTestServiceA = testServiceA;
            this._iTestServiceB = testServiceB;
            this._iTestServiceC = testServiceC;
            this._iTestServiceD = testServiceD;
            this._iTestServiceE = testServiceE;

            Console.WriteLine("*********************************************");
            Console.WriteLine($"AddTransient ： testServiceA2.Equals(testServiceA)=={testServiceA2.Equals(testServiceA)}"); //false
            Console.WriteLine($"AddScoped (same in same request)： testServiceB2.Equals(testServiceB)=={testServiceB2.Equals(testServiceB)}");//true
            Console.WriteLine($"AddSingleton ： testServiceD2.Equals(testServiceD)=={testServiceD2.Equals(testServiceD)}"); //true


            if (_iTestServiceB2 == null)
            {
                _iTestServiceB2 = testServiceB2; //use static field to keep the previous service B instance
                Console.WriteLine("scope _iTestServiceB2  initialization");
            }
            else
            {
                Console.WriteLine($"scope + static：testServiceB2.Equals(_iTestServiceB2)=={testServiceB2.Equals(_iTestServiceB2)}");//false;
            }

            if (_iTestServiceD2 == null)
            {
                _iTestServiceD2 = testServiceD2;
                Console.WriteLine("Singleton  _iTestServiceD2 initialization");
            }
            else
            {
                Console.WriteLine($" Singleton + static ： testServiceD2.Equals(_iTestServiceD2)=={testServiceD2.Equals(_iTestServiceD2)}");//true
            }
            Console.WriteLine("*********************************************");
        }

        public IActionResult Index()
        {
            this._iTestServiceA.Show();
            this._iTestServiceB.Show();
            this._iTestServiceC.Show();
            this._iTestServiceD.Show();
            this._iTestServiceE.Show();

            //base.HttpContext.RequestServices.GetService<ITestServiceA>();


            return View();
        }






    }
}
