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
    internal class Ex075 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 075: 使用可空引用类型从列表中过滤空字符串 ---");
            // 题目描述
            string line = "实现RemoveNulls方法，接收string列表，一些可能是null，返回一个非空列表";
            Console.WriteLine(line);

            // 准备一些测试数据

            List<string?> input = new List<string?>() { "wangkai", "w", null };

            // 调用你的逻辑方法
            var result1 = StringFilter.RemoveNulls1(input);
            var result2 = StringFilter.RemoveNulls2(input);

            // 输出结果
            foreach ( var item in result1)
            {
                Console.WriteLine(item);
            }

            foreach (var item in result2)
            {
                Console.WriteLine(item);
            }
        }


        //题目知识：
        // 1. 可空类型只在编译器中有用，提示可空信息，对程序本身没有任何影响
        // 2. Cast方法可以强制转换类型，在确保没有null的时候，可以把可空类型转换为非空类型
    }
    public static class StringFilter
    {
        public static List<string> RemoveNulls1(List<string?> input)
        {
            if (input is null)
            {
                throw new ArgumentNullException();
            }

            List<string> result = new List<string>();
            foreach (var item in input)
            {
                if (item == null)
                {
                    continue;
                }
                else
                {
                    result.Add(item);
                }
            }
            return result;
        }
        public static List<string> RemoveNulls2(List<string?> input)
        {
            if (input is null)
            {
                throw new ArgumentNullException();
            }

            return input
                .Where(str => str != null)
                .Cast<string>()
                .ToList();
        }
    }
}
