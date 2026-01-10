using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingExercises100.Exercises
{
    internal class Ex054 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 054: 使用反射生成属性报告 ---");
            // 题目描述
            string line = "实现DescribeProperties方法，接收一个类型Type，返回一个字符串，包含所有public属性";
            Console.WriteLine(line);

            // 准备一些测试数据

            string result = TypeReporter.DescribeProperties(typeof(Test1));

            // 调用你的逻辑方法


            // 输出结果
            Console.WriteLine(result);

        }


        //题目知识：
        // 1. 使用反射需要传入Type类型的变量，这个变量可以用来访问这个类型的一些内容
        // 2. GetProperties默认只能反射到public的属性，如果要反射所有属性，需要加上BindingFlags
        // 3. Environment.NewLine 表示当前程序执行环境的空行


    }
    public static class TypeReporter
    {
        public static string DescribeProperties(Type type)
        {
            var properties = type.GetProperties();
            return string.Join(Environment.NewLine, properties.Select(property => $"{property.Name}: {property.PropertyType}"));
        }
    }

    public class Test1
    {
        public string? Name { get; set; }
        public int Age { get; set; }
        private string? Password { get; set; }
    }
}
