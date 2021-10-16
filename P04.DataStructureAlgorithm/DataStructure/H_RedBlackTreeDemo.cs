using System;
using System.Collections.Generic;
using System.Text;

namespace P04.DataStructureAlgorithm.DataStructure
{
    public class H_RedBlackTreeDemo
    {
        //***************************************************************
        int[] arr = {3, 2, 1, 4, 5, 6, 7, 16, 15, 14, 13, 12, 11, 10, 8, 9};

        int i;

        //RedBlackTree tree = new RedBlackTree(arr[0].ToString());
       


   

    }




    #region RedBlackTree




    #endregion
    #region Node

    public class CustomRedBlackTreeNode<T>
    {
        public T Data { get; set; }
        public CustomRedBlackTreeNode<T> LeftChild { get; set; }
        public CustomRedBlackTreeNode<T> RightChild { get; set; }
        public CustomRedBlackTreeNode<T> Parent { get; set; }

        public bool Color { get; set; }

        public CustomRedBlackTreeNode(T value, bool color)
        {
            Data = value;
            LeftChild = null;
            RightChild = null;
            Color = color;
        }
    }
    #endregion







    public static class StringCompareExtend
    {
        public static int StringIntCompareTo(this string value, string target)
        {
            if (int.TryParse(value, out int iValue)
                && int.TryParse(target, out int iTargetValue))
            {
                return iValue.CompareTo(iTargetValue);
            }
            else
            {
                throw new Exception("Only int can StringIntCompareTo");
            }
        }
    }


}
