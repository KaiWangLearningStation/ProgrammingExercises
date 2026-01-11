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
    internal class Ex063 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 063: 生成唯一单词，直到遇到重复项 ---");
            // 题目描述
            string line = "实现GetUniqueWords方法，接收string列表，按顺序yield每个独特的单词，当生成重复word时停止。使用惰性求值来生成";
            Console.WriteLine(line);

            // 准备一些测试数据
            List<string> words = new List<string>()
            {
                "apple","banana","apple","orange"
            };

            // 调用你的逻辑方法
            var result1 = GetUniqueWords1(words);
            var result2 = GetUniqueWords2(words);

            // 输出结果
            foreach ( var word in result1)
            {
                Console.WriteLine(word);
            }
            Console.WriteLine();
            foreach (var word in result2)
            {
                Console.WriteLine(word);
            }

        }
        public static IEnumerable<string> GetUniqueWords1(List<string> words)
        {
            if (words is null)
            {
                throw new ArgumentNullException();
            }
            HashSet<string> seenWords = new HashSet<string>();
            foreach (string word in words)
            {
                if (seenWords.Contains(word))
                {
                    yield break;
                }
                seenWords.Add(word);
                yield return word;
            }
        }
        public static IEnumerable<string> GetUniqueWords2(List<string> words)
        {
            if (words == null) throw new ArgumentNullException(nameof(words));

            HashSet<string> seen = new HashSet<string>();
            return words.TakeWhile(word => seen.Add(word));
        }

        //题目知识：
        // 1. 使用能够自动查重的数据结构是最佳选择，HashSet只能存放不重复的元素，是最佳选择
        // 2. Hashset 的Add方法是用来添加元素的，添加失败不会有异常，而是会返回false
        // 3. 如果不用Hashset，可以用Contains方法来判断是否已经添加过，例如Dictionary的Key中
        // 4. lazy惰性和 yield是搭档，yield返回的就是IEnumerable类型
        // 5. 返回值是IEnumerable，还应该想到的就是LINQ方法，TaksWhile方法也能把数据从一个List中取出来，然后用hashset的add可以添加，如果添加失败，返回false，这个linq也就恰好结束了，但是这个不符合lazy惰性

    }
}
