﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05.IOCDI.Framework.CustomContainerFolder.ContainerAttributes
{
    //label for method injection 
    [AttributeUsage(AttributeTargets.Method)]
    public class MethodInjectionAttribute:Attribute
    {
    }
}
