using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithmStudy01
{
    /// <summary>
    /// 定容的字符串栈
    /// </summary>
    public class 定容字符串栈
    {
        public void Test01()
        {
            MyStringStack stack = new MyStringStack(20);
            string str = "to be or not to be - - - this - is - a question";
            string[] splitStr = str.Split(' ');
            foreach (var s in splitStr)
            {
                if (s == "-")
                {
                    stack.Pop();
                }
                else
                {
                    stack.Push(s);
                }
            }

            foreach (var item in stack.GetAll())
            {
                Console.WriteLine(item);
            }
        }

        public class MyStringStack
        {
            private string[] strArray;
            private int index;

            public MyStringStack(int cap)
            {
                strArray = new string[cap];
            }

            public bool IsEmpty => index == 0;
            public int Size => index;

            public void Push(string item)
            {
                strArray[index++] = item;
            }

            public string Pop()
            {
                return strArray[index--];
            }

            public IEnumerable<string> GetAll()
            {
                return strArray.Take(index);
            }
        }
    }
}