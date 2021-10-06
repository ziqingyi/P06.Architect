using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using P04.DataStructureAlgorithm.CustomExtension;

namespace P04.DataStructureAlgorithm.Algorithm
{
    public static class c_AdvancedSortDemo
    {
        public static void Show()
        {
            #region Random array
            int[] array = new int[10];
            for (int i = 0; i < array.Length; i++)
            {
                Thread.Sleep(100);
                array[i] = new Random(i + 100 + DateTime.Now.Millisecond).Next(100, 999);
            }
            #endregion

            #region Fixed Array
            int[] array0 = { 941, 770, 130, 388, 646, 905, 264, 569, 828, 187 };
            int[] array1 = { 941, 770, 130, 388, 646, 905, 264, 569, 828, 187};
            int[] array2 = { 941, 770, 130, 388, 646, 905, 264, 569, 828, 187 };
            int[] array3 = { 941, 770, 130, 388, 646, 905, 264, 569, 828, 187 };
            int[] array4 = { 941, 770, 130, 388, 646, 905, 264, 569, 828, 187 };

            #endregion

            Console.WriteLine("before Insertion sort");
            array0.Show();
            Console.WriteLine("start Insertion sort");
            array0.InsertionSortOriginal();
            Console.WriteLine("end Insertion Sort");


            Console.WriteLine("before ShellSort");
            array1.Show();
            Console.WriteLine("start ShellSort");
            array1.ShellSort();
            Console.WriteLine("end ShellSort");

            Console.WriteLine("before MergeSort");
            array2.Show();
            Console.WriteLine("start MergeSort");
            array2.MergeSort();
            Console.WriteLine("end MergeSort");
            

            //array.HeapSort();
            //array.QuickSort();

            array.Show();

        }

        #region Shell Sort

        /// <summary>
        /// InsertionSort:
        /// start from the second num, compare with previous num,
        /// swap when left is less than right.
        /// </summary>
        public static void InsertionSortOriginal(this int[] arr)
        {
            int inner, temp;
            for (int outer = 1; outer < arr.Length; outer++)
            {
                //keep the current value, 
                temp = arr[outer];
                inner = outer-1;

                while (inner >= 0 && arr[inner] >= temp)
                {
                    arr[inner + 1] = arr[inner];
                    inner -= 1;
                }
                //swap after -1
                arr[inner+1] = temp;
                arr.Show();
            }
        }

        private static void ShellSort(this int[] arr)
        {
            int inner = 0;
            int temp = 0;
            int increment = 0;
            while (increment <= arr.Length / 3) //10  --4    20   --13
            {
                increment = increment * 3 + 1;
            }
            while (increment > 0)
            {
                for (int outer = increment; outer <= arr.Length -1 ; outer++)
                {
                    #region Swap

                    temp = arr[outer];
                    inner = outer;
                    while ((inner > increment - 1) && arr[inner - increment] >= temp)
                    {
                        arr[inner] = arr[inner - increment];
                        inner -= increment;
                    }
                    arr[inner] = temp;

                    #endregion

                    arr.Show();
                }

                increment = (increment - 1) / 3;
                arr.Show();
            }
        }



        #endregion



        #region Merge Sort
        public static void MergeSort(this int[] arr)
        {
            int[] temp = new int[arr.Length];//empty array
            PartSort(arr, 0, arr.Length - 1, temp);
        }
        private static void PartSort(int[] arr, int left, int right, int[] temp)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;
                PartSort(arr, left, middle, temp);//left side sort
                PartSort(arr, middle + 1, right, temp);//right side sort
                Merge(arr, left, middle, right, temp);//combine together
            }
        }
        private static void Merge(int[] arr, int left, int mid, int right, int[] temp)
        {
            int i = left;
            int j = mid + 1;
            int t = 0;
            while (i <= mid && j <= right)
            {
                if (arr[i] <= arr[j])
                {
                    //temp[t++] = arr[i++];
                    temp[t] = arr[i];
                    t++;
                    i++;
                }
                else
                {
                    //temp[t++] = arr[j++];
                    temp[t] = arr[j];
                    t++;
                    j++;
                }
            }
            while (i <= mid)
            {
                temp[t++] = arr[i++];//left remaining to temp array
            }
            while (j <= right)
            {
                temp[t++] = arr[j++];//right
            }
            t = 0;
            while (left <= right)
            {
                arr[left++] = temp[t++];//put elements in temp to original array
            }
            arr.Show();
        }

        #endregion











    }
}
