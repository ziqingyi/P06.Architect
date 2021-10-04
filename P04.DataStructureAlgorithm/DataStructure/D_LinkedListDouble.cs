using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04.DataStructureAlgorithm.DataStructure
{
    public class D_LinkedListDouble
    {
        static void show()
        {
            var test = new CSharpLinkedList<int>();
            var data = Enumerable.Range(1, 50).ToList();
            foreach (var i in data)
            {
                test.AddLast(i);
            }
            Console.WriteLine(test.Count);

            foreach (var i in data.Where(d => d % 2 == 0))
            {
                test.Remove(i);
            }
            Console.WriteLine(test.Count);

            test.Print();

            foreach (var i in data.Where(d => d % 3 == 0))
            {
                test.Remove(i);
            }
            Console.WriteLine(test.Count);

            test.Print();

            Console.ReadKey();
        }
    }

    //
    public class CSharpLinkedList<T> : IEnumerable<T>
    {
        //internal: avoid creation with head only and forget prev, next
        //head must be inserted by AddFirst or AddLast Method.
        internal CSharpLinkedListNode<T> head;

        //internal use, for count time complex calculation to n. 
        private int count;
        public int Count
        {
            get { return count; }
        }

        public CSharpLinkedListNode<T> First
        {
            get { return head; }
        }

        public CSharpLinkedListNode<T> Last
        {
            get
            {
                if (head != null)
                {
                    return head.prev;
                }
                return null;
            }
        }

        public CSharpLinkedList()
        {
        }


        #region Find
        public CSharpLinkedListNode<T> Find(T value)
        {
            var next = head;
            var comparer = EqualityComparer<T>.Default;
            if (next != null)
            {
                if (value != null)
                {
                    //For T compare,  use EqualityComparer
                    while (!comparer.Equals(next.item, value))
                    {
                        next = next.next;
                        //if next is head, it means this node is end.
                        if (next == head)
                        {
                            return null;
                        }
                    }
                    return next;
                }
                while (next.item != null)
                {
                    next = next.next;
                    if (next == head)
                    {
                        return null;
                    }
                }
                return next;
            }
            return null;
        }


        #endregion

        #region Add First and Last

        public void AddFirst(T value)
        {
            AddFirst(new CSharpLinkedListNode<T>(value));
        }
        public void AddFirst(CSharpLinkedListNode<T> node)
        {
            if (head == null)
            {
                InsertNodeToEmptyList(node);
            }
            else
            {
                InsertNodeBefore(head, node);
            }
        }
        public void AddLast(T value)
        {
            AddLast(new CSharpLinkedListNode<T>(value));
        }

        public void AddLast(CSharpLinkedListNode<T> node)
        {
            if (head == null)
            {
                InsertNodeToEmptyList(node);
            }
            else
            {
                InsertNodeBefore(head, node);
            }
        }

        #endregion


        #region add before, after
        public void AddBefore(CSharpLinkedListNode<T> node, CSharpLinkedListNode<T> newNode)
        {
            InsertNodeBefore(node, node);

            if (node == head)
            {
                head = newNode;
            }
        }

        public void AddAfter(CSharpLinkedListNode<T> node, CSharpLinkedListNode<T> newNode)
        {
            InsertNodeBefore(node.next, newNode);
        }


        #endregion


        #region Remove
       public void Remove(T value)
        {
            var node = Find(value);
            if (node != null)
            {
                Remove(node);
            }
        }
        public void Remove(CSharpLinkedListNode<T> node)
        {
            if (node.next == node)
            {
                head = null;
            }
            else
            {
                node.prev.next = node.next;
                node.next.prev = node.prev;

                if (node == head)
                {
                    head = head.next;
                }
            }
            node.Invalidate();
            count--;
        }

 

        #endregion






        #region Other

        internal void InsertNodeToEmptyList(CSharpLinkedListNode<T> node)
        {
            head = node;
            head.next = head;
            head.prev = head;
            count++;
        }
        internal void InsertNodeBefore(CSharpLinkedListNode<T> node, CSharpLinkedListNode<T> newNode)
        {
            newNode.next = node;
            newNode.prev = node.prev;
            node.prev.next = newNode;
            node.prev = newNode;
            count++;
        }
        public void Print()
        {
            var current = First;
            do
            {
                Console.Write(current.item.ToString());
                current = current.next;
                if (current != First)
                {
                    Console.Write("->");
                }
            } while (current != First);

            Console.Write("\n");
        }


        #endregion

        #region Enumerator
        public IEnumerator<T> GetEnumerator()
        {
            return new CSharpLinkedListEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }




        public class CSharpLinkedListEnumerator : IEnumerator<T>
        {
            private T current;
            public T Current
            {
                get { return current; }
            }

            object IEnumerator.Current
            {
                get { return current; }
            }

            private readonly CSharpLinkedList<T> list;

            private CSharpLinkedListNode<T> node;

            private int _position = -1;

            public CSharpLinkedListEnumerator(CSharpLinkedList<T> data)
            {
                list = data;
                node = list.head;
            }

            public bool MoveNext()
            {
                _position++;
                if (_position == list.count)
                {
                    return false;
                }

                current = node.item;
                node = node.next;
                return true;
            }

            //no need
            public void Reset()
            {
                throw new NotImplementedException();
            }

            //no need, C# will do
            public void Dispose()
            {
            }
        }
        #endregion






    }








    public class CSharpLinkedListNode<T>
    {
        //Internal, avoid modification externally. 
        internal CSharpLinkedListNode<T> next;
        internal CSharpLinkedListNode<T> prev;

        //value in the node
        public T item { get; set; }

        public CSharpLinkedListNode(T value)
        {
            item = value;
        }

        //invalidate the point
        public void Invalidate()
        {
            this.prev = null;
            this.next = null;
        }

    }
}
