using System;
using System.Collections.Generic;
using System.Text;

namespace P04.DataStructureAlgorithm.DataStructure
{
    public class G_AVLTreeDemo
    {
        int[] arr = { 3, 2, 1, 4, 5, 6, 7, 16, 15, 14, 13, 12, 11, 10, 8, 9 };

        int i;

        public static void Show()
        {

            //***************************************************************
            int[] arr = { 3, 2, 1, 4, 5, 6, 7, 16, 15, 14, 13, 12, 11, 10, 8, 9 };

            int i;
            AVLTree tree = new AVLTree();

            Console.WriteLine("*******Insert Values: ");
            for (i = 0; i < arr.Length; i++)
            {
                tree.Insert(arr[i]);
            }

            Console.WriteLine("*******PreTraversal: ");
            tree.PreTraversal();
            Console.WriteLine();


            Console.WriteLine("*******InOrderTraversal: ");
            tree.InOrderTraversal();
            Console.WriteLine();


            Console.WriteLine("*******PostTraversal: ");
            tree.PostTraversal();
            Console.WriteLine();


            Console.WriteLine("*******Height:" + tree.TreeHeight());
            Console.WriteLine("*******Min:" + tree.Min().value);
            Console.WriteLine("*******Max:" + tree.Max().value);
            Console.WriteLine("*******Tree Show():");
            tree.Show();
            Console.WriteLine();


            i = 8;
            Console.WriteLine($"*******Remove : {i}");
            tree.Remove(i);
            tree.Show();
            Console.WriteLine("*******Height:" + tree.TreeHeight());
            Console.WriteLine("*******InOrderTraversal: ");
            tree.InOrderTraversal();
            Console.WriteLine();

            i = 17;
            Console.WriteLine($"*******Insert node: {i}");
            tree.Insert(i);
            tree.Show();
            Console.WriteLine("*******Height:" + tree.TreeHeight());
            Console.WriteLine("*******InOrderTraversal: ");
            tree.InOrderTraversal();
            Console.WriteLine();

            Console.WriteLine("*******Tree Show():");
            tree.Show();
            Console.WriteLine();

            tree.Destroy();
        }

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

        #region Tree height
        private int NodeHeight(TreeNode TreeNode)
        {
            if (TreeNode != null)
            {
                return TreeNode.height;
            }
            return 0;
        }
        public int TreeHeight()
        {
            return NodeHeight(_root);
        }
        #endregion


        #region private
        private int ChooseMax(int a, int b)
        {
            return a > b ? a : b;
        }
        private void ReplaceNode(TreeNode src, TreeNode tar)
        {
            tar.value = src.value;
        }
        #endregion


        #region Traversal : Pre-Sequential-Post

        private void PreTraversal(TreeNode TreeNode)
        {
            if (TreeNode != null)
            {
                Console.Write(TreeNode.value + " ");
                PreTraversal(TreeNode.left);
                PreTraversal(TreeNode.right);
            }
        }

        public void PreTraversal()
        {
            PreTraversal(_root);
        }

        private void InOrderTraversal(TreeNode TreeNode)
        {
            if (TreeNode != null)
            {
                InOrderTraversal(TreeNode.left);
                Console.Write(TreeNode.value + " ");
                InOrderTraversal(TreeNode.right);
            }
        }

        public void InOrderTraversal()
        {
            InOrderTraversal(_root);
        }

        private void PostTraversal(TreeNode TreeNode)
        {
            if (TreeNode != null)
            {
                PostTraversal(TreeNode.left);
                PostTraversal(TreeNode.right);
                Console.Write(TreeNode.value + " ");
            }
        }

        public void PostTraversal()
        {
            PostTraversal(_root);
        }
        #endregion

        #region Search-Max-Min
        /// <summary>
        /// Search TreeNode root
        /// </summary>
        /// <param name="TreeNode"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private TreeNode Search(TreeNode TreeNode, int value)
        {
            if (TreeNode == null)
            {
                return null;
            }
            int compare = TreeNode.CompareTo(value);
            if (compare == 0)
            {
                return TreeNode;
            }
            else if (compare < 0)
            {
                return Search(TreeNode.left, value);
            }
            else
            {
                return Search(TreeNode.right, value);
            }
        }

        public TreeNode Search(int value)
        {
            return Search(_root, value);
        }

        private TreeNode Min(TreeNode TreeNode)
        {
            if (TreeNode == null)
            {
                return null;
            }
            else if (TreeNode.left == null)
            {
                return TreeNode;
            }
            else
            {
                return Min(TreeNode.left);
            }
        }

