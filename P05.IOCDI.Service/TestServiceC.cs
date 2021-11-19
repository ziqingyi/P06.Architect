using System;
using P05.IOCDI.ServiceInterface;

namespace P05.IOCDI.Service
{
    public class TestServiceC : ITestServiceC
    {
        public TestServiceC(ITestServiceB iTestServiceB)
        {
            Console.WriteLine($"{this.GetType().Name} is constructed....");
        }
        public void Show()
        {
            Console.WriteLine("C123456");
        }
    }
}
