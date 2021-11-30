using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05.IOCDI.Framework.CustomAOP.AOPAttributes
{
    public class BeforeLogAttribute: BaseAOPAttribute
    {
        public override Action DoSomething(Action action)
        {                
            //name: BeforeLogAttribute              
            //typeof: P05.IOCDI.Framework.CustomAOP.AOPAttributes.BeforeLogAttribute

            return () =>
            {
                //do something before action
                Console.WriteLine($"This is {nameof(BeforeLogAttribute)} {typeof(BeforeLogAttribute)} DoSomething()");


                action.Invoke();
            };
        }


    }
}
