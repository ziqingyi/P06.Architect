using System;
using System.Collections.Generic;
using System.Text;

namespace P04.DataStructureAlgorithm.DataStructure
{
    public class D_LinkedListDemo
    {
        public class LinkedListDemo
        {
            public static void Show()
            {
                #region MyRegion
                {
                    CustomStack<string> stack = new CustomStack<string>();
                    foreach (var item in "A-B-C-D".Split("-"))
                    {
                        stack.Push(item);
                    }

                    for (int i = 0; i < 3; i++)
                    {
                        Console.WriteLine(stack.Pop());
                        Console.WriteLine(stack.Peek());
                        Console.WriteLine(stack.Pop());
                    }
                }
                #endregion


                #region doubly linked list.

                LinkedList<string> link = new LinkedList<string>(); 
                LinkedListNode<string> node1 = new LinkedListNode<string>("E1"); 
                LinkedListNode<string> node2 = new LinkedListNode<string>("E2"); 
                LinkedListNode<string> node3 = new LinkedListNode<string>("E3");
                LinkedListNode<string> node4 = new LinkedListNode<string>("E4");

                link.AddFirst(node1); 
                link.AddAfter(node1, node2);
                link.AddAfter(node2, node3);
                link.AddAfter(node3, node4);

                Console.WriteLine(link.Count);

                LinkedListNode<string> current = link.First;
                while (current != null)
                {
                    Console.WriteLine(current.Value);
                    current = current.Next;
                }

                LinkedListNode<string> temp = link.Find("E2");
                if (temp != null)
                {
                    Console.WriteLine("the value is found in linked list" + temp.Value);
                }

                temp = link.Last;
                Console.WriteLine("The last value is" + temp.Value);

                link.RemoveFirst();
                link.Remove("E1");
                link.Clear();


                #endregion
            }

            private class CustomNode<T>
            {
                public T Element;
                public CustomNode<T> NextNode;
                public CustomNode()
                {
                    Element = default(T);
                    NextNode = null;
                }
                public CustomNode(T theElement)
                {
                    Element = theElement;
                    NextNode = null;
                }
            }
         
            private class CustomLinkedList<T>
            {
                private CustomNode<T> _CurrentHeader;
                public CustomLinkedList()
                {
                    this._CurrentHeader = new CustomNode<T>(default(T));
                }
                public CustomLinkedList(CustomNode<T> header)
                {
                    this._CurrentHeader = header;
                }
                public void Add(T t)
                {
                    CustomNode<T> node = new CustomNode<T>(t);
                    node.NextNode = _CurrentHeader;
                    _CurrentHeader = node;
                }
                public T GetAndRemove()
                {
                    T t = _CurrentHeader.Element;
                    CustomNode<T> node = _CurrentHeader.NextNode;
                    _CurrentHeader = node;
                    return t;
                }
                public T Get()
                {
                    T t = _CurrentHeader.Element;
                    return t;
                }
            }
            private class CustomStack<T>
            {
                private CustomLinkedList<T> _Container = new CustomLinkedList<T>();
                public void Push(T t)
                {
                    this._Container.Add(t);
                }
                public T Pop()
                {
                    return this._Container.GetAndRemove();
                }
                public T Peek()
                {
                    return this._Container.Get();
                }
            }

        }

    }
}
