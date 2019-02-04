using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithmStudy01
{
    public class 点点连接
    {
        public void Test01()
        {
            QuickFind qf = new QuickFind(10);
            int[] pArr = {4, 3, 6, 9, 2, 5, 7, 6};
            int[] qArr = {3, 8, 5, 4, 1, 0, 2, 1};
            for (int i = 0; i < pArr.Length; i++)
            {
                int p = pArr[i], q = qArr[i];
                if (qf.Connected(p,q))
                {
                    continue;
                }

                qf.Union(p, q);
                Console.WriteLine($"{p} {q}");
            }

            Console.WriteLine(qf.Count + " Components");
        }

        private class QuickFind
        {
            private int[] id;//分量id(以触点作为索引)
            private int count;//分量数量

            public QuickFind(int n)
            {
                count = n;
                id = new int[n];
                for (int i = 0; i < n; i++)
                {
                    id[i] = i;
                }
            }

            public int Count => count;

            /// <summary>
            /// 是否已经连接
            /// </summary>
            public bool Connected(int p, int q)
            {
                return Find(p) == Find(q);
            }

            /// <summary>
            /// 在相同触点返回索引
            /// </summary>
            /// <returns></returns>
            public int Find(int p)
            {
                return id[p];
            }

            /// <summary>
            /// 递归分量
            /// </summary>
            public void Union(int p, int q)
            {
                int pID = Find(p);
                int qID = Find(q);

                if (pID == qID)
                {
                    return;
                }

                for (int i = 0; i < id.Length; i++)
                {
                    if (id[i] == pID)
                    {
                        id[i] = qID;
                    }
                }

                count--;
            }

        }
    }
}
