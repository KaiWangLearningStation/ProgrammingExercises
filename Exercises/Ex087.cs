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
    internal class Ex087 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 087: 创建泛型扩展方法使集合中所有值翻倍 ---");
            // 题目描述
            string line = "实现DoubleAll<T>方法，接收IEnumerable<T>返回一个新的值翻倍的IEnumerable<T>";
            Console.WriteLine(line);

            // 准备一些测试数据
            string[] strings = { "a", "b", "c" };
            int[] ints = { 1, 2, 3 };
            List<double> doubles = new List<double>() { 1.5, 2.5, 3.5 };

            // 调用你的逻辑方法
            var result1 = EnumerableExtensions.DoubleAll1(strings);
            var result2 = EnumerableExtensions.DoubleAll2(ints);
            var result3 = EnumerableExtensions.DoubleAll3(doubles);
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
            Console.WriteLine();
            foreach (var item in result3)
            {
                Console.WriteLine(item);
            }
        }


        //题目知识：
        // 1. 最简单的操作是直接yield return两次
        // 2. 使用Zip方法能够按照咬合的方式形成对象，但是是元组类型的，不好直接把元组变成一个数组，因此在这里不推荐
        // 3. Select方法是一对一的，如果value => new[] { value, value }，则会生成多个嵌套数组，但是SelectMany不一样，在这个基础上扁平化，最终成为一个整体数组。
        // 4. 拓展方法的类一般是要被拓展的类型+Extensions，拓展方法中第一个参数要加上this关键字
    }
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> DoubleAll1<T>(this IEnumerable<T> values)
        {
            var turple = values.Zip(values);
            foreach (var item in turple)
            {
                yield return item.First;
                yield return item.Second;
            }
        }
        public static IEnumerable<T> DoubleAll2<T>(this IEnumerable<T> values)
        {
            foreach (var value in values)
            {
                yield return value;
                yield return value;
            }
        }
        public static IEnumerable<T> DoubleAll3<T>(this IEnumerable<T> values)
        {
            return values.SelectMany(value => new[] { value, value });
        }
    }

}
