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
    internal class Ex055 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 055: 使用委托转换数字 ---");
            // 题目描述
            string line = "实现TransformNumbers方法，接收float列表和一个transformation函数，返回一个新的列表，列表中是经过函数变化的内容";
            Console.WriteLine(line);

            // 准备一些测试数据

            List<float> floatList = new List<float>() { 1.0f, 2.0f, 3.0f};
            List<float> result1 = NumberTransformer.TransformNumbers1(floatList, item => item * item);
            List<float> result2 = NumberTransformer.TransformNumbers2(floatList, item => item * item);
            List<float> result4 = NumberTransformer.TransformNumbers4(floatList, item => item * item);

            // 调用你的逻辑方法


            // 输出结果

            foreach (var item in result1)
            {
                Console.WriteLine(item);
            }
            foreach (var item in result2)
            {
                Console.WriteLine(item);
            }
            foreach (var item in result4)
            {
                Console.WriteLine(item);
            }
        }


        //题目知识：
        // 1. function作为参数是可以传递给方法的，需要指定这个function的类型，如果是有参数有返回值的就要用Func预定义委托，如果是有参数无返回值的用Action委托。
        // 2. 传入的委托，实际上可以用来当作方法来调用，在方法内这个委托变量看作是方法，可以用括号调用
        // 3. 可以用LINQ的Select简化foreach过程，直接return。Select本身就是要传入一个Func委托，这里正好就是传入方法的委托。
        // 4. lambda表达式是委托的具体内容，但是注意lambda仅定义函数，而本例中函数是作为参数给定的
        // 5. 也可以不适用预定义Func委托，Func是简单的定义参数和返回值类型的预定义，如果不使用，需要自己手动定义：public delegate float Multi(float num); 表明传入的参数是float，返回类型是float。然后可以把Func<float, float>换成Trans。此时要注意：如果不适用LINQ语法，这样改动后没有变化，transform仍然可以当作方法来用。但是在LINQ中有一些不同，LINQ方法一定要接收一个Func类型的参数，虽然 Multi 委托和 Func<float, float> 的签名（参数和返回值）完全一样，但它们是两种不同的“名义类型（Nominal Types）”，且 C# 不支持从一个委托实例隐式转换为另一个委托类型。可以使用transform.Invoke 是一个方法组（Method Group）。C# 编译器允许将“方法组”自动转换为任何匹配签名的委托类型（包括系统自带的 Func）。


    }
    public static class NumberTransformer
    {
        public static List<float> TransformNumbers1(List<float> input, Func<float, float> transform)
        {
            List<float> result = new List<float>();

            foreach (var item in input)
            {
                float transformed = transform(item);
                result.Add(transformed);
            }
            return result;
        }

        public static List<float> TransformNumbers2(List<float> input, Func<float, float> transform)
        {
            return input
                .Select(transform)
                .ToList();
        }

        public delegate float Multi(float num);
        public static List<float> TransformNumbers3(List<float> input, Multi transform)
        {
            var result = new List<float>();
            foreach (var num in input)
            {
                result.Add(transform(num));
            }
            return result;
        }
        public static List<float> TransformNumbers4(List<float> input, Multi transform)
        {
            return input
                .Select(transform.Invoke)
                .ToList();
        }
    }
}
