
using System;
using P05.IOCDI.Framework.CustomContainerFolder.ContainerAttributes;
using P05.IOCDI.ServiceInterface;

namespace P05.IOCDI.Service
{
    public class TestServiceB : ITestServiceB
    {
        //public attribute for interface access
        [PropertyInjection]
        public ITestServiceA _ITestServiceA { get; set; }
    

        [ConstructorInjectionAttribute]//not affect B, but provide more information
        public TestServiceB(ITestServiceA testServiceA)
        {
            Console.WriteLine($"{this.GetType().Name} is constructed....");
            this._ITestServiceA = testServiceA;
        }

        //public TestServiceB(ITestServiceD testServiceD,int a)
        //{
        //    Console.WriteLine($"{this.GetType().Name} is constructed");
        //}

        public TestServiceB()
        {
            Console.WriteLine($"{this.GetType().Name} is constructed....");
        }



        public void Init(ITestServiceA testServiceA)
        {
            this._ITestServiceA = testServiceA;
        }

        public void Show()
        {
            Console.WriteLine($"This is TestServiceB B123456");
        }
    }
}
