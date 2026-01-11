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
    internal class Ex064 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 064: 使用Stopwatch秒表测量方法执行时间 ---");
            // 题目描述
            string line = "在优化性能的时候，常用到Stopwatch秒表来计算方法执行的时间。实现一个MEasureExecutionTime方法，接收一个Action委托，执行这个方法，返回所消耗的毫秒时间";
            Console.WriteLine(line);

            // 准备一些测试数据

            List<int> ints = new List<int>();
            Action action = () =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    ints.Add(i);
                }
            };
            long result = PerformanceTimer.MeasureExecutionTime(action);

            // 调用你的逻辑方法


            // 输出结果
            Console.WriteLine(result);

        }


        //题目知识：
        // 1. Stopwatch sw = Stopwatch.StartNew()方法创建并直接开始时钟，等于先创建对象后，sw.Start();
        // 2. 时钟使用后，停止，如果再开始会累加时间如果要重置，需要reset方法

    }
    public static class PerformanceTimer
    {
        public static long MeasureExecutionTime(Action action)
        {
            Stopwatch sw = Stopwatch.StartNew();

            //sw.Start();
            action.Invoke();
            sw.Stop();

            return sw.ElapsedMilliseconds;
        }
    }
}
