using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
using P04.DataStructureAlgorithm.CustomExtension;

namespace P04.DataStructureAlgorithm.Algorithm
{
    public static class b_BasicSearchDemo
    {
        public static void Show()
        {
            Console.Clear();
            int[] array = new int[10];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new Random(i + DateTime.Now.Millisecond).Next(0,100);
            }
            array.Show();



            Console.WriteLine("find your int number");


            Console.WriteLine("Please input your int number");
            string sValue = Console.ReadLine();
            if (int.TryParse(sValue, out int iValue))
            {
                #region test different method of search 
                //int ResultLocation = array.SequentialSearch(iValue);
                //array.SequentialSearchWithSelfOrganizing(iValue);
                
                array.BinarySearchRecursion(iValue);

                #endregion 

            }
            else
            {
                Console.WriteLine("Please input right number");
            }

        }


        #region binary search
        public static int BinarySearch(this int[] arr, int value)
        {
            arr.InsertionSort();

            int right = arr.Length - 1;
            int left = 0;
            int middle;

            int newEdge;
            while (left < right)
            {
                middle = (right + left) / 2;
                newEdge = middle - 1;
                if (arr[middle] == value)
                {
                    return middle;
                }
                else if (value < arr[middle])
                {
                    right = newEdge;
                }
                else
                {
                    left = newEdge;
                }
            }

            return -1;
        }

        //binary search recursively

        public static int BinarySearchRecursion(this int[] arr, int value)
        {
            arr.InsertionSort();
            return arr.BinarySearchRecursion(value, 0, arr.Length);
        }

        private static int BinarySearchRecursion(this int[] arr, int value, int left, int right)
        {
            if (left > right)
            {
                return -1;
            }
            else
            {
                int middle = (int) (right + left) / 2;
                if (value < arr[middle])
                {
                    return arr.BinarySearchRecursion(value, left, middle-1);
                }
                else if (value == arr[middle])
                {
                    return middle;
                }
                else
                {
                    return arr.BinarySearchRecursion(value, middle + 1, right);
                }
            }
        }


        #endregion


        #region self organizing
        //just move the searched result to a position before it.
        public static void SequentialSearchWithSelfOrganizing(this int[] arr, int sValue)
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

                    Console.WriteLine(sValue+" is at new position "+ index--);
                    //return true;
                }
            }

            Console.WriteLine("not exist");
            //return false;
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
