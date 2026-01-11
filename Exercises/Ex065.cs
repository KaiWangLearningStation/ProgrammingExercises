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
    internal class Ex065 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 065: 使用Span提取字符片段 ---");
            // 题目描述
            string line = "实现GetSlice方法，接收一个string和两个int分别是start和length，返回substring从start开始，长度为length";
            Console.WriteLine(line);

            // 准备一些测试数据

            string str = "Substring方法能按照开始index和长度进行切割\r\n        // 2. Span的性能更优，能够引用存储在堆栈数组甚至非托管内存中的数据，而无需创建额外副本。Span是处理连续内存块的轻量级且内存安全的方式，他提供的是原始数据的视图而非数据复制。在性能敏感场景中十分有用，例如处理大型字符串。\r\n        // 3. ReadOnlySpan<char> chars = input.AsSpan(start,length);不会创建新的字符串分配内存，而是原始数据的视图，仅在返回结果时将Span转换为字符串。当无需直接返回值的时候，即直接操作切片的时候，优势更能体现，在进行数据解析，比较、扫描的时候无需额外字符串。使用的时候注意参数验证，防止参数越界。";

            // 调用你的逻辑方法
            Console.WriteLine(SpanHelper.GetSlice1(str, 10, 20));
            Console.WriteLine(SpanHelper.GetSlice2(str, 10, 20));

            // 输出结果

        }


        //题目知识：
        // 1. Substring方法能按照开始index和长度进行切割
        // 2. Span的性能更优，能够引用存储在堆栈数组甚至非托管内存中的数据，而无需创建额外副本。Span是处理连续内存块的轻量级且内存安全的方式，他提供的是原始数据的视图而非数据复制。在性能敏感场景中十分有用，例如处理大型字符串。
        // 3. ReadOnlySpan<char> chars = input.AsSpan(start,length);不会创建新的字符串分配内存，而是原始数据的视图，仅在返回结果时将Span转换为字符串。当无需直接返回值的时候，即直接操作切片的时候，优势更能体现，在进行数据解析，比较、扫描的时候无需额外字符串。使用的时候注意参数验证，防止参数越界。
    }
    public static class SpanHelper
    {
        public static string GetSlice1(string input, int start, int length)
        {
            return input.Substring(start, length);
        }
        public static string GetSlice2(string input, int start, int length)
        {
            if (start < 0 || length < 0 || start + length > input.Length)
            {
                throw new ArgumentOutOfRangeException();
            }
            ReadOnlySpan<char> chars = input.AsSpan(start, length);
            return chars.ToString();
            // return new string(chars);
        }
    }
}
