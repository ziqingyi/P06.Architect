using P05.IOCDI.Framework.CustomAOP.AOPAttributes;
using System;

namespace P05.IOCDI.ServiceInterface
{
    public interface ITestServiceA
    {
        [BeforeLog(Order = 1)]
        [AfterLog(Order = 3)]
        [Cache(Order = 5)]
        [Monitor(Order = 7)]
        void Show();

        void Show1();
    }
}
