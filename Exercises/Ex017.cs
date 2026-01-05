using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingExercises100.Exercises
{
    internal class Ex017 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 017: 读取到指定内容时停止 ---");
            // 题目描述
            string line = "请编写一个方法，接受一个字符串，如果读取到停止标识符则立刻停止，返回标识符之前的字符串，如果没有读取到，则返回完整字符串";
            Console.WriteLine(line);

            // 准备一些测试数据

            string test1 = "hello_world_END_EXTRA";
            string test2 = "hello_world_EXTRA";

            // 调用你的逻辑方法

            string result1 = ReadUntilEndMarker1(test1);
            string result2 = ReadUntilEndMarker2(test2);

            // 输出结果
            Console.WriteLine(result1);
            Console.WriteLine(result2);

        }

        //方法1 ：Split分割，如果成功分割则输出第一个，如果没有分割，也返回第一个
        public static string ReadUntilEndMarker1(string input)
        {
            string[] results = input.Split("_END_");
            return results[0];
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
