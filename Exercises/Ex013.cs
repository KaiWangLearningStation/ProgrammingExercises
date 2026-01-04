using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingExercises100.Exercises
{
    internal class Ex013 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 013: 把string和int混合的对象列表进行分离 ---");
            // 题目描述
            string line = "请编写一个方法，接受一个object类型列表，包含integer，string和其他类型。返回一个元组，包含所有的int值，所有的sstring值，和其他类型的值";
            Console.WriteLine(line);

            // 准备一些测试数据
            List<object> objects = new List<object>() { 0, 1, 2, 3, "WangKai", "Good", 3.2, 4.8 };

            // 调用你的逻辑方法


            List<int> ints = SeparateObjects1(objects).ints;
            List<string> strings = SeparateObjects2(objects).strings;
            int unKnownCount = SeparateObjects3(objects).unKnownCount;

            // 输出结果
            Console.Write("ints: ");
            foreach (var item in ints)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            Console.Write("strings: ");
            foreach (var item in strings)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            Console.WriteLine($"strings: {unKnownCount}");
            

        }

        //方法1 ：循环判断
        public static (List<int> ints, List<string> strings, int unKnownCount) SeparateObjects1(List<object> objects)
        {
            List<int> ints = new List<int>();
            List<string> strings = new List<string>();
            int unKnownCount = 0;

            foreach (var item in objects)
            {
                if (item is int)
                {
                    ints.Add((int)item);
                }
                else if (item is string)
                {
                    strings.Add((string)item);
                }
                else
                {
                    unKnownCount++;
                }
            }
            return (ints, strings, unKnownCount);
        }

        //方法2 ：LINQ的OfType方法，不够高效，集合被遍历两次
        public static (List<int> ints, List<string> strings, int unKnownCount) SeparateObjects2(List<object> objects)
        {
            List<int> ints = objects.OfType<int>().ToList();
            List<string> strings = objects.OfType<string>().ToList();
            int unKnownCount = objects.Count - ints.Count - strings.Count;

            return (ints, strings, unKnownCount);
        }

        //方法3 ：安全使用is模式转换，加上一个
        public static (List<int> ints, List<string> strings, int unKnownCount) SeparateObjects3(List<object> objects)
        {
            List<int> ints = new List<int>();
            List<string> strings = new List<string>();
            int unKnownCount = 0;

            foreach (var item in objects)
            {
                if (item is int intNumber)
                {
                    ints.Add(intNumber);
                }
                else if (item is string stringText)
                {
                    strings.Add(stringText);
                }
                else
                {
                    unKnownCount++;
                }
            }
            return (ints, strings, unKnownCount);
        }

        //题目知识：
        // 1. is进行类型转换时，加上后续的变量名，在转换成功后直接进行类型转换，省区了强制转换的步骤
        // 2. LINQ的OfType<>方法能够自动进行类型划分，划分后是IEnumerable<>类型，可以再转化为List
        // 3. 元组类型可以用.操作符进行访问
    }

}
