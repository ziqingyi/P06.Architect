using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace P04.DataStructureAlgorithm.DataStructure
{
    public class A_ArrayDemo
    {
        public static void Show()
        {
            {
                Console.WriteLine("***************Array******************");
                int[] intArray = new int[3];
                intArray[0] = 123;
                string[] stringArray = new string[] {"123", "234"};
            }
            {
                Console.WriteLine("***************Multidimensional Array******************");

                int[,] a = new int[3, 4]
                {
                    {0, 1, 2, 3},
                    {4, 5, 6, 7},
                    {8, 9, 10, 11}
                };
            }

            {
                Console.WriteLine("***************Jagged Array******************");
                int[][] a = new int[2][];
                a[0] = new int[] {1, 2, 3};
                a[1] = new int[] {2};
            }

            {

                Console.WriteLine("***************ArrayList******************");
                ArrayList arrayList = new ArrayList();
                arrayList.Add("E");
                arrayList.Add("Is");
                arrayList.Add(32);
                arrayList[4] = 26;

                //arrayList.RemoveAt(4);
                var value = arrayList[2];
                arrayList.RemoveAt(0);
                arrayList.Remove("E");

                {
                    ArrayList arrayList1 = new ArrayList();
                    arrayList1.Add("Eleven");
                    arrayList1.Add("Is");
                    Console.WriteLine(arrayList1.Capacity);
                    arrayList1.TrimToSize();
                    Console.WriteLine(arrayList1.Capacity);
                }
                {
                    ArrayList arrayList1 = new ArrayList(6);
                    arrayList1.Add("Eleven");
                    arrayList1.Add("Is");
                    arrayList1.Add("Eleven");
                    arrayList1.Add("Is");
                    Console.WriteLine(arrayList1.Capacity);
                    arrayList1.TrimToSize();
                    Console.WriteLine(arrayList1.Capacity);
                }
            }
            {
                //List:is Array, strongly typed list of objects that can be accessed by index
                // continusly in memory;
                //ach time you add an element to the list, it will first check whether the capacity has been reached
                //(i.e. whether the existing Count equals Capacity). If so, it will create a fresh array of twice the size
                //as the previous one, copy over all existing elements into it, and then proceed with writing the new element.
                //This will keep happening indefinitely on subsequent element additions, until the hard limit you referenced
                //(Int32.MaxValue) is reached.
                // Performance - wise, this means that the addition of an element is either an O(1) or an O(n) operation,
                // depending on whether the capacity needs to be increased(as discussed under Add).
                // However, since the capacity is doubled whenever it needs to increase, this reallocation happens with
                // exponentially decreasing frequency as the list grows larger.
                //fast in read--slow for adding and delete
                Console.WriteLine("***************List<T>******************");
                List<int> intList = new List<int>() {1, 2, 3, 4};
                intList.Add(123);
                intList.Add(123);
                //intList.Add("123");
                //intList[0] = 123;
                List<string> stringList = new List<string>();
                //stringList[0] = "123";//Exception

                {
                    List<int> intList1 = new List<int>() {1, 2, 3, 4, 5};
                    intList1.Add(123);
                    intList1.Add(123);
                    intList1.Add(123);
                    intList1.Add(123);
                    Console.WriteLine(intList1.Capacity);
                    intList1.TrimExcess();
                    Console.WriteLine(intList1.Capacity);
                }
                {
                    List<int> intList1 = new List<int>(3) {1, 2, 3, 4};
                    intList1.Add(123);
                    intList1.Add(123);
                    intList1.Add(123);
                    Console.WriteLine(intList1.Capacity);
                    //intList1.TrimToSize();
                    Console.WriteLine(intList1.Capacity);
                }
            }

            Console.WriteLine("***************End ofList<T>******************");
        }
    }
}
