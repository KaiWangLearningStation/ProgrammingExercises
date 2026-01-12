using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingExercises100.Exercises
{
    internal class Ex073 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 073: 从路径段segments分析文件路径 ---");
            // 题目描述
            string line = "实现AnalyzeFilePath方法，接收string数组路径，返回FilePathInfo对象，这个对象包含FullPath绝对路径，FileName文件名，Extension扩展名、Directory文件夹";
            Console.WriteLine(line);

            // 准备一些测试数据
            string[] segments = { "Users", "Alice", "Documents", "Wangkai.txt"  };


            // 调用你的逻辑方法
            var result = PathAnalyzer.AnalyzeFilePath(segments);

            // 输出结果
            Console.WriteLine($"{result.FullPath}");
            Console.WriteLine($"{result.FileName}");
            Console.WriteLine($"{result.Extension}");
            Console.WriteLine($"{result.Directory}");
        }


        //题目知识：
        // 1. Path类用来处理路径，Combine方法把数组拼接起来，使用适合该系统的连接符，例如win使用 \ 。注意文件名一定要包含拓展类型，否则会把单独的拓展类型看成是文件名
        // 2. GetFullPath方法，会自动填充exe程序所在位置的文件夹，作为绝对路径的一部分
        // 3. GetFileName方法，识别到最后一层\的内容，而不是真的能判断什么是文件名
        // 4. GetExtension方法，识别最后一层\的内容的从.开始的内容
        // 5. GetDirectoryName方法，返回除了文件名的前面的内容
    }
    public static class PathAnalyzer
    {
        public static FilePathInfo AnalyzeFilePath(string[] segments)
        {
            if (segments is null)
            {
                throw new ArgumentNullException();
            }
            var validSegments = segments
                .Where(segment => !string.IsNullOrEmpty(segment))
                .ToArray();
            if (validSegments.Length == 0)
            {
                throw new ArgumentException();
            }

            string combinedPath = Path.Combine(validSegments); // Users\Alice\Documents\Wangkai.txt

            string fullPath = Path.GetFullPath(combinedPath);
            string fileName = Path.GetFileName(fullPath);
            string extension = Path.GetExtension(fullPath);
            string? directory = Path.GetDirectoryName(fullPath);
            //D:\Software\CodeSoftware\IDE\Microsoft Visual Studio\2022\Default\100 Programming Exercises\bin\Debug\net8.0\Users\Alice\Documents\Wangkai.txt
            //Wangkai.txt
            //.txt
            //D:\Software\CodeSoftware\IDE\Microsoft Visual Studio\2022\Default\100 Programming Exercises\bin\Debug\net8.0\Users\Alice\Documents
            return new FilePathInfo(fullPath, fileName, extension, directory);
        }
    }
    public record FilePathInfo(string FullPath, string FileName, string Extension, string? Directory);
}
