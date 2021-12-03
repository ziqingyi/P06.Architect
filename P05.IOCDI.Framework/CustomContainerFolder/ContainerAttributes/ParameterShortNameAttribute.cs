using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05.IOCDI.Framework.CustomContainerFolder.ContainerAttributes
{
    [AttributeUsage(AttributeTargets.Parameter|AttributeTargets.Property)]
    public class ParameterShortNameAttribute:Attribute
    {
        public string ShortName { get; private set; }
        public ParameterShortNameAttribute(string shortName)
        {
            this.ShortName = shortName;
        }


    }
}
