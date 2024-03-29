﻿using Castle.DynamicProxy;
using P03.DotNetCoreMVC.Utility.CustomAOP.AOPAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace P03.DotNetCoreMVC.Utility.CustomAOP
{
    public class CustomInterceptor : StandardInterceptor
    {
        protected override void PreProceed(IInvocation invocation)
        {
            Console.WriteLine($"This is {nameof(CustomInterceptor)} method: {nameof(PreProceed)}");
            base.PreProceed(invocation);
        }



        protected override void PerformProceed(IInvocation invocation)
        {
            //store base method
            Action action = () => base.PerformProceed(invocation);


            //find all attributes, add action into the methods, encapsulate. 
            if (invocation.Method.IsDefined(typeof(BaseAOPAttribute), true))
            {
                var attributes = invocation.Method.GetCustomAttributes<BaseAOPAttribute>().OrderBy(a => a.Order);

                foreach (BaseAOPAttribute attr in attributes)
                {
                    action = attr.DoSomething(action);
                }

            }


            action.Invoke();
            Console.WriteLine($"This is {nameof(CustomInterceptor)} method: {nameof(PerformProceed)}");
            //base.PerformProceed(invocation);
        }

        protected override void PostProceed(IInvocation invocation)
        {
            Console.WriteLine($"This is {nameof(CustomInterceptor)} method: {nameof(PostProceed)}");
            base.PostProceed(invocation);
        }



    }
}
