using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingExercises100.Exercises
{
    internal class Ex012 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 012: 求给定索引之间的数字和 ---");
            // 题目描述
            string line = "请编写一个方法，接受一个start index和一个end index，再接受一个可变长度的数字列表，方法返回起始index和结尾index之间的数字的和，左闭右开。如果start和end超出列表范围，调整start为0，end为数组长度";
            Console.WriteLine(line);

            // 准备一些测试数据
            int[] array1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // 调用你的逻辑方法

            int result1 = SumInRange1(2, 5, array1);
            int result2 = SumInRange2(2, 5, array1);
            int result3 = SumInRange3(2, 5, array1);

            // 输出结果
            Console.WriteLine(result1);
            Console.WriteLine(result2);
            Console.WriteLine(result3);

        }

        //方法1 ：处理好边界条件，for循环即可
        public static int SumInRange1(int start, int end, params int[] numbers)
        {
            int length = numbers.Length;
            int sum = 0;

            if (start < 0)
            {
                start = 0;
            }
            if (end > length)
            {
                end = length - 1;
            }
            if (start >= end)
            {
                return 0;
            }
            for (int i = start; i < end; i++)
            {
                sum += numbers[i];
            }
            return sum;
        }

        //方法2 ：处理好边界条件，使用数组切片Slice概念，再用LINQ的sum方法
        public static int SumInRange2(int start, int end, params int[] numbers)
        {
            int length = numbers.Length;

            if (start < 0)
            {
                start = 0;
            }
            if (end > length)
            {
                end = length - 1;
            }
            if (start >= end)
            {
                return 0;
            }
            return numbers[start..end].Sum();
        }

        //方法3 ：处理好边界条件，完全使用LINQ的方法  skip+take+sum
        public static int SumInRange3(int start, int end, params int[] numbers)
        {
            int length = numbers.Length;

            if (start < 0)
            {
                start = 0;
            }
            if (end > length)
            {
                end = length - 1;
            }
            if (start >= end)
            {
                return 0;
            }

            return numbers.Skip(start).Take(end - start).Sum();
        }

        //题目知识：
        // 1. 使用params参数，可以自动接受一组数据转化为一个数组，记得params只能放在参数列表的最后，且只能有一个
        // 2. 使用for循环处理数组是可以的，但是有更加方便的针对array或list的工具，例如linq
        // 3. LINQ的skip方法跳过几个内容，take取出几个元素到数组，最后可以sum来进行求和
        // 4. skip和take可以用Range  ..取元素，左闭右开，操作取代，
    }

}
