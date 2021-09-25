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

    }
}
