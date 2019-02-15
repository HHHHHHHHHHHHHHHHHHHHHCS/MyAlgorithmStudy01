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
            UnionFind uf = new UnionFind(10);
            int[] pArr = {4, 3, 6, 9, 2, 5, 7, 6};
            int[] qArr = {3, 8, 5, 4, 1, 0, 2, 1};
            for (int i = 0; i < pArr.Length; i++)
            {
                int p = pArr[i], q = qArr[i];
                if (uf.Connected(p,q))
                {
                    continue;
                }

                uf.Union(p, q);
                Console.WriteLine($"{p} {q}");
            }

            Console.WriteLine(uf.Count + " Components");
        }

        public void Test02()
        {
            QuickUnionFind qf = new QuickUnionFind(10);
            int[] pArr = { 4, 3, 6, 9, 2, 5, 7, 6 };
            int[] qArr = { 3, 8, 5, 4, 1, 0, 2, 1 };
            for (int i = 0; i < pArr.Length; i++)
            {
                int p = pArr[i], q = qArr[i];
                if (qf.Connected(p, q))
                {
                    continue;
                }

                qf.Union(p, q);
                Console.WriteLine($"{p} {q}");
            }

            Console.WriteLine(qf.Count + " Components");
        }

        //普通的遍历
        private class UnionFind
        {
            private int[] id;//分量id(以触点作为索引)
            private int count;//分量数量

            public UnionFind(int n)
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
        
        //森林组成
        private class QuickUnionFind
        {
            private int[] id;//分量id(以触点作为索引)
            private int[] sz;//各个节点所对应的分量大小
            private int count;//分量数量

            public QuickUnionFind(int n)
            {
                count = n;
                id = new int[n];
                for (int i = 0; i < n; i++)
                {
                    id[i] = i;
                }

                sz = new int[n];
                for (int i = 0; i < n; i++)
                {
                    sz[i] = 1;
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
            {//跟随查找到根节点
                while (p != id[p])
                {
                    p = id[p];
                }
                return p;
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

                //由小数的根节点连接的大树的根节点
                if (sz[pID] < sz[qID])
                {
                    id[pID] = qID;
                    sz[qID] += sz[pID];
                }
                else
                {
                    id[qID] = pID;
                    sz[pID] += sz[qID];
                }

                count--;
            }
        }
    }
}
