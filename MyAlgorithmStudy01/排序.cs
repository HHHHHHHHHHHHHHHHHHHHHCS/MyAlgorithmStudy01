using System;
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
                "S","H","E","L","L","S","O","R","T","E","X","A","M","P","L","E"
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

        private abstract class SortBase
        {
            public abstract void Sort(IComparable[] a);

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
        private class Insertion:SortBase
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
                int h = 1;//h为步长,可以随意调节,下面的/3要记得,这里的基础步长为三分之一
                while (h < n / 3)
                {
                    h = 3 * h + 1;//1,4,13,40,121,364,1093,...
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
    }
}