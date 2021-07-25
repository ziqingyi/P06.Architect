using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P06.CustomHangFire
{
    public class PrintJob:IPrintJob
    {
        public void Print()
        {
            Console.WriteLine();
        }


    }

    public interface IPrintJob
    { 
        void Print();
    }
}
