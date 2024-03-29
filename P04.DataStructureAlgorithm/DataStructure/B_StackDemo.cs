﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P04.DataStructureAlgorithm.DataStructure
{
    public class B_StackDemo
    {
        public static void Show()
        {
            Console.WriteLine("***************Stack<T>******************");
            Stack<string> numbers = new Stack<string>();
            numbers.Push("one");
            numbers.Push("two");
            numbers.Push("three");
            numbers.Push("four");
            numbers.Push("five");

            foreach (string number in numbers)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine($"Pop '{numbers.Pop()}'");
            Console.WriteLine($"Peek at next item to dequeue: { numbers.Peek()}");
            Console.WriteLine($"Pop '{numbers.Pop()}'");

            Stack<string> stackCopy = new Stack<string>(numbers.ToArray());
            foreach (string number in stackCopy)
            {
                Console.WriteLine(number);
            }

            //stackCopy.Capacity;
            stackCopy.TrimExcess();

            Console.WriteLine($"stackCopy.Contains(\"four\") = {stackCopy.Contains("four")}");
            stackCopy.Clear();
            Console.WriteLine($"stackCopy.Count = {stackCopy.Count}");

            {

                BinaryConversion(4,2);

            }
            Console.WriteLine("***************End of Stack<T>******************");
        }


        private static void BinaryConversion(int number, int format)
        {
            Stack<int> targetStack = new Stack<int>();
            do
            {
                targetStack.Push(number % format);
                number = number / format;
            }
            while (number != 0);

            while (targetStack.Count > 0)
            {
                Console.Write(targetStack.Pop());
            }
        }


    }
}
