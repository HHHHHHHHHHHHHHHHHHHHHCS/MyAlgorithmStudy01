using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithmStudy01
{
    /// <summary>
    /// 用Dijkstra双栈算数表达式 求职
    /// </summary>
    public class Dijkstra双栈算数表达式
    {
        public void Test01()
        {
            string str;
            // str = Console.ReadLine();
            str = "(1 + 2 +3)";
            Console.WriteLine(Calc(str));
            str = "(sqrt((1+ 2)) -((3*4)/5))";
            Console.WriteLine(Calc(str));
        }

        public static double Calc(string str)
        {
            Stack<char> ops = new Stack<char>();
            Stack<double> vals = new Stack<double>();
            char op;
            double val;
            string temps = string.Empty;
            for (int i = 0; i < str.Length; i++)
            {
                op = str[i];
                switch (op)
                {
                    case ' ':
                    case '(':
                    {
                        break;
                    }
                    case '+':
                    case '-':
                    case '*':
                    case '/':
                    {
                        ops.Push(op);
                        break;
                    }
                    case 's' when str.Substring(i, 4) == "sqrt":
                    {
                        i += 3;
                        ops.Push('s');
                        break;
                    }
                    case ')':
                    {
                        op = ops.Pop();
                        val = vals.Pop();
                        switch (op)
                        {
                            case '+':
                            {
                                val = vals.Pop() + val;
                                break;
                            }
                            case '-':
                            {
                                val = vals.Pop() - val;
                                break;
                            }
                            case '*':
                            {
                                val = vals.Pop() * val;
                                break;
                            }
                            case '/':
                            {
                                val = vals.Pop() / val;
                                break;
                            }
                            case 's':
                            {
                                val = Math.Sqrt(val);
                                break;
                            }
                        }

                        vals.Push(val);
                        break;
                    }
                    default:
                    {
                        for (int k = i; k < str.Length; k++)
                        {
                            op = str[k];
                            if (('0' <= op && op <= '9') || op == '.')
                            {
                                temps += op;
                            }
                            else
                            {
                                vals.Push(double.Parse(temps));
                                temps = string.Empty;
                                break;
                            }
                        }

                        break;
                    }
                }
            }

            return vals.Pop();
        }
    }
}