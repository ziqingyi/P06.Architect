using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.DotNetCoreMVC.Utility.CustomAOP.AOPAttributes
{
    public class CacheAttribute:BaseAOPAttribute
    {
        public override Action DoSomething(Action action)
        {

            return () =>
            {
                action.Invoke();
                Console.WriteLine($"This is {nameof(CacheAttribute)} DoSomething()");
            };


        }


    }
}
