using System;
using System.Collections.Generic;
using System.Text;
using P04.DataStructureAlgorithm.CustomExtension;

namespace P04.DataStructureAlgorithm.Algorithm
{
    public static class a_SortDemo
    {

        public static void Show()
        {
            int[] array1 = new int[10];
            int[] array2 = new int[10];
            int[] array3 = new int[10];
            for (int i = 0; i < array1.Length; i++)
            {
                 int newRand= new Random(i + DateTime.Now.Millisecond).Next(100, 999);
                 array1[i] = newRand;
                 array2[i] = newRand;
                 array3[i] = newRand;

            }


            Console.WriteLine("before BubbleSort");

            
            array1.Show();
            Console.WriteLine("start Bubble Sort");
            array1.BubbleSort();

            Console.WriteLine("before Selection sort");
            array2.Show();
            Console.WriteLine("start Selection sort");
            array2.SelectionSort();


            Console.WriteLine("before Insertion sort");
            array3.Show();
            Console.WriteLine("start Insertion sort");
            array3.InsertionSort();

        }


        /// <summary>
        /// BubbleSort
        /// 1 pick largest one one the right
        /// 2 pick the smallest one on the left
        /// </summary>
        /// <param name="arr"></param>
        public static void BubbleSort(this int[] arr)
        {
            int temp;
            for (int outer = arr.Length; outer >= 1; outer--)
            {
                for (int inner = 0; inner <= outer - 2; inner++)
                {
                    if (arr[inner] > arr[inner + 1])
                    {
                        temp = arr[inner];
                        arr[inner] = arr[inner + 1];
                        arr[inner + 1] = temp;
                    }
                }
                arr.Show();
            }
        }
        /// <summary>
        /// SelectionSort
        /// </summary>
        /// <param name="arr"></param>
        public static void SelectionSort(this int[] arr)
        {
            int min, temp;
            for (int outer = 0; outer < arr.Length; outer++)
            {
                //find the smallest one on the right, swap with current position.
                min = outer;
                for (int inner = outer + 1; inner < arr.Length; inner++)
                {
                    if (arr[inner] < arr[min])
                    {
                        min = inner;
                    }
                }
                temp = arr[outer];
                arr[outer] = arr[min];
                arr[min] = temp;
                arr.Show();
            }
        }

        /// <summary>
        /// InsertionSort
        /// </summary>
        /// <param name="arr"></param>
        public static void InsertionSort(this int[] arr)
        {
            int inner, temp;
            for (int outer = 1; outer < arr.Length; outer++)
            {
                //keep the current value, 
                temp = arr[outer];
                inner = outer;
                while (inner > 0 && arr[inner - 1] >= temp)
                {
                    arr[inner] = arr[inner - 1];
                    inner -= 1;
                }
                arr[inner] = temp;
                arr.Show();
            }
        }





    }
}
