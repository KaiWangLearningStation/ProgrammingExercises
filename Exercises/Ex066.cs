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
    internal class Ex066 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 066: 使用ValueTuple返回结果而非匿名对象 ---");
            // 题目描述
            string line = "实现AnalyzeSentence方法，接收string，返回一个命名的ValueTuple元组带有两个值：WordCount和LongestWord（如果长度相等返回第一个）";
            Console.WriteLine(line);

            // 准备一些测试数据
            string str = "这是一个 包含各种空白字符\t的字符串示例。\r\n这里使用了：\n1. 空格' '\n2. 制表符'\\t'\n3. 回车符'\\r'\n4. 换行符'\\n'\r\n\t- 缩进使用制表符\n  - 缩进使用空格";


            // 调用你的逻辑方法
            var result = TextAnalyzer.AnalyzeSentence(str);

            // 输出结果
            Console.WriteLine(result.WordCount);
            Console.WriteLine(result.LogestWord);

        }


        //题目知识：
        // 1. 元组作为返回类型也要加上括号
        // 2. split方法能拆分字符串，可以传入多个字符，因为params的缘故。Split除了第一个传入seperators数组，还能传入split选项，RemoveEmptyEntries能够取出重复空格
        // 3. 数组能用LINQ，使用OrderByDescending可以从大到小排序，传入的是Func，入参是数组的每个元素，返回值是每个元素的长度，即可排序，然后用first可以取第一个元素。
    }

    public static class TextAnalyzer
    {
        public static (int WordCount, string LogestWord) AnalyzeSentence(string sentence)
        {
            if (sentence is null)
            {
                throw new ArgumentNullException();
            }

            var separators = new[] { ' ', '\t', '\r', '\n' };
            string[] words = sentence.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            int WordCount = words.Length;
            string LogestWord = WordCount == 0? string.Empty : words
                .OrderByDescending(word => word.Length)
                .First();
            return (WordCount, LogestWord);
        }
    }
}
