using System;
using System.Threading.Tasks;

namespace P06.Architect
{
    class Program
    {
        private static volatile int SuperSum = 0;
        private static readonly object _lock = new object();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            int sum = 0;
            
            Task[] tasks = new Task[10];
            for (int i = 0; i < 10; i++)
            {
                tasks[i] = Task.Run(
                    () => 
                        increment(ref SuperSum)
                    );
            }
            Task.WaitAll(tasks);

            Console.WriteLine(SuperSum);

            Console.ReadKey();

        }


        static void increment(ref int a)
        {
            lock (_lock)
            {
                 for (int i = 0; i < 1000; i++) 
                     a++;
            }
           


        }
    




    }
}
