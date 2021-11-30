using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05.IOCDI.Framework.CustomAOP.AOPAttributes
{
    public class AfterLogAttribute : BaseAOPAttribute
    {

        public override Action DoSomething(Action action)
        {
            return () =>
            {
                action.Invoke();

                //do something after action
                Console.WriteLine($"This is {nameof(AfterLogAttribute)} {typeof(AfterLogAttribute)} DoSomething");
                
            };
        }



    }
}
