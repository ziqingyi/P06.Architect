using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05.IOCDI.Framework.CustomAOP
{
    public static class AOPExtension
    {


        public static T AOP<T>(this object t)
        {
            ProxyGenerator proxy = new ProxyGenerator();
            CustomInterceptor interceptor = new CustomInterceptor();
            return (T)proxy.CreateInterfaceProxyWithTarget(typeof(T), t, interceptor);
        }
        public static object AOP(this object t, Type interfaceType)
        {
            ProxyGenerator proxy = new ProxyGenerator();
            CustomInterceptor interceptor = new CustomInterceptor();
            return proxy.CreateInterfaceProxyWithTarget(interfaceType, t, interceptor);
        }



    }
}
