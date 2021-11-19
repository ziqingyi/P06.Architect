using System;
using P05.IOCDI.ServiceInterface;

namespace P05.IOCDI.Service
{
    public class TestServiceE : ITestServiceE
    {
        public TestServiceE(ITestServiceC serviceC, ITestServiceB serviceB, ITestServiceA serviceA, ITestServiceD serviceD)
        {
            Console.WriteLine($"{this.GetType().Name} is constructed....");
        }

        public void Show()
        {
            Console.WriteLine("E123456");
        }
    }
}
