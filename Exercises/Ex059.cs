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
    internal class Ex059 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 059: 反转泛型数组 ---");
            // 题目描述
            string line = "实现static ReverseArray方法，接收泛型类型，返回一个新的反转后的数组";
            Console.WriteLine(line);

            // 准备一些测试数据

            int[] arr = [0, 1, 2, 3, 4, 5];

            // 调用你的逻辑方法
            var result1 = ArrayUtils.ReverseArray1(arr);
            var result2 = ArrayUtils.ReverseArray2(arr);
            var result3 = ArrayUtils.ReverseArray3(arr);
            var result4 = ArrayUtils.ReverseArray4(arr);


            // 输出结果
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(result1[i]);
                Console.WriteLine(result2[i]);
                Console.WriteLine(result3[i]);
                Console.WriteLine(result4[i]);
                Console.WriteLine();
            }

        }


        //题目知识：
        // 1. 使用手动方式反转数组是最高效的
        // 2. 使用LINQ的Reverse方法，创建新的数组对象，然后进行反转，可读性最高。LINQ的Reverse和Array.Reverse静态方法是不同的，Array.Reverse让数组本身反转
        // 3. LINQ的Select确实会创建新的对象，但是在这里是多余的，因为Reverse本就能创建新的对象，不影响原数组
        // 4. 使用CopyTo做的是浅拷贝，如果是值类型变量做浅拷贝，其行为是深拷贝的行为，即修改一处不会修改原处。如果是引用类型的变量，则完全是浅拷贝的行为，修改会同步。值类型：int double 等，引用类型：string object 自定义类等。注意string虽然是引用类型，但是string具有不可变性，实际上还是创建了新的string对象。
        // 5. 泛型方法，一定要给方法名称后面加上<T>

    }
    public static class ArrayUtils
    {
        public static T[] ReverseArray1<T>(T[] input)
        {
            T[] result = new T[input.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = input[input.Length - 1 - i];
            }
            return result;
        }
        public static T[] ReverseArray2<T>(T[] input)
        {
            return input.Reverse().ToArray();
        }
        public static T[] ReverseArray3<T>(T[] input)
        {
            return input
                .Select(n => n)
                .Reverse()
                .ToArray();
        }
        public static T[] ReverseArray4<T>(T[] input)
        {
            var result = (T[])input.Clone();
            return result
                .Reverse()
                .ToArray();
        }
    }
}
