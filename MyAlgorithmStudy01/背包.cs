using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithmStudy01
{
    public class 背包
    {
        public void Test01()
        {
            Bag<int> bag = new Bag<int>();
            bag.Add(1);
            bag.Add(2);
            bag.Add(3);
            bag.Add(4);
            bag.Add(5);
            var temp = bag.GetIterator();
            while (temp.HasNext)
            {
                Console.WriteLine(temp.Now);
                temp.Next();
            }
        }


        private class Bag<T>
        {
            public class Node<T>
            {
                public T item;
                public Node<T> next;
            }

            public class ListIterator<T>
            {
                private Node<T> Current;

                public bool HasNext => Current != null;

                public T Now => Current.item;


                public ListIterator(Node<T> first)
                {
                    Current = first;
                }


                public bool Next()
                {
                    Current = Current.next;
                    return Current != null;
                }
            }

            private Node<T> first;
            public int Count { get; private set; }
            public bool IsEmpty => Count == 0;


            public void Add(T item)
            {
                Node<T> oldFirst = first;
                first = new Node<T>();
                first.item = item;
                first.next = oldFirst;
                Count++;
            }


            public ListIterator<T> GetIterator()
            {
                return new ListIterator<T>(first);
            }
        }
    }
}