using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithmStudy01
{
    public class 排序
    {
        private void TestBase(SortBase s)
        {
            string[] a = new string[]
            {
                "bed", "bug", "dad", "yes", "zoo", "...", "all", "bad", "yet", "bug"
            };
            s.Sort(a);
            if (!s.IsSorted(a))
            {
                Console.WriteLine("排序失败");
                throw new Exception("排序失败");
            }

            s.Show(a);
        }

        public void Test01()
        {
            TestBase(new Selection());
        }

        public void Test02()
        {
            TestBase(new Insertion());
        }

        public void Test03()
        {
            String[] a = new String[]
            {
                "S", "H", "E", "L", "L", "S", "O", "R", "T", "E", "X", "A", "M", "P", "L", "E"
            };
            SortBase s = new Shell();
            s.Sort(a);
            if (!s.IsSorted(a))
            {
                Console.WriteLine("排序失败");
                throw new Exception("排序失败");
            }

            s.Show(a);
        }

        public void Test04()
        {
            String[] a = new String[]
            {
                "S", "H", "E", "L", "L", "S", "O", "R", "T", "E", "X", "A", "M", "P", "L", "E"
            };
            SortBase s = new UpToDownMerge();
            s.Sort(a);
            if (!s.IsSorted(a))
            {
                Console.WriteLine("排序失败");
                throw new Exception("排序失败");
            }

            s.Show(a);
        }

        public void Test05()
        {
            String[] a = new String[]
            {
                "S", "H", "E", "L", "L", "S", "O", "R", "T", "E", "X", "A", "M", "P", "L", "E"
            };
            SortBase s = new DownToUpMerge();
            s.Sort(a);
            if (!s.IsSorted(a))
            {
                Console.WriteLine("排序失败");
                throw new Exception("排序失败");
            }

            s.Show(a);
        }

        public void Test06()
        {
            String[] a = new String[]
            {
                "S", "H", "E", "L", "L", "S", "O", "R", "T", "E", "X", "A", "M", "P", "L", "E"
            };
            SortBase s = new QuickBase();
            s.Sort(a);
            if (!s.IsSorted(a))
            {
                Console.WriteLine("排序失败");
                throw new Exception("排序失败");
            }

            s.Show(a);
        }

        public void Test07()
        {
            String[] a = new String[]
            {
                "S", "H", "E", "L", "L", "S", "O", "R", "T", "E", "X", "A", "M", "P", "L", "E"
            };
            SortBase s = new Quick3Way();
            s.Sort(a);
            if (!s.IsSorted(a))
            {
                Console.WriteLine("排序失败");
                throw new Exception("排序失败");
            }

            s.Show(a);
        }

        /// <summary>
        /// 普通排序的基类
        /// </summary>
        private abstract class SortBase
        {
            public abstract void Sort(IComparable[] a);

            //v<=w = true
            public bool Less(IComparable v, IComparable w)
            {
                return v.CompareTo(w) < 0;
            }

            public void Swap(IComparable[] a, int i, int j)
            {
                IComparable t = a[i];
                a[i] = a[j];
                a[j] = t;
            }

            public void Show(IComparable[] a)
            {
                foreach (var item in a)
                {
                    Console.Write(item + " ");
                }

                Console.WriteLine();
            }

            public bool IsSorted(IComparable[] a)
            {
                for (int i = 1; i < a.Length; i++)
                {
                    if (Less(a[i], a[i - 1]))
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        /// <summary>
        /// 选择排序
        /// </summary>
        private class Selection : SortBase
        {
            public override void Sort(IComparable[] a)
            {
                int n = a.Length;
                for (int i = 0; i < n; i++)
                {
                    int min = i;
                    for (int j = i + 1; j < n; j++)
                    {
                        if (Less(a[j], a[min]))
                        {
                            min = j;
                        }
                    }

                    Swap(a, i, min);
                }
            }
        }

        /// <summary>
        /// 插入排序
        /// </summary>
        private class Insertion : SortBase
        {
            public override void Sort(IComparable[] a)
            {
                int n = a.Length;
                for (int i = 1; i < n; i++)
                {
                    for (int j = i; j > 0 && Less(a[j], a[j - 1]); j--)
                    {
                        Swap(a, j, j - 1);
                    }
                }
            }
        }

        /// <summary>
        /// 希尔排序
        /// </summary>
        private class Shell : SortBase
        {
            public override void Sort(IComparable[] a)
            {
                int n = a.Length;
                int h = 1; //h为步长,可以随意调节,下面的/3要记得,这里的基础步长为三分之一
                while (h < n / 3)
                {
                    h = 3 * h + 1; //1,4,13,40,121,364,1093,...
                }

                while (h >= 1)
                {
                    for (int i = h; i < n; i++)
                    {
                        for (int j = i; j >= h && Less(a[j], a[j - h]); j -= h)
                        {
                            Swap(a, j, j - h);
                        }
                    }

                    h /= 3;
                }
            }
        }

        /// <summary>
        /// 归并排序基类
        /// </summary>
        private abstract class MergeBase : SortBase
        {
            public IComparable[] aux;

            public override void Sort(IComparable[] a)
            {
                aux = new IComparable[a.Length];
                Sort(a, 0, a.Length - 1);
            }

            public virtual void Sort(IComparable[] a, int lo, int hi)
            {
            }

            public void Merge(IComparable[] a, int lo, int mid, int hi)
            {
                int i = lo, j = mid + 1;
                for (int k = lo; k <= hi; k++)
                {
                    aux[k] = a[k];
                }

                for (int k = lo; k <= hi; k++)
                {
                    if (i > mid)
                    {
                        a[k] = aux[j++];
                    }
                    else if (j > hi)
                    {
                        a[k] = aux[i++];
                    }
                    else if (Less(aux[j], aux[i]))
                    {
                        a[k] = aux[j++];
                    }
                    else
                    {
                        a[k] = aux[i++];
                    }
                }
            }
        }

        /// <summary>
        /// 自顶向下的归并排序
        /// </summary>
        private class UpToDownMerge : MergeBase
        {
            public override void Sort(IComparable[] a, int lo, int hi)
            {
                if (hi <= lo)
                {
                    return;
                }

                int mid = lo + (hi - lo) / 2;
                Sort(a, lo, mid);
                Sort(a, mid + 1, hi);
                Merge(a, lo, mid, hi);
            }
        }

        /// <summary>
        /// 自下而上归并排序
        /// </summary>
        private class DownToUpMerge : MergeBase
        {
            public override void Sort(IComparable[] a)
            {
                int n = a.Length;
                aux = new IComparable[n];
                for (int sz = 1; sz < n; sz *= 2)
                {
                    for (int lo = 0; lo < n - sz; lo += sz + sz)
                    {
                        Merge(a, lo, lo + sz - 1, Math.Min(lo + sz + sz - 1, n - 1));
                    }
                }
            }
        }

        /// <summary>
        /// 快速排序的基类
        /// </summary>
        private class QuickBase:SortBase
        {
            public override void Sort(IComparable[] a)
            {
                Sort(a, 0, a.Length - 1);
            }

            public virtual void Sort(IComparable[] a, int lo, int hi)
            {
                if (hi <= lo)
                {
                    return;
                }

                int j = Partition(a, lo, hi);
                Sort(a, lo, j - 1);
                Sort(a, j + 1, hi);
            }

            /// <summary>
            /// 快速排序切分用
            /// </summary>
            public int Partition(IComparable[] a, int lo, int hi)
            {
                int i = lo, j = hi + 1;
                IComparable v = a[lo];
                while (true)
                {
                    while (Less(a[++i], v))
                    {
                        if (i == hi)
                        {
                            break;
                        }
                    }

                    while (Less(v, a[--j]))
                    {
                        if (j == lo)
                        {
                            break;
                        }
                    }

                    if (i >= j)
                    {
                        break;
                    }

                    Swap(a, i, j);
                }

                Swap(a, lo, j);
                return j;
            }
        }

        /// <summary>
        /// 三分快速排序
        /// 在一样的元素过多的时候可以使用
        /// </summary>
        private class Quick3Way: QuickBase
        {
            public override void Sort(IComparable[] a, int lo, int hi)
            {
                if (hi <= lo)
                {
                    return;
                }

                int lt = lo, i = lo + 1, gt = hi;
                IComparable v = a[lo];
                while (i <= gt)
                {
                    int cmp = a[i].CompareTo(v);
                    if (cmp < 0)
                    {
                        Swap(a, lt++, i++);
                    }
                    else if(cmp>0)
                    {
                        Swap(a, i, gt--);
                    }
                    else
                    {
                        i++;
                    }
                }

                Sort(a, lo, lt - 1);
                Sort(a, gt + 1, hi);
            }
        }
    }
}