using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithmStudy01
{
    public class 下压链表堆栈
    {
        public void Test01()
        {
            MyLIFO<int> m = new MyLIFO<int>();
            m.Push(1);
            m.Push(2);
            m.Push(3);
            m.Push(4);
            m.Push(5);
            m.Pop();
            m.Push(6);
            foreach (var item in m)
            {
                Console.WriteLine(item);
            }
        }

        private class MyLIFO<T> : IEnumerable<T>
        {
            private class Node<T>
            {
                public T item;
                public Node<T> next;
            }

            private Node<T> first;
            private int n;

            public bool IsEmpty => n == 0 || first == null;
            public int Size => n;

            public void Push(T val)
            {
                Node<T> oldFirst = first;
                first = new Node<T>()
                {
                    item = val,
                    next = oldFirst
                };
                n++;
            }

            public T Pop()
            {
                T item = first.item;
                first = first.next;
                n--;
                return item;
            }

            public IEnumerator<T> GetEnumerator()
            {
                var temp = first;
                while (temp != null)
                {
                    yield return temp.item;
                    temp = temp.next;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}