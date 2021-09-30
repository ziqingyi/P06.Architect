using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace P04.DataStructureAlgorithm.DataStructure
{
    public class F_TreeDemo
    {
        public static void Show()
        {

            Expression<Func<int, int, int, int>> expression = (i, m, n) => i * 3 + m + 2 + n / 4;
            CustomTreeNode tree = new CustomTreeNode()
            {
                data = 123,
                left = new CustomTreeNode()
                {
                    data = 12,
                    left = new CustomTreeNode()
                    {
                        data = 11,
                        left = null,
                        right = null
                    },
                    right = new CustomTreeNode()
                    {
                        data = 12,
                        left = null,
                        right = null
                    }
                },
                right = new CustomTreeNode()
                {
                    data = 15,
                    left = new CustomTreeNode()
                    {
                        data = 13,
                        left = null,
                        right = null
                    },
                    right = new CustomTreeNode()
                    {
                        data = 17,
                        left = null,
                        right = null
                    }
                }
            };

            CustomBinarySearchTree tree1 = new CustomBinarySearchTree();
            tree1.Insert(10);
            tree1.InOrder();
            Console.WriteLine();
            tree1.Insert(5);
            tree1.InOrder();
            Console.WriteLine();
            tree1.Insert(1);
            tree1.InOrder();
            Console.WriteLine();
            tree1.Insert(8);
            tree1.InOrder();
            Console.WriteLine();
            tree1.Insert(20);
            tree1.InOrder();
            Console.WriteLine();
            tree1.Insert(28);
            tree1.InOrder();
            Console.WriteLine();
            tree1.Insert(12);
            tree1.InOrder();
            Console.WriteLine();
            tree1.Insert(6);
            tree1.InOrder();
            Console.WriteLine();
            tree1.Insert(7);
            tree1.InOrder();
            Console.WriteLine();
            tree1.Insert(25);
            tree1.InOrder();
            Console.WriteLine();


            Console.WriteLine("min: " + tree1.Min());
            Console.WriteLine("max:" + tree1.Max());
            Console.WriteLine("is it in tree? " + tree1.Find(25)?.data);


        }





    }

    public class CustomBinarySearchTree
    {
        private CustomTreeNode root;

        public CustomBinarySearchTree()
        {
            this.root = null;
        }

        public CustomBinarySearchTree(CustomTreeNode rootNode)
        {
            this.root = rootNode;
        }

        #region Insert
        public void Insert(int i)
        {
            CustomTreeNode newNode = new CustomTreeNode();
            newNode.data = i;
            if (root == null)
            {
                root = newNode;
            }
            else
            {
                CustomTreeNode current = this.root;
                CustomTreeNode parent;

                while (true)
                {
                    parent = current;
                    if (i < current.data)
                    {
                        current = current.left;
                        if (current == null)
                        {
                            parent.left = newNode;
                            break;
                        }
                    }
                    else
                    {
                        current = current.right;
                        if (current == null)
                        {
                            parent.right = newNode;
                            break;
                        }
                    }
                }
            }
        }

        #endregion

        #region find

        public CustomTreeNode Find(int i)
        {
            CustomTreeNode current = this.root;
            while (current != null)
            {
                if (i == current.data)
                {
                    return current;
                }

                if (i < current.data)
                {
                    current = current.left;
                }

                if (i > current.data)
                {
                    current = current.right;
                }
            }

            return null;
        }




        #endregion



        #region traversal
        public void InOrder()
        {
            root.ShowInOrder();
        }
        public void PreOrder()
        {
            root.ShowPreOrder();
        }
        public void PostOrder()
        {
            root.ShowPostOrder();
        }

        #endregion


        #region Min and Max
        public int Min()
        {
            CustomTreeNode current = this.root;
            while (current.left != null)
            {
                current = current.left;
            }
            return current.data;
        }

        public int Max()
        {
            CustomTreeNode current = this.root;
            while (current.right != null)
            {
                current = current.right;
            }

            return current.data;
        }
        #endregion












    }





    public class CustomTreeNode
    {
        public int data { get; set; }

        public CustomTreeNode left { get; set; }
        public CustomTreeNode right { get; set; }

        public void ShowInOrder()
        {
            this.left?.ShowInOrder();
            Console.Write(this.data + " ");//in-order
            this.right?.ShowInOrder();
        }

        public void ShowPreOrder()
        {
            Console.Write(this.data + " ");//pre-order
            this.left?.ShowPreOrder();
            this.right?.ShowPreOrder();
        }

        public void ShowPostOrder()
        {
            this.left?.ShowPostOrder();
            this.right?.ShowPostOrder();
            Console.Write(this.data + " ");//post-order
        }

    }























}
