using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using P06.CustomHangFire.Interface;

namespace P06.CustomHangFire.Controllers
{
    //dotnet P06.CustomHangFire.dll --urls="http://*:5177" --ip="127.0.0.1" --port=5177 
    //http://localhost:5177/
    //[ApiController]
    //[System.Web.Http.RouteAttribute.Route("[controller]")]
    public class PrintController : ApiController
    {
        private IServiceProvider _serviceProvider;
        private IBackgroundJobClient _backgroundJobClient;
        private IRecurringJobManager _recurringJobManager;
        private ITest _testService;
        public PrintController(
        IBackgroundJobClient backgroundJobClient,
        IRecurringJobManager recurringJobManager,
        IServiceProvider serviceProvider,
        ITest test)
        {
            this._serviceProvider = serviceProvider;
            this._backgroundJobClient = backgroundJobClient;
            this._recurringJobManager = recurringJobManager;
            this._testService = test;
        }

        //[HttpGet]
        public string Index()
        {
            #region add task

            //_backgroundJobClient.Enqueue(() => Console.WriteLine("Hello Hangfire Job 1"));


            _backgroundJobClient.Enqueue(()=>_testService.Show());

            #endregion

            System.Diagnostics.Debug.WriteLine("Print Index Page");
            //return View();
            return "print index";
        }

        public string other()
        {

            _recurringJobManager.AddOrUpdate(
                "Run Every Minute",
                () => Console.WriteLine("Test recurring job"), "* * * * *");


            _recurringJobManager.AddOrUpdate("Run Print Job",
                () => _serviceProvider.GetService<IPrintJob>().Print(),
                "* * * * *");

            _recurringJobManager.AddOrUpdate("TestService",
                () => _serviceProvider.GetService<ITest>().Show(),
                "* * * * *");

            return "other services";
        }


    }
}