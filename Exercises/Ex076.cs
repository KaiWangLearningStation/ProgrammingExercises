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
    internal class Ex076 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 076: 对项目列表进行分页 ---");
            // 题目描述
            string line = "实现GetPage<T>方法，接收一个对象列表，1-based页数number，和一个pagesize。返回属于某个页的items";
            Console.WriteLine(line);

            // 准备一些测试数据
            List<int> items = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
            var result = Paginator.GetPage(items, 3, 5);

            // 调用你的逻辑方法


            // 输出结果
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }


        //题目知识：
        // 1. 分页就是skip某些在take某些的过程
        // 2. 第一页需要跳过零个，后续要跳过页数-1乘Size个
    }
    public static class Paginator
    {
        public static List<T> GetPage<T>(List<T> items, int pageNumber, int pageSize)
        {
            if (items is null)
            {
                throw new ArgumentNullException();
            }
            if (pageNumber <= 0)
            {
                throw new ArgumentException();
            }
            if (pageSize <= 0)
            {
                throw new ArgumentException();
            }

            return items
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToList();

        }
    }
}
