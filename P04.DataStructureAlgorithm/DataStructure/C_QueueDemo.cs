using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04.DataStructureAlgorithm.DataStructure
{
    public class C_QueueDemo
    {
        public static void Show()
        {
            Console.WriteLine("***************Queue<T>******************");
            Queue<string> numbers = new Queue<string>();
            numbers.Enqueue("one");
            numbers.Enqueue("two");
            numbers.Enqueue("three");
            numbers.Enqueue("four");
            numbers.Enqueue("four");
            numbers.Enqueue("five");

            foreach (string number in numbers)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine($"Dequeuing '{numbers.Dequeue()}'");
            Console.WriteLine($"Peek at next item to dequeue: { numbers.Peek()}");
            Console.WriteLine($"Dequeuing '{numbers.Dequeue()}'");

            Queue<string> queueCopy = new Queue<string>(numbers.ToArray());
            foreach (string number in queueCopy)
            {
                Console.WriteLine(number);
            }

            //queueCopy.Capacity;
            queueCopy.TrimExcess();

            Console.WriteLine($"queueCopy.Contains(\"four\") = {queueCopy.Contains("four")}");
            queueCopy.Clear();
            Console.WriteLine($"queueCopy.Count = {queueCopy.Count}");
        }

    }

    //need to adjust size and 
    public class WeightQueue<T>
    {
        private T[] Items;
        private int _iIndex = 0;
        private int _iHead = 0;

        private class Entry
        {
            public int Weight { get; set; }
            public int iIndex { get; set; }
        }

        private Entry[] EntryArray;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <param name="weight">0  </param>
        public void Enqueue(T t, int weight = 0)
        {
            if (Items == null)
            {
                Items = new T[4];
            }
            Items[_iIndex] = t;//还要扩容
            if (weight > 0)
            {
                if (EntryArray == null)
                {
                    EntryArray = new Entry[4];
                    EntryArray[_iIndex] = new Entry()
                    {
                        iIndex = _iIndex,
                        Weight = weight
                    };//Extend space 
                }
            }
            _iIndex++;
        }

        public T Dequeue()
        {
            if (EntryArray == null)
            {
                throw new Exception();
            }
            Entry entry = this.EntryArray.OrderByDescending(e => e.Weight).First();
            T t;
            if (entry.Weight == 0)
            {
                t = Items[_iHead];
                Items[_iHead] = default(T);
            }
            else
            {
                t = Items[entry.iIndex];
                Items[entry.iIndex] = default(T); //Size ?
            }
            return t;
        }
    }




















}
