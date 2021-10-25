using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace P04.DataStructureAlgorithm.AlgorithmAdvanced
{
    public class DynamicPlanningDemo
    {
        public static void Show()
        {
            ShowFibonacci();


        }











        #region Fibonacci

        public static void ShowFibonacci()
        {
            int n = 5;
            {
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    long lResult = RecursionFibonacci(n);
                    stopwatch.Stop();
                    Console.WriteLine($"RecursionFibonacci {n}  Time{stopwatch.ElapsedMilliseconds}");
                }
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    long lResult = DynamicFibonacci(n);
                    stopwatch.Stop();
                    Console.WriteLine($"DynamicFibonacci {n}  Time{stopwatch.ElapsedMilliseconds}");
                }
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    long lResult = DynamicFibonacciWithoutArray(n);
                    stopwatch.Stop();
                    Console.WriteLine($"DynamicFibonacciWithoutArray {n}  Time{stopwatch.ElapsedMilliseconds}");
                }
            }
        }


        /// <summary>
        /// Recursion: 0 1 1 2 3 5 8
        /// </summary>
        /// <param name="n">Begin from 1</param>
        /// <returns></returns>
        public static long RecursionFibonacci(int n)
        {
            if (n < 2)
            {
                return n;
            }
            else
            {
                return RecursionFibonacci(n - 1) + RecursionFibonacci(n - 2);
            }
        }
        /// <summary>
        /// Dynamic Programming -0 1 1 2 3 5 8
        /// </summary>
        /// <param name="n">Begin from 1</param>
        /// <returns></returns>
        public static long DynamicFibonacci(int n)
        {
            int[] totalArray = new int[n];
            if (n == 1 || n == 2)
            {
                return 1;
            }
            else
            {
                totalArray[1] = 1;
                totalArray[2] = 2;
                for (int i = 3; i <= n - 1; i++)
                {
                    totalArray[i] = totalArray[i - 1] + totalArray[i - 2];
                }
            }
            return totalArray[n - 1];
        }
        /// <summary>
        /// DynamicFibonacciWithoutArray-0 1 1 2 3 5 8
        /// </summary>
        /// <param name="n">Begin from 1</param>
        /// <returns></returns>
        public static long DynamicFibonacciWithoutArray(int n)
        {
            long last = 1;
            long nextLast = 1;
            long result = 1;
            for (int i = 2; i <= n - 1; i++)
            {
                result = last + nextLast;
                nextLast = last;
                last = result;
            }
            return result;
        }
        #endregion








    }
}
