using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace P01.CLRdemo
{
    public class MyLog
    {
        public static void Log(string msg)
        {
            StreamWriter sw = null;
            try
            {
                string fileName = "log.txt";
                string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

                sw = File.AppendText(fullPath);

                sw.WriteLine(string.Format(" {0} : {1} ", DateTime.Now, msg));
                sw.WriteLine("***************************************************");

                Console.WriteLine(msg);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (sw != null)
                {
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }

            }



        }


    }
}
