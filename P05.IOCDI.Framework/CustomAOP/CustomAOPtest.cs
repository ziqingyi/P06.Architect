using Castle.DynamicProxy;
using P05.IOCDI.Framework.CustomAOP.AOPAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05.IOCDI.Framework.CustomAOP
{
    public class CustomAOPtest
    {
        public static void Show()
        {
            {
                //1 add method to CommonClass without changing the class
                ProxyGenerator proxy = new ProxyGenerator();
                CustomInterceptor interceptor = new CustomInterceptor();

                ICommonClass common = new CommonClass();
                common.Show();

                ICommonClass commonClass = (ICommonClass)proxy.CreateInterfaceProxyWithTarget(typeof(ICommonClass), common, interceptor);
                commonClass.Show();

            }


        }


    }





    #region test common class and interface

    public interface ICommonClass
    {
        [BeforeLog]
        [AfterLog]
        void Show();
    }

    public class CommonClass: ICommonClass
    {
        public void Show()
        {
            Console.WriteLine("this is CommonClass Show()....");
        }
    }

    public interface ICommonClass1
    {
        void Show();
    }

    public class CommonClass1 : ICommonClass1
    {
        public void Show()
        {
            Console.WriteLine("this is CommonClass1 Show()....");
        }
    }
    public interface ICommonClass12
    {
        void Show();
    }

    public class CommonClass12 : ICommonClass12
    {
        public void Show()
        {
            Console.WriteLine("this is CommonClass2 Show()....");
        }
    }

    #endregion




}
