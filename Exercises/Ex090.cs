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
    internal class Ex090 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 90: 展平并筛选锯齿字符串数组 ---");
            // 题目描述
            string line = "实现FlattenAndFilterWords方法，接收一个锯齿数组string[][]，和一个最小单词长度int。首先把锯齿数组展平成一个序列，去掉首位空格，筛选不小于长度的单词，返回一个去重的、按照字母表排序的剩余单词列表";
            Console.WriteLine(line);

            // 准备一些测试数据

            // 使用初始化器创建和初始化锯齿数组
            string?[][] words = new string?[][]
            {
                new string?[] { "apple", "banana", "cherry", "date",null },
                new string[] { "elephant", "fox", "       " },
                new string[] { "grape", "honeydew", "kiwi", "lemon", "mango" },
                new string[] { "north", "ocean", "planet" },
                new string[] { "quantum", "rainbow", "sun", "tree", "umbrella", "vortex", "water" }
            };


            // 调用你的逻辑方法
            var result = JaggedArrayUtils.FlattenAndFilterWords(words, 5);

            // 输出结果
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }


        //题目知识：
        // 1. 集合表达式可以缩减语法 new string[] { "apple", "banana", "cherry", "date" },简化为["apple", "banana", "cherry", "date"]只能用在数组、列表、和实现了ICollection/IList的类型
        // 2. 复合LINQ操作实例： selectmany如果不含内容时，会抛出异常，解决办法是用空接合操作符。如果不为空为左侧值，为空为右侧值
    }
    public static class JaggedArrayUtils
    {
        public static List<string> FlattenAndFilterWords(string[][] words, int minLength)
        {
            return words
                .SelectMany(word => word ?? Array.Empty<string>())
                .Select(word => word.Trim())
                .Where(word => !string.IsNullOrEmpty(word) && word.Length >= minLength)
                .Distinct()
                .OrderBy(word => word)
                .ToList();
        }
    }
}
