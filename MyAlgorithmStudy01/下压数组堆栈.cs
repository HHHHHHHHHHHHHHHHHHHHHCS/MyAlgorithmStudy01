using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithmStudy01
{
    public class 下压数组堆栈
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

        private class MyLIFO<T> :IEnumerable<T>

        {
            private T[] array;
            private int N = 0;
            public bool IsEmpty => N == 0;
            public int Size => N;

            public MyLIFO(int length = 1)
            {
                array = new T[length];
            }

            private void Resize(int max)
            {
                T[] temp = new T[max];
                for (int i = 0; i < N; i++)
                {
                    temp[i] = array[i];
                }

                array = temp;
            }

            public void Push(T item)
            {
                if (N == array.Length)
                {
                    Resize(array.Length << 1);
                }

                array[N++] = item;
            }

            public T Pop()
            {
                T item = array[--N];
                array[N] = default(T);
                if (N > 0 && N == array.Length / 4)
                {
                    Resize(array.Length / 2);
                }

                return item;
            }

            public IEnumerator<T> GetEnumerator()
            {
                for (int i = 0; i < N; i++)
                {
                    yield return array[i];
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}