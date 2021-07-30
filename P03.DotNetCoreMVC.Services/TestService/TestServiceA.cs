using P03.DotNetCoreMVC.Interface.TestServiceInterface;
using System;

namespace P03.DotNetCoreMVC.Services
{
    public class TestServiceA : ITestServiceA
    {
        public TestServiceA()
        {
            Console.WriteLine($"{this.GetType().Name} is constructed");
        }

        public void Show()
        {
            Console.WriteLine("A123456");
        }
    }
}
