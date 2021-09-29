using System;
using System.Collections.Generic;
using System.Text;

namespace P04.DataStructureAlgorithm.DataStructure
{
    public class F_TreeDemo
    {
        public static void Show()
        {




        }





    }






    public class CustomTreeNode
    {
        public int data { get; set; }

        public CustomTreeNode left { get; set; }
        public CustomTreeNode right { get; set; }

        public void Show()
        {
            this.left?.Show();
            Console.Write(this.data + " ");//in-order
            this.right?.Show();

            //Console.Write(this.data + " ");//pre-order
            //this.left?.Show();
            //this.right?.Show();

            //this.left?.Show();
            //this.right?.Show();
            //Console.Write(this.data + " ");//post-order
        }


    }























}
