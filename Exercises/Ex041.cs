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
    internal class Ex041 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 041: 获取按照时间戳排序的最近n条消息 ---");
            // 题目描述
            string line = "假设消息已经按照时间戳排序，最旧的消息在前，最新的在后，编写一个方法返回最近获取的n条消息。这个方法应该跳过所有";
            Console.WriteLine(line);

            // 准备一些测试数据
            IEnumerable<Message1> test = new List<Message1>()
            {
                new Message1("wk",new DateTime(2026,1,8)),
                new Message1("wk",new DateTime(2026,2,8)),
                new Message1("wk",new DateTime(2026,3,8)),
                new Message1("wk",new DateTime(2025,3,8))
            };

            IEnumerable<Message1> test1 = OrderMessages(test);
            IEnumerable<Message1> test2 = GetTopNRencetMessages(test1, 2);

            // 调用你的逻辑方法


            // 输出结果
            foreach (var item in test1)
            {
                Console.WriteLine($"{item.Content},{item.Timastamp}");
            }
            Console.WriteLine();
            foreach (var item in test2)
            {
                Console.WriteLine($"{item.Content},{item.Timastamp}");
            }

        }
        public static IEnumerable<Message1> OrderMessages(IEnumerable<Message1> messages)
        {
            return messages.OrderByDescending(message => message.Timastamp);
        }
        public static IEnumerable<Message1> GetTopNRencetMessages(IEnumerable<Message1> messages, int n)
        {
            if (messages is null)
            {
                throw new ArgumentException(nameof(messages), "Messages cannot be null");
            }
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(n), "Number of messages to take must be non-negative");
            }
            return messages
                .SkipWhile(message => message.Timastamp < DateTime.Now)
                .Take(n);
        }

        //题目知识：
        // 1. record类型用来存放数据是很好的选择，自动实现了不可变性，基于值的相等性
        // 2. 返回类型是IEnumerable<T>，和LINQ方法很搭配
        // 3. skipwhile不会完全遍历集合，而是跳过元素直到满足Func条件的元素出现时，因此是依赖于排序的
        // 4. 代码中单独写了Order方法，实际上可以融合到GetTopNRencetMessages中，第一步先排序即可
    }
    public record Message1(string Content, DateTime Timastamp);
}
