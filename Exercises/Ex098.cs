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
    internal class Ex098 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 098: 将单词列表中的变位词分组 ---");
            // 题目描述
            string line = "变位词anagrams是指重新排列原始单词的字母生成的单词列表，例如eat tea ate是一组变位词" +
                "实现GroupAnagrams方法，接收小写形式的word列表，返回一个变位词groups列表，列表每个元素包含一组变位词集合。";
            Console.WriteLine(line);

            // 准备一些测试数据

            List<string> words = new List<string>()
            {
                "eat","tea","tan","ate","nat","bat"
            };

            // 调用你的逻辑方法
            var result = AnagramGrouper.GroupAnagrams(words);

            // 输出结果
            foreach (var word in result)
            {
                foreach (var item in word)
                {
                    Console.Write($"{item} ");
                }
                Console.WriteLine();
            }
        }


        //题目知识：
        // 1. .GroupBy(word => new string(word.OrderBy(character => character).ToArray()))这个lambda表达式的目的就是：为每个单词生成一个唯一的"字母签名"，相同字母组成的单词会有相同的签名，不同字母组成的单词签名不同。
        // 2. Grouping对象使用ToList方法只保留除了key以外的部分
    }
    public static class AnagramGrouper
    {
        public static List<List<string>> GroupAnagrams(List<string> words)
        {
            return words
                .GroupBy(word => new string(word.OrderBy(character => character).ToArray()))
                .Select(group => group.ToList())
                .ToList();
        }
    }
}
