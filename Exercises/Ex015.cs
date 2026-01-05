using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingExercises100.Exercises
{
    internal class Ex015 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 015: 对int类型安全求和，返回long类型 ---");
            // 题目描述
            string line = "请编写一个方法，接受一个int集合，以long类型返回他们的和，避免integer overflow发生，超过int最大值2,147,483,647";
            Console.WriteLine(line);

            // 准备一些测试数据

            List<int> ints1 = new List<int>() { 1, int.MaxValue, int.MaxValue };
            List<int> ints2 = new List<int>() { 1, 2 };

            // 调用你的逻辑方法
            try
            {
                long result2 = SafeSum2(ints2);
                Console.WriteLine(result2);

                long result1 = SafeSum2(ints1);
                Console.WriteLine(result1);

            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }


            // 输出结果


        }

        //方法1 ：循环判断
        public static long SafeSum1(IEnumerable<int> numbers)
        {
            long result = 0;

            foreach (var item in numbers)
            {
                result += item;
            }
            return result;

        }

        //方法2 ：LINQ sum
        public static long SafeSum2(IEnumerable<int> numbers)
        {
            long sum = 0;

            sum = numbers.Sum(number => (long)number);
            return sum;

        }


        //题目知识：
        // 1. Sum方法如果传入的是int类型列表，则返回类型还是int，如果出现溢出还是会抛出溢出，不会隐式转换，因为内部使用了checked，所以下面的代码是不能正常允许的，而是被异常打断
        //public static long SafeSum2(IEnumerable<int> numbers)
        //{
        //    long sum = 0;

        //    sum = numbers.Sum();
        //    return sum;
        //}


        // 2. 方法2使用的类型转换实际上是这个的重载：
        // public static long Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector) => Sum<TSource, long, long>(source, selector);

        //TSource：是 int（因为 numbers 是 IEnumerable<int>）。
        //selector：是一个委托（Delegate），即 number => (long) number。它接收一个 int，返回一个 long。

        // this: 表示这是一个扩展方法，IEnumerable<TSource>: 第一个参数类型，source: 第一个参数的参数名，拓展方法使得该方法可以像 source.Sum(...) 这样调用
        // Func<TSource, long>：第二个参数的类型， selector: 第二个参数参数名，一个函数，用于从每个元素中提取要求和的值
        // Func<TSource, long>: 委托类型，接受一个 TSource 参数，返回 long

        // => Sum<TSource, long, long>(source, selector); 表达式体语表示上面的方法返回值是这个Sum重载方法
        //这个方法是private的，不直接对用户公开
        //参数顺序是：
        //TSource - 源集合元素类型
        //TResult - 结果类型（最终返回值类型），这里是long
        //TAccumulator - 累加器类型（中间计算类型），这里是long

        //// 1. 初始化累加器
        //TAccumulator sum = TAccumulator.Zero;
        //// 2. 遍历源集合
        //foreach (TSource value in source)
        //{
        //    // 从 value 中提取 TResult 类型的结果
        //    TResult selectedValue = selector(value);
        //    // 将 TResult 转换为 TAccumulator 进行累加
        //    sum += TAccumulator.CreateChecked(selectedValue);
        //}
        //// 3. 将累加器结果转换回 TResult 并返回
        //return TResult.CreateTruncating(sum);





    }

}
