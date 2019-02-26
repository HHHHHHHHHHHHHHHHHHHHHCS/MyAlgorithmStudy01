using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithmStudy01
{
    public class 优先队列
    {

        /// <summary>
        /// 优先队列基类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        private abstract class MaxPQBase<T> where T:IComparable
        {
            private T[] pq; //基于堆的完全二叉树
            private int n = 0; //储存于pq[1...n],pq[0]不使用

            public int Size => n;
            public Boolean IsEmpty => n == 0;

            public MaxPQBase(int max)
            {
                pq = new T[max];
            }

            /// <summary>
            /// 插入
            /// </summary>
            /// <param name="val"></param>
            public void Insert(T val)
            {
                pq[++n] = val;

            }

            /// <summary>
            /// 删除最后的
            /// </summary>
            /// <returns></returns>
            public T DelMax()
            {
                T max = pq[1]; //从根节点得到最大的元素
                Swap(1, n--); //将其和最后一个节点交换
                pq[n + 1] = default(T); //防止越界
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
        }
    }
}
