using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingExercises100.Exercises
{
    internal class Ex019 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 019: 计算多少次除以2后会小于1 ---");
            // 题目描述
            string line = "请编写一个方法，接受一个double值，返回经过多少次除以2后小于1，即使一开始就为负数，也需要执行一次除以2";
            Console.WriteLine(line);

            // 准备一些测试数据

            double test1 = -1.546;
            double test2 = 10.125;

            // 调用你的逻辑方法

            int result1 = CountHalvings(test1);
            int result2 = CountHalvings(test2);

            // 输出结果
            Console.WriteLine(result1);
            Console.WriteLine(result2);

        }

        //方法1 ：Split分割，如果成功分割则输出第一个，如果没有分割，也返回第一个
        public static int CountHalvings(double value)
        {
            int count = 0;
            do
            {
                value /= 2;
                count++;
            } while (value >= 1);
            return count;
        }

        //方法2 ：IndexOf取索引，如果是一个字符串的索引，是第一位的索引，如果找不到返回-1。然后用substring取子字符串，左闭右开
        public static string ReadUntilEndMarker2(string input)
        {
            int index = input.IndexOf("_END_");
            if (index >= 0)
            {
                return input.Substring(0, index);
            }
            return input;
        }

        //方法3 ：可以加一个Contains判断，如果包含返回bool true，不包含返回false，实际上有点冗余了
        public static string ReadUntilEndMarker3(string input)
        {
            if (input.Contains("_END_"))
            {
                string[] results = input.Split("_END_");
                return results[0];
            }
            return input;
        }


        //题目知识：
        // 1.Split分割的结果，是把分割符去掉，然后前后进行分割，返回的是string[]数组
        // 2.IndexOf取索引，如果是一个字符串的索引，是第一位的索引，如果找不到返回-1。然后用substring取子字符串，左闭右开
        // 3.Contains返回bool值，包含为true

    }

}
