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
    internal class Ex058 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 058: 使用索引器限制列表容量 ---");
            // 题目描述
            string line = "目标是实现一个有限列表类LimitedList。这个类应该只允许10个元素加入进来，超过则抛出异常。";
            Console.WriteLine(line);

            // 准备一些测试数据

            LimitedList limitedList = new LimitedList();
            for (int i = 0; i < 10; i++)
            {
                limitedList.Add(i);
            }
            try
            {
                limitedList.Add(10);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            

            //limitedList[1] = 1;  错误，不能用index赋值


            // 调用你的逻辑方法


            // 输出结果


        }


        //题目知识：
        // 1. List预定义类和自己定义的List类，都不能直接用index来进行赋值，会出现异常
        // 2. 因此做set限制，不能在indexer中，而是要在自定义的Add方法中，用Add方法添加元素，并且做数量判断
    }
    public class LimitedList
    {
        private readonly List<int> _item = new List<int>();
        private const int MaxCapacity = 10;

        public int Count => _item.Count;

        public void Add(int value)
        {
            if (_item.Count >= MaxCapacity)
            {
                throw new InvalidOperationException($"Capacity of {MaxCapacity} items exceeded");
            }
            _item.Add(value);
        }
        public int this[int index]
        {
            get => this[index];
            set => _item[index] = value;
        }
    }
}
