using System;
using System.Collections.Generic;
using System.Text;

namespace P04.DataStructureAlgorithm.CustomExtension
{
    public static class ArrayExtension
    {
        public static void Show(this int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write(item.ToString() + " ");
            }
            Console.WriteLine();
        }
        public static void Show(this int[] arr, int count)
        {
            for (int i = 0;i < arr.Length;i++)
            {

                Console.Write(arr[i].ToString() + " ");

                if ((i + 1) % count == 0)
                {
                    Console.Write(" * ");
                }

            }
            Console.WriteLine();
        }
    }
}
