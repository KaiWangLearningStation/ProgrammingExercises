using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingExercises100.Exercises
{
    internal class Ex023 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 023: 检查括号是否平衡 ---");
            // 题目描述
            string line = "实现一个方法：判断字符串中括号是否成对（即括号平衡），如果平衡返回true，不平衡返回false";
            Console.WriteLine(line);

            // 准备一些测试数据

            string str1 = "(((((())))))";
            string str2 = "wankgi())))())";   //无意义的括号，应该算不平衡括号
            string str3 = "())))(((";   //无意义的括号，应该算不平衡括号

            // 调用你的逻辑方法

            bool b1 = AreParenthesesBalanced2(str1);
            bool b2 = AreParenthesesBalanced2(str2);
            bool b3 = AreParenthesesBalanced1(str3);

            // 输出结果
            Console.WriteLine(b1);
            Console.WriteLine(b2);
            Console.WriteLine(b3);

        }

        // 方法1：错误方法，只能判断括号是否是成对的，但是不能判断是否是有意义的括号
        public static bool AreParenthesesBalanced1(string expression)  
        {
            int left = expression.Count(item => item is '(');
            int right = expression.Count(item => item is ')');
            return left == right;
        }

        // 方法2：使用栈数据类型，每有一个左括号就push，每有一个右括号就pop，这样既能判断是否是成对的（最后的栈是否为空），又能判断是否是有意义的（即栈为空的时候如果再做pop操作，就证明没有意义，应该为不平衡）
        public static bool AreParenthesesBalanced2(string expression)
        {
            Stack<char> stack = new Stack<char>();
            foreach (char c in expression)
            {
                if (c == '(')
                {
                    stack.Push(c);
                }
                else if (c == ')')
                {
                    if (stack.Any())
                    {
                        stack.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            if (stack.Any())
            {
                return false ;
            }
            else
            {
                return true;
            }
        }


        //题目知识：
        // 1.检查括号是否平衡，不光是要判断是否数量相等，而还要判断是否括号是有意义的
        // 2.string.Count方法能够传入一个Func类型的委托，即有参数有返回值的委托，这里的参数是字符串的每个字符，判断其是否是符号(和)，如果是返回true，在true的情况下，count进行计数
        // 3.Any拓展方法，返回是否存在内容
        // 4.

            //if (stack.Any())
            //{
            //    return false ;
            //}
            //else
            //{
            //    return true;
            //}
            //可以替换为  return stack.Count() == 0;
    }


}
