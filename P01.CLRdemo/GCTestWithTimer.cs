using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Timers;
using Timer = System.Threading.Timer;


namespace P01.CLRdemo
{
    public class GCTestWithTimer
    {
        public static void Show()
        {
            //1
           // TestSystemTimers_Timer();

            //Timer timer1 = new Timer(Timer_Elapsed_Thread, null, 0, 2000);
            //2
            TestThreading_Timer();
        }

        private static void TestSystemTimers_Timer()
        {
            System.Timers.Timer timer = new System.Timers.Timer(1000 * 10);
            timer.Elapsed += Timer_Elapsed_System;
            timer.Start();

            Console.WriteLine("key to stop timer....");
            Console.Read();
        }
        private static void Timer_Elapsed_System(object sender, ElapsedEventArgs e)
        {
            Thread.Sleep(100);
            Console.WriteLine($"This is Timer_Elapsed_System Invoke....{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")}");
            GC.Collect();
        }

        private static void TestThreading_Timer()
        {
            System.Threading.Timer timer = new Timer(Timer_Elapsed_Thread, null, 0,2000);
            Console.WriteLine("key to stop timer....");
            Console.Read();
        }

        private static void Timer_Elapsed_Thread(object sender)
        {
            Thread.Sleep(100);
            Console.WriteLine($"This is Timer_Elapsed_Thread Invoke....{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")}");
            GC.Collect(0);
        }



    }
}
