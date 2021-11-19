using System;
using P05.IOCDI.ServiceInterface;

namespace P05.IOCDI.Service
{
    public class TestServiceD : ITestServiceD
    {
        public TestServiceD()
        {
            Console.WriteLine($"{this.GetType().Name} is constructed....");
        }

        public void Show()
        {
            Console.WriteLine("D123456");
        }
    }
}
