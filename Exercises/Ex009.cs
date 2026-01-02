using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingExercises100.Exercises
{
    internal class Ex009 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 009: 检查一个string是否是回文字符串palindorme ---");
            // 题目描述
            string line = "请编写一个方法，传入一个string，判断string是否符合回文字符串palindorme，如果是，返回true，不是则返回false";
            Console.WriteLine(line);

            // 准备一些测试数据
            string str1 = "abccba";
            string str2 = "abcba";
            string str3 = "abc ,, cba";
            string str4 = "1234";

            // 调用你的逻辑方法
            bool b1 = IsPalindorme(str1);
            bool b2 = IsPalindorme(str2);
            bool b3 = IsPalindorme(str3);
            bool b4 = IsPalindorme(str4);

            // 输出结果
            Console.WriteLine(b1);
            Console.WriteLine(b2);
            Console.WriteLine(b3);
            Console.WriteLine(b4);

        }



        //方法1：遍历到中点
        public static bool IsPalindorme(string input)
        {
            int length = input.Length;
            //空字符串通常被认为是回文字符串
            for (int i = 0; i < length / 2; i++)  //不用判断奇数偶数，只要循环到length/2之前，例如6：循环到0 1 2   5：循环到0 1
            {
                if (input[i] != input[length - 1 - i])
                {
                    return false;
                }
            }
            return true;
        }

        //方法2：使用IndexFromEnd Operator 索引从后开始操作符 ^
        public static bool IsPalindorme1(string input)
        {
            int length = input.Length;
            for (int i = 0; i < length / 2; i++)  
            {
                if (input[i] != input[^(i+1)])   //使用IndexFromEnd Operator 索引从后开始操作符
                {
                    return false;
                }
            }
            return true;
        }

        //方法3：使用SequenceEqual方法
        public static bool IsPalindorme2(string input)
        {
            return input.SequenceEqual(input.Reverse());
        }


        //题目知识：
        // 1. 回文遍历不用分奇数偶数，只需要遍历到Length / 2
        // 2. 可以使用IndexFromEnd Operator 索引从后开始操作符，也是遍历到Length / 2
        // 3. 可以使用SequenceEqual来进行元素级比较，Reverse方法能直接反转字符串，低效
    }


}
