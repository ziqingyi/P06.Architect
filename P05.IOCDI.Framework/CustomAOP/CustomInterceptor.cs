﻿using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05.IOCDI.Framework.CustomAOP
{
    public class CustomInterceptor:StandardInterceptor
    {
        protected override void PreProceed(IInvocation invocation)
        {
            Console.WriteLine($"This is {nameof(CustomInterceptor)} method: {nameof(PreProceed)}");
            base.PreProceed(invocation);
        }



        protected override void PerformProceed(IInvocation invocation)
        {
            Console.WriteLine($"This is {nameof(CustomInterceptor)} method: {nameof(PerformProceed)}");
            base.PerformProceed(invocation);
        }

        protected override void PostProceed(IInvocation invocation)
        {
            Console.WriteLine($"This is {nameof(CustomInterceptor)} method: {nameof(PostProceed)}");
            base.PostProceed(invocation);
        }



    }


}