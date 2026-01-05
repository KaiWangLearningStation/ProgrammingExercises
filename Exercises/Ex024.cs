using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingExercises100.Exercises
{
    internal class Ex025 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 025: 静态构造函数练习 ---");
            // 题目描述
            string line = "一个日志系统需要通过为每条消息分配唯一 ID 来跟踪它已处理的消息数量。Logger 类使用一个静态字段（_logCounter）来统计日志条目数量。你的任务是：实现一个静态构造函数，将 _logCounter 初始化为 1。在你的解决方案中使用提供的静态字段（_logCounter）。实现静态方法 Log，用于输出每条消息及其用括号括起来的 ID（例如 [i] Message）。每次调用 Log 时，应递增计数器，以便下一条消息获得下一个 ID。";
            Console.WriteLine(line);

            // 准备一些测试数据
            Logger.Log("test1");
            Logger.Log("test2");
            Logger.Log("test3");


            // 调用你的逻辑方法



            // 输出结果


        }


        //题目知识：
        // 1.静态类中可以有静态构造函数，在不需要创建实例的情况下，就能进行一些初始化操作，在CLR加载这个静态类的时候，静态构造函数就执行了，如果程序不执行这个类名相关的代码，就不会执行静态构造函数


    }
    public static class Logger
    {
        private static int _logCounter;

        static Logger()
        {
            _logCounter = 1;
        }

        public static void Log(string message)  //Log方法，输出每条消息时附带唯一ID，且每次ID递增
        {
            Console.WriteLine($"[{_logCounter}] {message}");
            _logCounter++;
        }
        public static void ResetCounter()
        {
            _logCounter = 1;
        }
    }


}
