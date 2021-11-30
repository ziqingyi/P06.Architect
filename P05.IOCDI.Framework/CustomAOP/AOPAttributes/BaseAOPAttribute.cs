using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05.IOCDI.Framework.CustomAOP.AOPAttributes
{
    public abstract class BaseAOPAttribute: Attribute
    {
        public int Order { get; set; }

        public abstract Action DoSomething(Action action);

    }


}
