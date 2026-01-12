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
    internal class Ex069 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 069: 使用StringBuilder提取括号中的值 ---");
            // 题目描述
            string line = "实现ExtractBracketedValues方法，接收一个stirng返回一个在[...]之间的substrings列表，即提取[...]中的值。通俗翻译：一个string中包含普通文本和用[]包裹的文本，这个方法要把string中用[]包裹的文本提取成list";
            Console.WriteLine(line);

            // 准备一些测试数据

            string str = "The [quick] brown [fox] [jumps] over [the lazy] dog.";

            // 调用你的逻辑方法
            var result1 = BracketExtractor.ExtractBracketedValues1(str);
            var result2 = BracketExtractor.ExtractBracketedValues1(str);
            // 输出结果
            foreach (var item in result1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            foreach (var item in result2)
            {
                Console.WriteLine(item);
            }
        }


        //题目知识：
        // 1. 提取字符串中的特定值，可以单纯用string，缺点是需要来回构建string，性能不好
        // 2. 使用stringbuilder可以只创建一个对象，通过clear方法能够清空这个对象，可以重复用
    }
    public static class BracketExtractor
    {
        public static List<string> ExtractBracketedValues1(string input)
        {
            List<string> result = new List<string>();
            var strings = input.Split(' ');
            foreach (var s in strings)
            {
                if (s.StartsWith('[') && s.EndsWith("]"))
                {
                    result.Add(s.Substring(1, s.Length - 2));
                }
            }
            return result;
        }
        public static List<string> ExtractBracketedValues2(string input)
        {
            List<string> result = new List<string>();
            StringBuilder stringBuilder = new StringBuilder();
            bool isInsideBrackets = false;
            foreach (var c in input)
            {
                if (c == '[')
                {
                    isInsideBrackets = true;
                }
                else if (isInsideBrackets && c == ']')
                {
                    isInsideBrackets = false;
                    result.Add(stringBuilder.ToString());
                    stringBuilder.Clear();
                }
                else if (isInsideBrackets)
                {
                    stringBuilder.Append(c);
                }
            }
            return result;
        }
    }

}
