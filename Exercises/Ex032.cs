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
    internal class Ex032 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 032: 活动票证的组合ID ---");
            // 题目描述
            string line = "一个活动系统需要基于活动名和日期来比较票证，需要实现Ticket类的可比较性，即实现Equals和GetHashCode方法，类内还有EventName属性和EventDate属性，只有这两个属性完全相同，才能说ticket完全相同";
            Console.WriteLine(line);

            // 准备一些测试数据
            Ticket t1 = new Ticket("Name", new DateTime(2012, 1, 1));
            Ticket t2 = new Ticket("Name", new DateTime(2012, 1, 1));
            Ticket t3 = new Ticket("wangkai", new DateTime(2012, 1, 1));


            // 调用你的逻辑方法

            Console.WriteLine(t1.Equals(t2));
            Console.WriteLine(t1.Equals(t3));

            // 输出结果

        }

        // 方法1：循环法
        public static int CalculateFactorial1(int number)
        {
            int factorial = 1;
            for (int i = 1; i <= number; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
        // 方法2：递归

        //题目知识：
        // 1. C#默认采用引用类型比较机制（类class），即Equals方法比较的是引用而不是值，如果要用值的比较，必须手动实现，或者干脆采用原生支持值类型比较的类型（结构体Struct或Record记录）
        // 2. 重写Equals方法，传入的是object类型对象，验证的时候需要拆箱为需要比较的类型，然后调用类型的属性来进行值的比较
        // 3. 重写GetHashCode方法，最常用的是使用HashCode.Combine 把属性的HashCode加起来，或者直接调用base.GetHashCode方法
        // 4. 两个方法要一起重写才行
        // 5. Ticket t1 = new Ticket() { "Name", (2012,1,1) }; 典型错误：首先参数一个写在圆括号内，因为构造函数是（）的；其次不能写成(2012,1,1)，而是要new DateTime(2012,1,1)；初始化器只能在有set访问器的时候使用，如果只有get，则不能这样用
        // 6. 默认的equls方法确实比较的是对象是否是同一个，也就是引用变量指向的对象是否是一样，即使里面的东西完全一样，但不是一个对象的时候，也是返回false
        // public override bool Equals(object? obj)
        //{
        //    return base.Equals(obj);
        //}

}
    public class Ticket
    {
        public string EventName { get; }
        public DateTime EventDate { get; }

        public Ticket(string eventName, DateTime eventTime)
        {
            EventName = eventName;
            EventDate = eventTime;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null || obj is not Ticket)
            {
                return false;
            }
            Ticket other = (Ticket)obj;
            return EventDate == other.EventDate && EventName == other.EventName;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(EventName, EventDate);
        }
    }
}
