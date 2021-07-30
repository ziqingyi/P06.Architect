using P03.DotNetCoreMVC.Interface.TestServiceInterface;
using System;

namespace P03.DotNetCoreMVC.Services
{
    public class TestServiceC : ITestServiceC
    {
        public TestServiceC(ITestServiceB iTestServiceB)
        {
            Console.WriteLine($"{this.GetType().Name} is constructed");
        }
        public void Show()
        {
            Console.WriteLine("C123456");
        }
    }
}
