using System;
using P05.IOCDI.Framework.CustomContainerFolder.ContainerAttributes;
using P05.IOCDI.ServiceInterface;

namespace P05.IOCDI.Service
{
    public class TestServiceD : ITestServiceD
    {
        private int _id;

        [ConstructorInjection]
        public TestServiceD():this(0)
        {
            this._id = 0;
            Console.WriteLine($"{this.GetType().Name} is constructed....");
        }
        
        public TestServiceD(int a)
        {
            Console.WriteLine($"{this.GetType().Name} is constructed....with constant value: {a}");
        } 
        public void Show()
        {
            Console.WriteLine("D123456");
        }
    }
}
