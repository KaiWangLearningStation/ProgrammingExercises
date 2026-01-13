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
    internal class Ex083 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 083: 并行计算数字平方列表 ---");
            // 题目描述
            string line = "Parallel.ForEach作用和foreach方法类似，不同的是他允许并行的高效的执行集合遍历。" +
                "实现SquareALL方法，接收int列表返回一个新的列表。";
            Console.WriteLine(line);

            // 准备一些测试数据

            List<int> list = new List<int>() { 1, 2, 3, 4 };

            // 调用你的逻辑方法
            var result = ParallelMath.SquareAll(list);

            // 输出结果
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }


        //题目知识：
        // 1. Enumerable.Range(0, numbers.Count) 生成了索引值序列 → Parallel.ForEach 迭代这个序列，每次取出一个值 → 这个值作为 index 参数传递给 lambda 表达式 → index 被用作数组的索引来访问对应位置的元素。
        // 2. Range返回整数，左闭右开
        // 3. ForEach是泛型的，但是可以省略类型，通过Range返回int类型的列表，推断类型是int，所以index是int
    }
    public static class ParallelMath
    {
        public static List<int> SquareAll(List<int> numbers)
        {
            var result = new int[numbers.Count];
            Parallel.ForEach(
                Enumerable.Range(0, numbers.Count),
                index => result[index] = numbers[index] * numbers[index]);
            return result.ToList();
        }
    }
}