        public TreeNode Min()
        {
            return Min(_root);
        }

        private TreeNode Max(TreeNode TreeNode)
        {
            if (TreeNode == null)
            {
                return null;
            }
            else if (TreeNode.right == null)
            {
                return TreeNode;
            }
            else
            {
                return Max(TreeNode.right);
            }
        }

        public TreeNode Max()
        {
            return Max(_root);
        }
        #endregion

        #region Rebalancing --4 Cases
        // 	Left Left Case 
        //
        //         k1                 k2
        //        /  \               /  \
        //       k2   z    LL单转   x    k1
        //      /  \       ----\   /    / \
        //     x    y      ----/  o    y   z
        //    //    /      k1右旋
        //   o
        //
        //   or
        //
        //         k1                 k2
        //        /  \               /  \
        //       k2   z    LL单转    x   k1
        //      /  \       ----\     \  / \
        //     x    y      ----/      o y  z
        //      \          k1右旋
        //       o
        //
        private TreeNode LeftLeftRotation(TreeNode k1)
        {
            TreeNode k2 = k1.left; 

            k1.left = k2.right;
            k2.right = k1; 

            k1.height = ChooseMax(NodeHeight(k1.left), NodeHeight(k1.right)) + 1;
            k2.height = ChooseMax(NodeHeight(k2.left), k1.height) + 1;

            return k2;
        }

        // Right Right Case 
        //
        //         k1                      k2
        //        /  \                    /  \
        //       x    k2      RR单转     k1   k3
        //           / \      ----\     / \    \
        //          y   k3    ----/    x   y    z
        //               \    k1左旋
        //                z
        //
        //   or
        //
        //         k1                      k2
        //        /  \                    /  \
        //       x    k2      RR单转     k1   k3
        //           / \      ----\     / \   /
        //          y  k3     ----/    x   y z
        //             /      k1左旋
        //            z
        //
        public TreeNode RightRightRotation(TreeNode k1)
        {
            TreeNode k2 = k1.right;

            k1.right = k2.left;
            k2.left = k1;

            k1.height = ChooseMax(NodeHeight(k1.left), NodeHeight(k1.right)) + 1;
            k2.height = ChooseMax(k1.height, NodeHeight(k2.right)) + 1;

            return k2;
        }

        // Left Right Case 
        //      k1                k1                k3
        //     /  \              /  \              /  \
        //    k2   z  RR单转    k3   z   LL单转    k2  k1
        //   /  \     -----\   / \      -----\   / \  / \
        //  w   k3    -----/  k2  y     -----/  w  x y   z
        //     /  \   k2左旋  / \        k1右旋
        //    x    y         w  x
        //
        public TreeNode LeftRightRotation(TreeNode k1)
        {
            k1.left = RightRightRotation(k1.left);
            return LeftLeftRotation(k1);
        }

        // Right Left Case 
        //    k1                k1                  k3
        //   /  \     LL单转    / \      RR单旋     /  \
        //  w   k2    -----\   w  k3    -----\    k1  k2
        //      / \   -----/     / \    -----/   / \  / \
        //     k3  z  k2右旋     x  k2   k1左旋  w   x y  z
        //    / \                  / \
        //   x   y                y   z
        //
        public TreeNode RightLeftRotation(TreeNode k1)
        {
            k1.right = LeftLeftRotation(k1.right);
            return RightRightRotation(k1);
        }
        #endregion

        #region Insert
        private TreeNode Insert(TreeNode TreeNode, int value)
        {
            if (TreeNode == null) return new TreeNode(value);

            if (TreeNode.CompareTo(value) == 0)
            {//如果key相同则更新该节点
                TreeNode.value = value;//可以记录个count
            }
            else if (TreeNode.CompareTo(value) < 0)
            {//如果key比当前根小，则去左子树找。即一步left
                TreeNode.left = Insert(TreeNode.left, value);
                if (NodeHeight(TreeNode.left) - NodeHeight(TreeNode.right) == 2)
                {//插在左边所以肯定是左-右，高度差2表示已经不平衡
                    if (TreeNode.left.CompareTo(value) < 0)
                    {// 又一步left，所以是LeftLeft
                        TreeNode = LeftLeftRotation(TreeNode);
                    }
                    else
                    { //一步right，所以是LeftRight
                        TreeNode = LeftRightRotation(TreeNode);
                    }
                }
            }
            else
            {   // TreeNode.key < key,那么去右子树找.即一步right
                TreeNode.right = Insert(TreeNode.right, value);
                if (NodeHeight(TreeNode.right) - NodeHeight(TreeNode.left) == 2)
                {//插在右边所以肯定是右-左，高度差2表示已经不平衡
                    if (TreeNode.right.CompareTo(value) > 0)
                    {//又一步right,所以是RightRight
                        TreeNode = RightRightRotation(TreeNode);
                    }
                    else
                    {//一步left，所以是RightLeft
                        TreeNode = RightLeftRotation(TreeNode);
                    }
                }
            }

            TreeNode.height = ChooseMax(NodeHeight(TreeNode.left), NodeHeight(TreeNode.right)) + 1;
            return TreeNode;
        }
        public void Insert(int value)
        {
            this._root = Insert(this._root, value);
        }
        #endregion

