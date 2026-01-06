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
    internal class Ex033 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 033: 生成斐波那契数列 ---");
            // 题目描述
            string line = "Fibonacci斐波那契数列 是一个数字序列，其中每个数字是前两个数字之和，通常起始于 0 和 1，从而产生一个像 0, 1, 1, 2, 3, 5, 8 等等的序列。你的任务是实现 GetFibonacciSequence 方法，以生成直到指定上限的斐波那契数字（从 0, 1 开始），如果上限为负数或数字超过上限，则立即停止。该方法接受一个整数上限，并返回一个包含该序列的 IEnumerable<int>。需要一个数学工具来生成直到给定上限的斐波那契数列，作为一个可以在 foreach 循环中惰性求值的迭代器方法（使用 yield 在这里至关重要）。";
            Console.WriteLine(line);

            // 准备一些测试数据
            int cap1 = 0;
            int cap2 = 1;
            int cap3 = 10;
            int cap4 = 20;


            // 调用你的逻辑方法

            IEnumerable<int> result1 = GetFibonacciSequence2(cap1);
            IEnumerable<int> result2 = GetFibonacciSequence2(cap2);
            IEnumerable<int> result3 = GetFibonacciSequence2(cap3);
            IEnumerable<int> result4 = GetFibonacciSequence2(cap4);

            // 输出结果
            foreach (var item in result1)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            foreach (var item in result2)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            foreach (var item in result3)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            foreach (var item in result4)
            {
                Console.Write($"{item} ");
            }
        }

        // 方法1：循环法，不能实现惰性求值lazily evaluated，没有使用yield return
        public static IEnumerable<int> GetFibonacciSequence1(int cap)
        {
            if (cap < 0)
            {
                return Enumerable.Empty<int>();
            }

            List<int> fibonacci = new List<int>();

            if (cap >= 0)
            {
                fibonacci.Add(0);
            }
            if (cap >= 1)
            {
                fibonacci.Add(1);
            }

            while (true)
            {
                if (fibonacci.Count == 1)
                {
                    return fibonacci;
                }
                int next = fibonacci[fibonacci.Count - 2] + fibonacci[fibonacci.Count - 1];
                if (next > cap)
                    break;
                else
                    fibonacci.Add(next);
            }
            return fibonacci;
        }
        // 方法2：使用yield return 返回IEnumerable类型的值
        public static IEnumerable<int> GetFibonacciSequence2(int cap)
        {
            int previous = 0;
            int current = 1;

            while (previous <= cap)
            {
                yield return previous;
                
                int tmp = previous + current;
                previous = current;
                current = tmp;
            }
        }


        //题目知识：
        // 1. 斐波那契数列如果用循环生成比较困难，需要定义好第一个元素和第二个元素，后续的元素可以通过循环实现
        // 2. 使用yield return可以逐个返回值，最后生成一个IEnumerable<T>的集合，斐波那契可以定义一个previous和current变量，用来循环，只要满足previous小于等于cap，就能yield return，然后用中间值把这previous和current向后移动一位即可。逻辑清晰，代码易读。

    }
}
