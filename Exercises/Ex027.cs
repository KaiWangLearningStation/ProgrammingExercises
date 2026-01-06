using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingExercises100.Exercises
{
    internal class Ex027 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 027: 计算列表中唯一元素的数量 ---");
            // 题目描述
            string line = "任务：输入一个列表，列表中元素如果是唯一的，计数增加1，最后返回这个列表中唯一元素的数量";
            Console.WriteLine(line);

            // 准备一些测试数据
            List<int> list1 = new List<int>() { 1,2,3,4,4,5 };
            List<string> list2 = new List<string>() { "1","sdf","sdf"};

            // 调用你的逻辑方法
            int result1 = CountUnique1(list1);
            int result2 = CountUnique1(list2);


            // 输出结果
            Console.WriteLine(result1);
            Console.WriteLine(result2);

        }
        // 方法1：使用HashSet
        public static int CountUnique1<T>(List<T> items)
        {
            HashSet<T> set = new HashSet<T>();  
            foreach (T item in items)
            {
                set.Add(item);
            }
            return set.Count;
        }

        // 方法2：使用HashSet的重载，直接把IEnumerable类型items转换为HashSet
        public static int CountUnique2<T>(List<T> items)
        {
            return new HashSet<T>(items).Count;
        }

        // 方法3：LINQ的Distinct方法内部用HashSet实现，能够去重
        public static int CountUnique3<T>(List<T> items)
        {
            return items.Distinct().Count();
        }

        //题目知识：
        // 1.存储不重复的值的数据结构，首选就是Hashset哈希集，因为哈希集只存储值，并且不能存在重复的值，因此天然就适合这种唯一元素的数据类型
        // 2.HashSet有构造函数，可以直接把IEnumerable类型转换为HashSet，自动去重
        // 3.LINQ的Distinct方法内部就是使用了HashSet，因此可以直接调用这个方法，生成唯一List，然后计数即可
    }
}
