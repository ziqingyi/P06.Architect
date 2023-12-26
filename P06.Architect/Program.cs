using P06.Architect.AspNetCoreCustom;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace P06.Architect
{
    class Program
    {

        [DllImport("C:\\xxxxxx\\repos\\ziqingyi\\P06.Architect\\x64\\Debug\\P08CPlusPlusDll.dll")]
        public static extern int Add(int a, int b);

        static void Main(string[] args)
        {
            //Console.WriteLine(Add(33, 2));

            //MiddlewareProcess.Show1();
        }



    }
}
