using System;
using System.Collections.Generic;
using System.Runtime;
using System.Text;

namespace P01.CLRdemo
{
    public class GCTypeTest
    {
        public static void Show()
        {

            Console.WriteLine(GCSettings.IsServerGC?"Server":"WorkStationGC");


        }


    }
}
