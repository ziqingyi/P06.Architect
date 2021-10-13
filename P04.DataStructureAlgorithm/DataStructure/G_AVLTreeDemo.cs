using System;
using System.Collections.Generic;
using System.Text;

namespace P04.DataStructureAlgorithm.DataStructure
{
    public class G_AVLTreeDemo
    {
        int[] arr = { 3, 2, 1, 4, 5, 6, 7, 16, 15, 14, 13, 12, 11, 10, 8, 9 };

        int i;


    }

    #region

    public class TreeNode:IComparable
    {
        public int value;
        public int height;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int value)
        {
            this.value = value;
            this.left = null;
            this.right = null;
            height = 1;
        }

        public int CompareTo(object value)
        {
            int.TryParse(value.ToString(), out int targetValue);
            if (targetValue > this.value)
            {
                return 1;
            }

            if (targetValue == this.value)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }

    public class AVLTree
    {
        #region ctor
        private TreeNode _root;
        public AVLTree()
        {
            _root = null;
        }
        #endregion





    }


    #endregion









}
