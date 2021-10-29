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
            FindLongestCommonSubStringShow();
            PirateGameShow();
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



        #region longest common sub string

        public static void FindLongestCommonSubStringShow()
        {
            string wordLeft = "eleven";
            string wordRight = "seven";// "secen";// "sevem";
            string result = FindLongCommonSubString(wordLeft, wordRight);

            if (string.IsNullOrWhiteSpace(result))
            {
                Console.WriteLine("no common string");
            }
            else
            {
                Console.WriteLine("Longest Common Sub String: " + result);
            }
        }

        public static string FindLongCommonSubString(string wordLeft, string wordRight)
        {
            string[] warrayLeft = new string[wordLeft.Length];
            string[] warrayRight = new string[wordRight.Length];
            string subString;
            int[,] larray = new int[wordLeft.Length, wordRight.Length];
            CompareString(wordLeft, wordRight, warrayLeft, warrayRight, larray);
            Console.WriteLine();
            ShowArray(larray);
            subString = GetString(larray, warrayLeft);
            Console.WriteLine();
            Console.WriteLine("The strings are: " + wordLeft + " " + wordRight);

            return subString;
        }

        private static void CompareString(string wordLeft, string wordRight, string[] wordArrayLeft, string[] wordArrayRight, int[,] arr)
        {
            int lenLeft = wordLeft.Length;
            int lenRight = wordRight.Length;
            for (int k = 0; k <= wordLeft.Length - 1; k++)
            {
                wordArrayLeft[k] = wordLeft.Substring(k, 1);
            }
            for (int k = 0; k <= wordRight.Length - 1; k++)
            {
                wordArrayRight[k] = wordRight.Substring(k, 1);
            }
            for (int i = lenLeft - 1; i >= 0; i--)
            {
                for (int j = lenRight - 1; j >= 0; j--)
                {
                    if (wordArrayLeft[i] == wordArrayRight[j])
                    {
                        if (i == lenLeft - 1 || j == lenRight - 1)//if it is the edge point
                        {
                            arr[i, j] = 1;
                        }
                        else//accumulate for finding the largest num
                        {
                            arr[i, j] = 1 + arr[i + 1, j + 1];
                        }
                        //arr[i, j] = 1;
                    }
                    else
                    {
                        arr[i, j] = 0;
                    }
                }
            }
        }
        ///find the largest common string in this array
        private static string GetString(int[,] arr, string[] wordArrayLeft)
        {
            string subString = "";
            int max = 0;
            int leftIndex = 0;
            for (int i = 0; i <= arr.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= arr.GetUpperBound(1); j++)
                {
                    if (arr[i, j] > max)
                    {
                        max = arr[i, j];
                        leftIndex = i;
                    }
                }
            }
            for (int i = 0; i < max; i++)
            {
                subString += wordArrayLeft[leftIndex + i];
            }
            return subString;
        }
        //display the array
        private static void ShowArray(int[,] arr)
        {
            Console.WriteLine("Display the Array");
            for (int row = 0; row <= arr.GetUpperBound(0); row++)
            {
                for (int col = 0; col <= arr.GetUpperBound(1); col++)
                {
                    Console.Write(arr[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
        #endregion


        #region Pirate game

        private static void PirateGameShow()
        {

            int pirates = 5;  //海盗总数
            int gold = 100;   //金币总数
            int joinNum;   //加入分配的海盗数
            int[] poke = new int[pirates + 1];  //每个海盗一个口袋
            int ticket;     //票数计数器
            for (int i = pirates; i >= 1; i--)
            {
                joinNum = pirates - i + 1;  //此次加入分配的海盗数
                ticket = 0;
                for (int j = pirates; j >= i; j--)
                {
                    if ((pirates - j + 1) == joinNum)  //如果本海盗就是此次加入分配的最后一个海盗
                    {
                        poke[j] = gold;      //利益最大化，把还剩的金币全给他
                        gold = gold - poke[j];
                        ticket = ticket + 1;
                    }
                    else
                    {
                        if (poke[j] > 0)    //此海盗已经获得了金币
                        {
                            gold = gold + poke[j]; //推论中本次分配者会使上一次获得金币的海盗什么都没有。
                            poke[j] = 0;
                        }
                        else
                        {
                            poke[j] = 1;   //推论中上一次分配中没有获得金币的海盗会在本次获得金币。
                            gold = gold - 1;
                            ticket = ticket + 1;
                        }
                    }
                }
                if ((double)ticket / (double)joinNum < 0.5) { break; } //总得票数/此次加入分配的海盗数>=50%则此次分配成立，否则失败
            }
            for (int n = 1; n <= 5; n++)
            {
                Console.WriteLine("Pirate {0} get {1} gold ", n, poke[n]);
            }
            Console.ReadKey();


        }



        #endregion


    }
}
