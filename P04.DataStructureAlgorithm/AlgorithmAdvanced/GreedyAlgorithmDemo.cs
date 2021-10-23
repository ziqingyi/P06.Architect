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

            HuffmanShow();



        }







        #region find change
        
        public static void MakeChangeShow()
        {
            double origAmount = 0.63;//total amount 
            double toChange = origAmount;
            double remainAmount = 0.0;
            int[] coins = new int[4];//4 kinds of coins 1-5-10-25
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



        #region Huffman Tree
        public static void HuffmanShow()
        {
            #region Huffman
            {
                string input;
                Console.Write("Please type: ");
                input = Console.ReadLine();
                TreeList treeList = new TreeList(input);
                for (int i = 0; i < input.Length; i++)
                {
                    treeList.AddSign(input[i].ToString());
                }

                treeList.SortTree();
                while (treeList.Length() > 1)
                    treeList.MergeTree();
                TreeList.MakeKey(treeList.RemoveTree(), "");
                string newStr = TreeList.Translate(input);
                string[] signTable = treeList.GetSignTable();
                string[] keyTable = treeList.GetKeyTable();
                for (int i = 0; i <= signTable.Length - 1; i++)
                    Console.WriteLine(signTable[i] + ": " + keyTable[i]);

                Console.WriteLine("original length " + input.Length * 16 + " bits.");
                Console.WriteLine("after compression:  " + newStr.Length + " bits long.");
                Console.WriteLine("code after compression:" + newStr);
            }
            #endregion
        }
        public class Node
        {
            public HuffmanTree data;
            public Node link;
            public Node(HuffmanTree newData)
            {
                data = newData;
            }
        }
        public class TreeList
        {
            private int count = 0;
            private Node first = null;
            private static string[] signTable = null;
            private static string[] keyTable = null;
            public TreeList(string input)
            {
                List<char> list = new List<char>();
                for (int i = 0; i < input.Length; i++)
                {
                    if (!list.Contains(input[i]))
                        list.Add(input[i]);
                }
                signTable = new string[list.Count];
                keyTable = new string[list.Count];
            }
            public string[] GetSignTable()
            {
                return signTable;
            }
            public string[] GetKeyTable()
            {
                return keyTable;
            }
            public void AddLetter(string letter)
            {
                HuffmanTree hTemp = new HuffmanTree(letter);
                Node eTemp = new Node(hTemp);
                if (first == null)
                    first = eTemp;
                else
                {
                    eTemp.link = first;
                    first = eTemp;

                    count++;
                }
            }

            public void SortTree()
            {
                if (first != null && first.link != null)
                {
                    Node tmp1;
                    Node tmp2;
                    for (tmp1 = first; tmp1 != null; tmp1 = tmp1.link)
                        for (tmp2 = tmp1.link; tmp2 != null; tmp2 = tmp2.link)
                        {
                            if (tmp1.data.GetFreq() > tmp2.data.GetFreq())
                            {
                                HuffmanTree tmpHT = tmp1.data;
                                tmp1.data = tmp2.data;
                                tmp2.data = tmpHT;
                            }
                        }
                }
            }
            public void MergeTree()
            {
                if (!(first == null))
                    if (!(first.link == null))
                    {
                        HuffmanTree aTemp = RemoveTree();
                        HuffmanTree bTemp = RemoveTree();
                        HuffmanTree sumTemp = new HuffmanTree("x");
                        sumTemp.SetLeftChild(aTemp);
                        sumTemp.SetRightChild(bTemp);
                        sumTemp.SetFreq(aTemp.GetFreq() + bTemp.GetFreq());
                        InsertTree(sumTemp);
                    }
            }
            public HuffmanTree RemoveTree()
            {
                if (!(first == null))
                {
                    HuffmanTree hTemp;
                    hTemp = first.data;
                    first = first.link;
                    count--;
                    return hTemp;
                }
                return null;
            }
            public void InsertTree(HuffmanTree hTemp)
            {
                Node eTemp = new Node(hTemp);
                if (first == null)
                    first = eTemp;
                else
                {
                    Node p = first;
                    while (!(p.link == null))
                    {
                        if ((p.data.GetFreq() <= hTemp.GetFreq()) && (p.link.data.GetFreq() >= hTemp.GetFreq()))
                            break;
                        p = p.link;
                    }
                    eTemp.link = p.link;
                    p.link = eTemp;
                }
                count++;
            }
            public int Length()
            {
                return count;
            }
            /// <summary>
            /// link---Count
            /// </summary>
            /// <param name="str"></param>
            public void AddSign(string str)
            {
                if (first == null)
                {
                    AddLetter(str);
                    return;
                }
                Node tmp = first;
                while (tmp != null)
                {
                    if (tmp.data.GetSign() == str)
                    {
                        tmp.data.IncFreq();
                        return;
                    }
                    tmp = tmp.link;
                }
                AddLetter(str);
            }
            public static string Translate(string original)
            {
                string newStr = "";
                for (int i = 0; i <= original.Length - 1; i++)
                {
                    for (int j = 0; j <= signTable.Length - 1; j++)
                    {
                        if (original[i].ToString() == signTable[j])
                        {
                            newStr += keyTable[j];
                        }
                    }
                }
                return newStr;
            }
            private static int pos = 0;
            public static void MakeKey(HuffmanTree tree, string code)
            {
                if (tree.GetLeftChild() == null)
                {
                    signTable[pos] = tree.GetSign();
                    keyTable[pos] = code;
                    pos++;
                }
                else
                {
                    MakeKey(tree.GetLeftChild(), code + "0");
                    MakeKey(tree.GetRightChild(), code + "1");
                }
            }
        }
        public class HuffmanTree
        {
            private HuffmanTree leftChild;
            private HuffmanTree rightChild;
            private string letter;
            private int freq;
            public HuffmanTree(string letter)
            {
                this.letter = letter;
                this.freq = 1;
            }
            public void SetLeftChild(HuffmanTree newChild)
            {
                leftChild = newChild;
            }
            public void SetRightChild(HuffmanTree newChild)
            {
                rightChild = newChild;
            }
            public void SetLetter(string newLetter)
            {
                letter = newLetter;
            }
            public void IncFreq()
            {
                freq++;
            }
            public void SetFreq(int newFreq)
            {
                freq = newFreq;
            }
            public HuffmanTree GetLeftChild()
            {
                return leftChild;
            }
            public HuffmanTree GetRightChild()
            {
                return rightChild;
            }
            public int GetFreq()
            {
                return freq;
            }
            public string GetSign()
            {
                return letter;
            }
        }
        #endregion







    }









}
