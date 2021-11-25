using System;

namespace P05.IOCDI.ServiceInterface
{
    public interface ITestServiceB
    {
        void Show();
        ITestServiceA _ITestServiceA { get; set; }
    }
}
