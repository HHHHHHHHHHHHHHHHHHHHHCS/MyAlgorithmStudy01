using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithmStudy01
{
    public class 排序
    {
        public void Test01()
        {
            string[] a = new string[]
            {
                "bed", "bug", "dad", "yes", "zoo", "...", "all", "bad", "yet", "bug"
            };
            Selection s = new Selection();
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
    }
}