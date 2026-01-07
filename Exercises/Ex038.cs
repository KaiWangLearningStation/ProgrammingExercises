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
    internal class Ex038 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 038: 按时间戳获取最近消息 ---");
            // 题目描述
            string line = "实现GetRecentMessages方法，获取Message集合对象，返回一个经过Timestamp时间戳排序的IEnumerable<string>，格式为yyyy-MM-dd HH:mm:ss - [Content]";
            Console.WriteLine(line);

            // 准备一些测试数据
            Message m1 = new Message("Content1", DateTime.Now);
            Message m2 = new Message("Content2", new DateTime(2012, 12, 23, 12, 20, 30));
            Message m3 = new Message("Content3", DateTime.Parse("2013-12-1 12:20:30"));
            Message m4 = new Message("Content4", DateTime.Parse("2008-1-1"));


            // 调用你的逻辑方法

            IEnumerable<Message> messages = new List<Message>() { m1, m2, m3, m4 };

            IEnumerable<string> result = GetRecentMessages(messages);
            // 输出结果
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            var numbers = new List<int> { -3, 5, 2, -8, 7, 4 };

        }

        public static IEnumerable<string> GetRecentMessages(IEnumerable<Message> messages)
        {
            if (messages == null)
            {
                throw new ArgumentNullException(nameof(messages));
            }

            return messages
                .OrderByDescending(message => message.Timestamp)
                .Select(message => $"{message.Timestamp.ToString("yyyy-MM-dd HH:mm:ss")} - [{message.Content}]");
            //  .Select(message => $"{message.Timestamp:yyyy-MM-dd HH:mm:ss} - [{message.Content}]");

        }
        //题目知识：
        // 1. LINQ的OrderBy方法，传入Func（有参有返回值委托），进行排序，这里的Func就是lambda表达式，表示排序用的key是message.Timestamp
        // 2. OrderBy按照升序排列，OrderByDescending按照降序排列
        // 3. Select也是传入Func委托，返回类型是string，可以new string来返回或者直接用字符串插值
        // 4. DateTime类型不能直接转为为字符串，需要调用ToString方法，可以选择传入字符串参数，指定时间的规则"yyyy-MM-dd HH:mm:ss"或者可以直接在插值字符串指定格式，而不调用ToString方法，message.Timestamp:yyyy-MM-dd HH:mm:ss 用冒号隔开
    }
    public class Message
    {
        public string Content { get; }
        public DateTime Timestamp { get; }
        public Message(string content, DateTime timestamp)
        {
            Content = content;
            Timestamp = timestamp;
        }
    }
}
