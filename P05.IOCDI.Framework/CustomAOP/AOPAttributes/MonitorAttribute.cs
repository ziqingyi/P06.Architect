using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05.IOCDI.Framework.CustomAOP.AOPAttributes
{
    public class MonitorAttribute: BaseAOPAttribute
    {
        public override Action DoSomething(Action action)
        {
            return () =>
            {
                Stopwatch stopwatch = new Stopwatch();

                stopwatch.Start();
                Console.WriteLine($"This is {nameof(MonitorAttribute)} DoSomething()  Before");

                action.Invoke();
                Console.WriteLine($"This is {nameof(MonitorAttribute)} DoSomething()  After");

                stopwatch.Stop();
                Console.WriteLine($"This is {nameof(MonitorAttribute)} DoSomething()  {stopwatch.ElapsedMilliseconds}ms");
            };
        }


    }
}
