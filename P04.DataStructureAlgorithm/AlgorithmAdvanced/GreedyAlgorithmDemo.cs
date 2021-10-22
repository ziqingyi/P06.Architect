using System;
using System.Collections.Generic;
using System.Text;

namespace P04.DataStructureAlgorithm.AlgorithmAdvanced
{
    public class GreedyAlgorithmDemo
    {

        public static void Show()
        {
            #region find change
            MakeChangeShow();
            #endregion





        }







        #region find change

        public static void MakeChangeShow()
        {
            double origAmount = 0.63;//原始总金额
            double toChange = origAmount;
            double remainAmount = 0.0;
            int[] coins = new int[4];//4种面值 1-5-10-25
            MakeChange(origAmount, remainAmount, coins);
        }

        public static void MakeChange(double origAmount, double remainAmount, int[] coins)
        {
            if ((origAmount % 0.25) < origAmount)
            {
                coins[3] = (int)(origAmount / 0.25);
                remainAmount = origAmount % 0.25;
                origAmount = remainAmount;
            }
            if ((origAmount % 0.1) < origAmount)
            {
                coins[2] = (int)(origAmount / 0.1);
                remainAmount = origAmount % 0.1;
                origAmount = remainAmount;
            }
            if ((origAmount % 0.05) < origAmount)
            {
                coins[1] = (int)(origAmount / 0.05);
                remainAmount = origAmount % 0.05;
                origAmount = remainAmount;
            }
            if ((origAmount % 0.01) < origAmount)
            {
                coins[0] = (int)(origAmount / 0.01);
                remainAmount = origAmount % 0.01;
            }
            ShowChange(coins);
        }
        private static void ShowChange(int[] arr)
        {
            Console.WriteLine($"Total number of coin : {arr.Length}");
            if (arr[3] > 0)
                Console.WriteLine("Number of 25: " + arr[3]);
            if (arr[2] > 0)
                Console.WriteLine("Number of 10: " + arr[2]);
            if (arr[1] > 0)
                Console.WriteLine("Number of 5: " + arr[1]);
            if (arr[0] > 0)
                Console.WriteLine("Number of 1: " + arr[0]);
        }
        #endregion










    }









}
