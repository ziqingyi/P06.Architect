using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using P03.DotNetCoreMVC.Interface.TestServiceInterface;
using Microsoft.Extensions.DependencyInjection;

namespace P03.DotNetCoreMVC.Controllers
{
    public class BSecondController : Controller
    {
        private readonly ILogger<BSecondController> _logger;
        private readonly ILoggerFactory _loggerFactory;
        private readonly ITestServiceA _testServiceA;
        private readonly ITestServiceB _testServiceB;
        private readonly ITestServiceC _testServiceC;
        private readonly ITestServiceD _testServiceD;
        private readonly ITestServiceE _testServiceE;
        private readonly IServiceProvider _serviceProvider;

        public BSecondController(ILogger<BSecondController> logger,
            ILoggerFactory loggerFactory
            , ITestServiceA testServiceA
            , ITestServiceB testServiceB
            , ITestServiceC testServiceC
            , ITestServiceD testServiceD
            , ITestServiceE testServiceE
            , IServiceProvider serviceProvider)
        {
            _testServiceA = testServiceA;
            _testServiceB = testServiceB;
            _testServiceC = testServiceC;
            _testServiceD = testServiceD;
            _testServiceE = testServiceE;
            _serviceProvider = serviceProvider;

            this._logger = logger;
            this._loggerFactory = loggerFactory;
        }

        #region Test reference with Scope

        private static ITestServiceC _testServiceCStatic = null;

        private static ITestServiceB _testServiceBStatic = null;
        #endregion
        public IActionResult Index()
        {
            //Microsoft.Extensions.DependencyInjection;
            //_serviceProvider belongs to Controller, will not be free up. 
            //this serviceA will be free up after return. return View(), which is not html page.
            //if the serviceA is freed up, it's binding to HTML will lead to error later. 
            //_testServiceA will be freed up after View() to html. controller is disposed after view display.
            ITestServiceA serviceA = this._serviceProvider.GetService<ITestServiceA>();


            #region TEST Service Provider: 
            //services.AddScoped<ITestServiceC, TestServiceC>();
            //The instance created by service provider is same to container created serviceC.
            //because service provider is singleton in scope. all service created by provider is same. 
            ITestServiceC serviceC = this._serviceProvider.GetService<ITestServiceC>();
            Console.WriteLine($"Controller private serviceC and Action serviceC  equal ? " +
                              $"{object.ReferenceEquals(this._testServiceC, serviceC)}");

            //services.AddScoped<ITestServiceC, TestServiceC>(); False
            if (_testServiceCStatic == null)
            {
                _testServiceCStatic = _testServiceC;
            }
            else
            {
                Console.WriteLine($"Controller private serviceC and Action serviceC  equal ? " +
                                  $"{object.ReferenceEquals(_testServiceCStatic, this._testServiceC)}");
            }

            //services.AddSingleton<ITestServiceB, TestServiceB>(); True
            if (_testServiceBStatic == null)
            {
                _testServiceBStatic = _testServiceB;
            }
            else
            {
                Console.WriteLine($"Controller private serviceB and Action serviceB  equal ? " +
                                  $"{object.ReferenceEquals(_testServiceBStatic, this._testServiceB)}");
            }



            #endregion





            _testServiceA.Show();
            _testServiceB.Show();
            _testServiceC.Show();
            _testServiceD.Show();
            _testServiceE.Show();

            this._logger.LogWarning("this is BSecondController Index");

            return View();
        }
    }
}
