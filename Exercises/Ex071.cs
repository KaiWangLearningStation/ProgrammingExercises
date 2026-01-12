using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingExercises100.Exercises
{
    internal class Ex071 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 071: 使用INumber<T> 约束计算平均值 ---");
            // 题目描述
            string line = "使用普通的计算平均值的方法，需要绑定特定的数据类型，例如int、long、double等。.NET7引入的泛型数学功能，通过实现INumber接口，可以支持所有的数据类型，避免了多个重载版本的编写。" +
                "实现泛型方法CalculateAverage<TNumber>，接收任何实现了INumber<TNumber>的数字类型。方法返回平均值";
            Console.WriteLine(line);

            // 准备一些测试数据

            double[] doubles = { 1.0, 2.0, 3.0, 4.0 };
            decimal[] decimals = { 1.0m, 2.0m, 3.0m, 4.0m };


            // 调用你的逻辑方法
            var result1 = MathUtils.CalculateAverage(doubles);
            var result2 = MathUtils.CalculateAverage(decimals);
            // 输出结果
            Console.WriteLine(result1);
            Console.WriteLine(result2);

        }


        //题目知识：
        // 1. where是用来表示泛型约束的，表示传入的TNumber要求都实现了INumber接口
        // 2. `TNumber` 是一个** 泛型类型参数**，名称是可以自定义的，这个泛型类型参数是`CalculateAverage<TNumber>`定义的
        // 3. **内置的数值类型** 实现了 `INumber<T>`：int, long, short, byte, sbyte, float, double, decimal, nint, nuint，这些类型可以直接传入这个方法中，因为符合** 泛型约束**
        // 4. 使用泛型数学类型，不能用常规的int中的0值，而是要用INumber中实现的Zero属性表示0
        // 5. 也不能用Length属性直接转换为TNumber类型，要用CreateChecked方法进行安全转化才行

    }
    public static class MathUtils
    {
        public static TNumber CalculateAverage<TNumber>(TNumber[] numbers) where TNumber : INumber<TNumber>
        {
            TNumber sum = TNumber.Zero;
            foreach (var item in numbers)
            {
                sum += item;
            }
            TNumber count = TNumber.CreateChecked(numbers.Length);
            return sum / count;
        }
    }
}
