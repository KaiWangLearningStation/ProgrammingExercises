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
    internal class Ex089 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 089: 使用Func和Action转换并记录数字列表 ---");
            // 题目描述
            string line = "实现TransformAndLog方法，接收一个int列表，一个transformation function Func<int,int>,一个logging action Action<int,int>。 把Func应用在每个元素上，用Action记录Log原始值和转换后的值。返回类型是转化后的int列表";
            Console.WriteLine(line);

            // 准备一些测试数据

            Func<int, int> Transform = (int x) => x * x;
            Action<int, int> Logging = (int x, int y) => Console.WriteLine($"Original: {x}, Transformed: {y}");
            List<int> ints = new List<int>() { 1, 2, 3, 4, 5, 6 };

            // 调用你的逻辑方法
            var result = FuncAndAction.TransformAndLog1(ints, Transform, Logging);

            // 输出结果
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }


        //题目知识：
        // 1. 平常都是在使用传入委托的方法，现在是在定义传入委托的方法。Func方法是一个函数方法，有输入参数有返回值，最后一个是返回值。Action方法是一个动作，有输入参数但是没有返回值，只是完成了一个动作。
        // 2. 一次循环可以做到两个事情的时候，就要避免多次循环，例如方法2中的样子。
    }
    public static class FuncAndAction
    {
        public static List<int> TransformAndLog1(List<int> numbers, Func<int, int> transform, Action<int, int> log)
        {
            List<int> result = new List<int>();
            foreach (var item in numbers)
            {
                result.Add(transform(item));
            }

            for (int i = 0; i < result.Count; i++)
            {
                log(numbers[i], result[i]);
            }
            return result;
        }
        public static List<int> TransformAndLog2(List<int> numbers, Func<int, int> transform, Action<int, int> log)
        {
            List<int> result = new List<int>();
            foreach (var item in numbers)
            {
                int transformed = transform(item);
                log(item, transformed);
                result.Add(transformed);
            }
            return result;
        }
    }
}
