
using P05.IOCDI.ServiceInterface;

namespace P05.IOCDI.Service
{
    public class TestServiceA : ITestServiceA
    {
        public TestServiceA()
        {
            Console.WriteLine($"{this.GetType().Name}is constructed....");
        }

        private ITestServiceC _ITestServiceC = null;
        //public TestServiceA(ITestServiceC testServiceC)
        //{
        //    Console.WriteLine($"{this.GetType().Name}is constructed....");
        //    this._ITestServiceC=testServiceC; 
        //}

        /// <summary>
        /// property injection, initialize automatically....
        /// </summary>
        public ITestServiceC ITestServiceC { get; set; }

        /// <summary>
        /// method injection
        /// </summary>
        /// <param name="testServiceC"></param>
        public void Init(ITestServiceC testServiceC)
        {
            this._ITestServiceC = testServiceC;
        }

        public void Show()
        {
            Console.WriteLine("A123456");
        }

        public void Show1()
        {
            Console.WriteLine("A123456111111111111111");
        }
    }
}
