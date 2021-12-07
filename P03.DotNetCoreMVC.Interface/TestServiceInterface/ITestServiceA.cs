using P03.DotNetCoreMVC.Utility.CustomAOP.AOPAttributes;
using System;

namespace P03.DotNetCoreMVC.Interface.TestServiceInterface
{
    public interface ITestServiceA
    {
        [BeforeLog(Order = 1)]
        [AfterLog(Order = 3)]
        [Cache(Order = 5)]
        [Monitor(Order = 7)]
        void Show();
    }
}
