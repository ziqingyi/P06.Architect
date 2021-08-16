using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DotNetCoreMVC.Utility
{
    public class StaticConstraint
    {

        //init with what to read, how to read is defined in project. 
        public static void Init(Func<string, string> func)
        {
            //can use iteration and reflection to read many configurations. use projects' read functions.
            connectionString = func.Invoke("ConnectionStrings:JDDbConnectionString");
        }

        public static string connectionString = null;


    }
}
