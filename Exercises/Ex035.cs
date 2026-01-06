using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingExercises100.Exercises
{
    internal class Ex035 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 035: 不适用内置方法反转字符串 ---");
            // 题目描述
            string line = "在不适用内置方法例如Reverse的情况下，反转字符串";
            Console.WriteLine(line);

            // 准备一些测试数据
            string str1 = "Hello ";
            Console.WriteLine(str1);
            Console.WriteLine(ReverseString1(str1));
            Console.WriteLine(ReverseString2(str1));
            Console.WriteLine(ReverseString3(str1));
            Console.WriteLine(ReverseString4(str1));
            Console.WriteLine(str1.Reverse());

            // 调用你的逻辑方法



            // 输出结果

        }

        private const int BasicGoodsTax = 7;
        private const int LuxuryGoodsExtraTax = 9;
        // 方法1（最常用）：使用 Array.Reverse()
        public static string ReverseString1(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                char[] chars = input.ToCharArray();
                chars.Reverse();
                return new string(chars);
            }

        }
        // 方法2（最简单）：使用 LINQ + new string()
        public static string ReverseString2(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                return new string(input.Reverse().ToArray()); //这里调用的是LINQ的Reverse方法，而不是Array的
            }

        }
        // 方法3（高性能，可修改）：使用 StringBuilder
        public static string ReverseString3(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException();
            }
            StringBuilder sb = new StringBuilder(input);   //可变字符串StringBuilder，在这个对象本身上面修改

            // 自定义反转方法
            for (int i = 0, j = sb.Length - 1; i < j; i++, j--)
            {
                char temp = sb[i];
                sb[i] = sb[j];
                sb[j] = temp;
            }

            string reversed = sb.ToString();  //不能直接返回StringBuilder对象

            return reversed;
        }

        // 方法4：手动实现，使用中间变量tmp
        public static string ReverseString4(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException();
            }

            char[] chars = input.ToCharArray();
            int length = chars.Length;
            for (int i = 0; i < length / 2; i++)
            {
                char tmp = chars[i];
                chars[i] = chars[length - i - 1];
                chars[length - i - 1] = tmp;
            }
            return new string(chars);
        }

        // 方法5：手动实现，利用string也能[]取char的特性，直接赋值
        public static string ReverseString5(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException();
            }

            char[] chars = new char[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                chars[i] = input[input.Length - i - 1];
            }
            return new string(chars);
        }

        //题目知识：
        // 1. return (string)input.Reverse();这样是错误的，因为不能把IEnumerable类型直接显式转换为string
        // 2. 常用的方法是把string转换为char Array，然后用Array的Reverse方法反转，然后再用new stirng构建回来
        // 3. StringBuilder中生成一个字符串构造对象，能够再这个对象内手动转化，这里使用了i和j两个索引，比较巧妙，很容易表达只遍历一半长度的概念
        // 4. 手动实现的时候也要转换为Array，然后遍历一半数组长度，使用tmp作为中转
        // 5. 使用拓展方法，StringExtensions类下写一个Reverse方法，方法中标明this string str，表明是string类型的拓展方法

    }
    // 方法6：定义扩展方法，然后在string后面直接调用Reverse方法
    public static class StringExtensions
    {
        public static string Reverse(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
