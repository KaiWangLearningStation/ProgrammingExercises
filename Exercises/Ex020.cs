using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingExercises100.Exercises
{
    internal class Ex020 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 020: 接口工作机制 ---");
            // 题目描述
            string line = "有一个方法：接受INotification接口的对象集合、string收件人、string消息参数，这个方法调用集合中每个元素的Send方法。需要编写INotification接口，编写SendEmail方法";
            Console.WriteLine(line);

            // 准备一些测试数据

            List<INotification> notifications = new List<INotification>()
            {
                new EmailNotification(),
                new SmsNotification()
            };

            // 调用你的逻辑方法

            SendToAll(notifications, "Wangkai", "messages");

            // 输出结果


        }

        //
        public static void SendToAll(List<INotification> notifications, string recipient, string message)
        {
            foreach (var notification in notifications)
            {
                notification.Send(recipient, message);
            }
        }


        //题目知识：
        // 1.List<INotification> 对象列表可以遍历，其中每个元素调用Send方法，这个Send方法是实现Inotification接口必要的方法
        // 2.在不同的具体类内，都需要实现这个方法，可用在这个公共方法的内部调用自己的方法，来满足不同类型有不同方法的需求
    }

    public interface INotification
    {
        void Send(string recipient, string message);
    }
    public class EmailNotification : INotification
    {
        public void Send(string recipient, string message)
        {
            SendEmail(recipient, message);
        }

        public void SendEmail(string emailAddress, string message)
        {
            Console.WriteLine($"[Email] To: {emailAddress} - Message: {message}");
        }

    }

    public class SmsNotification : INotification
    {
        public void Send(string recipient, string message)
        {
            SendSms(recipient, message);
        }

        public void SendSms(string smsAddress, string message)
        {
            Console.WriteLine($"[Sms] To: {smsAddress} - Message: {message}");
        }
    }

}
