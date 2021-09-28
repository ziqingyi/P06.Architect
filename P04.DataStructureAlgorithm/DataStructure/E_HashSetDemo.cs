using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04.DataStructureAlgorithm.DataStructure
{
    public class E_HashSetDemo
    {
        public static void Show()
        {
            #region Set
            {
                Console.WriteLine("***************HashSet<string>******************");
                HashSet<string> hashSet = new HashSet<string>();
                hashSet.Add("123");
                hashSet.Add("689");
                hashSet.Add("456");
                hashSet.Add("12435");
                hashSet.Add("12435");
                hashSet.Add("12435");
                //hashSet[0];
                foreach (var item in hashSet)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine(hashSet.Count);
                Console.WriteLine(hashSet.Contains("12345"));

                {
                    HashSet<string> hashSet1 = new HashSet<string>();
                    hashSet1.Add("123");
                    hashSet1.Add("689");
                    hashSet1.Add("789");
                    hashSet1.Add("12435");
                    hashSet1.Add("12435");
                    hashSet1.Add("12435");

                    hashSet1.IntersectWith(hashSet);
                    hashSet1.ExceptWith(hashSet);
                    hashSet1.UnionWith(hashSet);
                    hashSet1.SymmetricExceptWith(hashSet);
                }
                hashSet.ToList();
                hashSet.Clear();
            }
            {
                //ranking with distinct
                //ranking
                Console.WriteLine("***************SortedSet<string>******************");
                SortedSet<string> sortedSet = new SortedSet<string>();
                //IComparer<T> comparer  self defined comparer 
                sortedSet.Add("123");
                sortedSet.Add("689");
                sortedSet.Add("456");
                sortedSet.Add("12435");
                sortedSet.Add("12435");
                sortedSet.Add("12435");

                foreach (var item in sortedSet)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine(sortedSet.Count);
                Console.WriteLine(sortedSet.Contains("12345"));
                {
                    SortedSet<string> sortedSet1 = new SortedSet<string>();
                    sortedSet1.Add("123");
                    sortedSet1.Add("689");
                    sortedSet1.Add("456");
                    sortedSet1.Add("12435");
                    sortedSet1.Add("12435");
                    sortedSet1.Add("12435");

                    sortedSet1.IntersectWith(sortedSet);
                    sortedSet1.ExceptWith(sortedSet);
                    sortedSet1.UnionWith(sortedSet);
                    sortedSet1.SymmetricExceptWith(sortedSet);
                }

                sortedSet.ToList();
                sortedSet.Clear();
            }
            #endregion
        }

    }
}
