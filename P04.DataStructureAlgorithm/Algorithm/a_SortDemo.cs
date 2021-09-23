using System;
using System.Collections.Generic;
using System.Text;

namespace P04.DataStructureAlgorithm.Algorithm
{
    public static class a_SortDemo
    {

        public static void Show()
        {
            int[] array = new int[10];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new Random(i + DateTime.Now.Millisecond).Next(100, 999);
            }

            Console.WriteLine("before BubbleSort");
            array.Show();
            Console.WriteLine("start BubbleSort");
            //array.BubbleSort();
            //array.SelectionSort();
            array.InsertionSort();

            Console.WriteLine("  end BubbleSort");
            array.Show();
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
                for (int inner = 0; inner <= outer - 1; inner++)
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

        private static void Show(this int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write(item.ToString() + " ");
            }
            Console.WriteLine();
        }




    }
}
