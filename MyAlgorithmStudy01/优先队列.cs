using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithmStudy01
{
    public class 优先队列
    {
        public void Test01()
        {
            PriorityQueue<char> c = new PriorityQueue<char>(20);

            c.Push('A', 'B', 'C', 'F', 'G', 'I', 'I', 'Z');
            c.Push('B', 'D', 'H', 'P', 'Q', 'Q');
            c.Push('A', 'B', 'E', 'F', 'G', 'N');

            while (c.Count > 0)
            {
                Console.WriteLine(c.Pop());
            }
        }

        /// <summary>
        /// 优先队列,二叉树,top 是最大的
        /// </summary>
        private class PriorityQueue<T>
        {
            private IComparer<T> comparer;
            private T[] heap;

            public int Count { get; private set; }

            public PriorityQueue() : this(null)
            {
            }

            public PriorityQueue(int capacity) : this(capacity, null)
            {
            }

            public PriorityQueue(IComparer<T> comparer) : this(16, comparer)
            {
            }

            public PriorityQueue(int capacity, IComparer<T> comparer)
            {
                this.comparer = comparer ?? Comparer<T>.Default;
                this.heap = new T[capacity];
            }

            public void Push(T v)
            {
                if (Count >= heap.Length)
                {
                    Array.Resize(ref heap, Count * 2);
                }

                heap[Count] = v;
                SiftUp(Count++);
            }

            public void Push(params T[] vals)
            {
                foreach (var item in vals)
                {
                    Push(item);
                }
            }

            public T Pop()
            {
                var v = Top();
                heap[0] = heap[--Count];
                if (Count > 0) SiftDown(0);
                return v;
            }

            public T Top()
            {
                if (Count > 0) return heap[0];
                throw new InvalidOperationException("优先队列为空");
            }

            void SiftUp(int n)
            {
                var v = heap[n];
                for (var n2 = n / 2; n > 0 && comparer.Compare(v, heap[n2]) > 0; n = n2, n2 /= 2)
                {
                    heap[n] = heap[n2];
                }

                heap[n] = v;
            }

            void SiftDown(int n)
            {
                var v = heap[n];
                for (var n2 = n * 2; n2 < Count; n = n2, n2 *= 2)
                {
                    if (n2 + 1 < Count && comparer.Compare(heap[n2 + 1], heap[n2]) > 0)
                    {
                        n2++;
                    }

                    if (comparer.Compare(v, heap[n2]) >= 0)
                    {
                        break;
                    }

                    heap[n] = heap[n2];
                }

                heap[n] = v;
            }
        }

        /*//错误的示范

        public void Test01()
        {
            MaxPQBase<char> c = new MaxPQBase<char>(20);

            //c.Insert('A', 'B', 'C', 'F', 'G', 'I', 'I', 'Z');
            //c.Insert('B', 'D', 'H', 'P', 'Q', 'Q');
            c.Insert('A', 'B', 'E', 'F', 'G', 'N');

            c.Foreach(Console.WriteLine);
        }


        /// <summary>
        /// 优先队列基类,完全二叉树
        /// </summary>
        /// <typeparam name="T"></typeparam>
        private class MaxPQBase<T> where T:IComparable
        {
            private T[] pq; //基于堆的完全二叉树
            private int n = 0; //储存于pq[1...n],pq[0]不使用

            public int Size => n;
            public Boolean IsEmpty => n == 0;

            public MaxPQBase(int max)
            {
                pq = new T[max + 1];
            }

            /// <summary>
            /// 多个插入
            /// </summary>
            /// <param name="vals"></param>
            public void Insert(params T[] vals)
            {
                foreach (var item in vals)
                {
                    Insert(item);
                }
            }

            /// <summary>
            /// 插入
            /// </summary>
            /// <param name="val"></param>
            public void Insert(T val)
            {
                pq[++n] = val;
                Swim(n);
            }

            /// <summary>
            /// 删除最后的
            /// </summary>
            /// <returns></returns>
            public T DelMax()
            {
                T max = pq[1]; //从根节点得到最大的元素
                Swap(1, n--); //将其和最后一个节点交换
                pq[n + 1] = default(T); //置空,防止越界
                Sink(1); //恢复堆的有序性
                return max;

            }

            /// <summary>
            /// 比较
            /// </summary>
            private bool Less(int i, int j)
            {
                return pq[i].CompareTo(pq[j]) < 0;
            }

            /// <summary>
            /// 交换
            /// </summary>
            private void Swap(int i, int j)
            {
                T t = pq[i];
                pq[i] = pq[j];
                pq[j] = t;
            }

            /// <summary>
            /// 堆的有序化上浮
            /// </summary>
            private void Swim(int k)
            {
                while (k > 1 && Less(k / 2, k))
                {
                    Swap(k / 2, k);
                    k /= 2;
                }
            }

            /// <summary>
            /// 堆的有序化下沉
            /// </summary>
            /// <param name="k"></param>
            private void Sink(int k)
            {
                while (2 * k <= n)
                {
                    int j = 2 * k;
                    if (j < n && Less(j, j + 1))
                    {
                        j++;
                    }

                    if (!Less(k, j))
                    {
                        break;
                    }

                    Swap(k, j);
                    k = j;
                }
            }

            public void Foreach(Action<T> act)
            {
                foreach (var item in pq)
                {
                    act(item);
                }
            }
        }
        */
    }
}