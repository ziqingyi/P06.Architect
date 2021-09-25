using System;
using System.Collections.Generic;
using System.Text;
using P04.DataStructureAlgorithm.CustomExtension;

namespace P04.DataStructureAlgorithm.Algorithm
{
    public static class b_BasicSearchDemo
    {
        public static void Show()
        {
            int[] array = new int[10];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new Random(i + DateTime.Now.Millisecond).Next(0,100);
            }
            array.Show();

            int iResult = -1;

            Console.WriteLine("find your int number");

            while (iResult < 0)
            {
                Console.WriteLine("Please input your int number");
                string sValue = Console.ReadLine();
                if (int.TryParse(sValue, out int iValue))
                {
                     //iResult = array.SequentialSearch(iValue);
                     bool bResult = array.SequentialSearchWithSelfOrganizing(iValue);
                }
                else
                {
                    Console.WriteLine("Please input right number");
                }
            }
        }




        #region self organizing
        //just move the searched result to a position before it.
        public static bool SequentialSearchWithSelfOrganizing(this int[] arr, int sValue)
        {
            for (int index = 0; index < arr.Length; index++)
            {
                if (arr[index] == sValue)
                {
                    if (index > 0)
                    {
                        int temp = arr[index - 1];
                        arr[index - 1] = arr[index];
                        arr[index] = temp;
                    }
                    return true;
                }
            }
            return false;
        }
        //if searched result is behind top 20 position,
        //move the searched result to a position before it.
        public static int SequentialSearchWithSelfOrganizingAfter20Percent(this int[] arr, int sValue)
        {
            for (int index = 0; index < arr.Length; index++)
            {
                if (arr[index] == sValue)
                {
                    if (index > (arr.Length * 0.2))
                    {
                        if (index > 0)
                        {
                            int temp = arr[index - 1];
                            arr[index - 1] = arr[index];
                            arr[index] = temp;
                            arr.Show();
                        }
                    } 
                    return index-1;//return new index
                }
            }
            return -1;
        }




        #endregion






        #region brute force
        public static int SequentialSearch(this int[] arr, int iValue)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == iValue)
                {
                    return i;
                }
            }
            return -1;
        }
        public static int Min(this int[] arr)
        {
            int min = arr[0];
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                }
            }
            return min;
        }
        public static int Max(this int[] arr)
        {
            int max = arr[0];
            for (int i = 0; i < arr.Length - 1; i++)
            {

                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }
            return max;
        }
        #endregion


    }
}
