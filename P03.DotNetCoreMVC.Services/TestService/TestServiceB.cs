
using P03.DotNetCoreMVC.Interface.TestServiceInterface;
using System;

namespace P03.DotNetCoreMVC.Services
{
    public class TestServiceB : ITestServiceB
    {
        public TestServiceB(ITestServiceA iTestServiceA)
        {
            Console.WriteLine($"{this.GetType().Name} is constructed");
        }


        public void Show()
        {
            Console.WriteLine($"This is TestServiceB B123456");
        }
    }
}