        #region Delete
        public TreeNode Remove(TreeNode TreeNode, TreeNode target)
        {
            if (TreeNode == null || target == null) return TreeNode;
            int compare = TreeNode.CompareTo(target.value);

            if (compare < 0)
            {//待删除key的比根的key小，那么继续在左子树查找
                TreeNode.left = Remove(TreeNode.left, target);
                if (NodeHeight(TreeNode.right) - NodeHeight(TreeNode.left) == 2)
                {//如果在删除后失去平衡
                    if (NodeHeight(TreeNode.right.left) <= NodeHeight(TreeNode.right.right))
                    {
                        TreeNode = RightRightRotation(TreeNode);
                    }
                    else
                    {
                        TreeNode = RightLeftRotation(TreeNode);
                    }
                }
            }
            else if (compare > 0)
            {//待删除key的比根的key大，那么继续在右子树查找
                TreeNode.right = Remove(TreeNode.right, target);
                if (NodeHeight(TreeNode.left) - NodeHeight(TreeNode.right) == 2)
                {
                    if (NodeHeight(TreeNode.left.right) <= NodeHeight(TreeNode.left.left))
                    {
                        TreeNode = LeftLeftRotation(TreeNode);
                    }
                    else
                    {
                        TreeNode = RightRightRotation(TreeNode);
                    }
                }
            }
            else
            { // TreeNode.key == target.key
                if (TreeNode.left == null)
                { // 如果TreeNode的左子树为空，那么删除TreeNode后，新的根就是TreeNode.right
                    return TreeNode.right;
                }
                else if (TreeNode.right == null)
                {// 如果TreeNode的右子树为空，那么删除TreeNode后，新的根就是TreeNode.left
                    return TreeNode.left;
                }
                else
                { // 如果TreeNode既有左子树，又有右子树
                    if (NodeHeight(TreeNode.left) > NodeHeight(TreeNode.right))
                    {//如果左子树比右子树深
                        TreeNode predecessor = Max(TreeNode.left);//找TreeNode的前继结点predecessor
                        ReplaceNode(predecessor, TreeNode);//predecessor替换TreeNode
                        TreeNode.left = Remove(TreeNode.left, predecessor);//再把原来的predecessor删掉
                    }
                    else
                    {//如果右子树比左子树深(一样深的话无所谓了)
                        TreeNode successor = Min(TreeNode.right);//找TreeNode的后继结点successor
                        ReplaceNode(successor, TreeNode);//successor替换TreeNode
                        TreeNode.right = Remove(TreeNode.right, successor);//再把原来的successor删掉
                    }
                }
            }
            return TreeNode;
        }
        public void Remove(int value)
        {
            TreeNode z = Search(_root, value);
            if (z != null)
                _root = Remove(_root, z);
        }
        #endregion

        #region Show-Destroy
        private void Destroy(TreeNode TreeNode)
        {
            if (TreeNode == null)
                return;

            if (TreeNode.left != null)
                Destroy(TreeNode.left);
            if (TreeNode.right != null)
                Destroy(TreeNode.right);

            TreeNode = null;
        }
        public void Destroy()
        {
            Destroy(_root);
        }
        private void Show(TreeNode TreeNode, int value, string pos)
        {
            if (TreeNode != null)
            {
                if (pos.Equals(""))    // tree是根节点
                    Console.WriteLine($"{TreeNode.value} is root");
                else                // tree是某个value的分支节点
                    Console.WriteLine($"{TreeNode.value} is  {value}  {pos} child,height={TreeNode.height}");

                Show(TreeNode.left, TreeNode.value, "left");
                Show(TreeNode.right, TreeNode.value, "right");
            }
        }
        public void Show()
        {
            if (_root != null) Show(_root, _root.value, "");
        }
        #endregion






    }


    #endregion









}
