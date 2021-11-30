using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05.IOCDI.Framework.CustomAOP.AOPAttributes
{
    public class ParameterValidateAttribute: BaseAOPAttribute
    {

        public override Action DoSomething(Action action)
        {
            return () =>
            {
                Console.WriteLine($"This is {nameof(ParameterValidateAttribute)} DoSomething()");

                action.Invoke();
            };
        }


    }
}
