using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05.IOCDI.Framework.CustomContainerFolder.ContainerAttributes
{

    //label for property injection 
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyInjectionAttribute : Attribute
    {
    }
}
