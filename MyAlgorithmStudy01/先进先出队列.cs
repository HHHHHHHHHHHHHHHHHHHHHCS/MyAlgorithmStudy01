using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithmStudy01
{
    public class 先进先出队列
    {
        public void Test01()
        {
            MyQueue<int> m = new MyQueue<int>();
            m.Enqueue(1);
            m.Enqueue(2);
            m.Enqueue(3);
            m.Enqueue(4);
            m.Enqueue(5);
            m.Dequeue();
            m.Enqueue(6);
            foreach (var item in m)
            {
                Console.WriteLine(item);
            }
        }

        private class MyQueue<T>:IEnumerable<T>
        {
            private class Node<T>
            {
                public T item;
                public Node<T> next;
            }

            private Node<T> first;
            private Node<T> last;
            private int n;

            public bool IsEmpty => n == 0 || first == null;
            public int Size => n;

            public void Enqueue(T val)
            {
                Node<T> oldLast = last;
                last = new Node<T>()
                {
                    item = val,
                    next = null
                };
                if (IsEmpty)
                {
                    first = last;
                }
                else
                {
                    oldLast.next = last;
                }

                n++;
            }

            public T Dequeue()
            {
                Node<T> item = first;
                first = first.next;
                n--;
                if (IsEmpty)
                {
                    last = null;
                }
                return item.item;
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
