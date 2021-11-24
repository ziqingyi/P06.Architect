using System;
using P05.IOCDI.Framework.CustomContainerFolder.ContainerAttributes;
using P05.IOCDI.ServiceInterface;

namespace P05.IOCDI.Service
{
    public class TestServiceC : ITestServiceC
    {
        [InjectionProperty]
        public ITestServiceA _ITestServiceA { get; set; }

        private ITestServiceB _ITestServiceB ;

        public int iNumber { get; set; }
        public TestServiceC(ITestServiceB iTestServiceB)
        {
            this._ITestServiceB = iTestServiceB;
            Console.WriteLine($"{this.GetType().Name} is constructed....");
        }
        public void Show()
        {
            Console.WriteLine("C123456"); 
            Console.WriteLine($"this._ITestServiceA is null？{this._ITestServiceA is null}");
        }
    }
}
