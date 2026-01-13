using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingExercises100.Exercises
{
    internal class Ex079 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 079: 获取基本系统信息 ---");
            // 题目描述
            string line = "实现GetSystemInfo方法，返回SystemInfo record，包含OperatingSystem表示OS名称，ProcessorCount逻辑处理器数量，Is64BitProcess是否是64位处理器";
            Console.WriteLine(line);

            // 准备一些测试数据
            var result = SystemInspector.GetSystemInfo();


            // 调用你的逻辑方法


            // 输出结果
            Console.WriteLine(result.OperatingSystem);
            Console.WriteLine(result.ProcessorCount);
            Console.WriteLine(result.Is64BitProcess);
        }


        //题目知识：
        // 1. 获取操作系统类型需要用RuntimeInformation类的IsOSplatform方法，方法接收OSPlatform结构体，里面有Windows、Linux、OSX属性可以选择。可以用嵌套三元表达式来判断是否是其中一种操作系统
        // 2. 核心数量、是否是64位系统则通过Environment类来访问即可
    }
    public static class SystemInspector
    {
        public static SystemInfo GetSystemInfo()
        {
            string os =
                RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "Windows" :
                RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ? "Linux" :
                RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? "MacOS" :
                "Unknown";
            return new SystemInfo(os, Environment.ProcessorCount, Environment.Is64BitProcess);
        }
    }
    public record SystemInfo(string OperatingSystem, int ProcessorCount, bool Is64BitProcess);
}
