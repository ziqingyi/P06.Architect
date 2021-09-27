using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace P04.DataStructureAlgorithm.DataStructure
{
    public class D_LinkedListDemo
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

                while(stack.Count> 0)
                { 
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

        #region singly linked list  with stack
        private class CustomNode<T>
        {
            public T element;
            public CustomNode<T> nextNode;
            public CustomNode()
            {
                element = default(T);
            }

            public CustomNode(T theElement)
            {
                element = theElement;
            }
        }

        private class CustomLinkedList<T>
        {
            private CustomNode<T> _header;
            internal int _count;

            public int Count
            {
                get
                {
                    return _count;
                }
            }
            public CustomLinkedList()
            {
                this._header = new CustomNode<T>();
                _count = 1;
            }

            public CustomLinkedList(CustomNode<T> header)
            {
                this._header = header;
                _count = 1;
            }

            public void Add(T t)
            {
                CustomNode<T> node = new CustomNode<T>(t);
                node.nextNode = _header;
                this._header = node;

                _count++;
            }

            public T GetAndRemove()
            {
                //get element and header point to next
                T t = _header.element;

                _header = _header.nextNode;

                _count--;
                return t;
            }

            public T Get()
            {
                if (_count > 0)
                {
                    return _header.element;
                }
                else
                {
                    return default(T);
                }
            }


        }
        private class CustomStack<T>
        {
            public CustomLinkedList<T> _container = new CustomLinkedList<T>();

            public int Count
            {
                get { return _container.Count; }
            }


            public void Push(T t)
            {
                this._container.Add(t);
            }

            public T Pop()
            {
                return this._container.GetAndRemove();
            }

            public T Peek()
            {
                return this._container.Get();
            }
        }



        #endregion

    }
}
