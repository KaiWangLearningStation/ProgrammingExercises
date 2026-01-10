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
    internal class Ex051 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 051: 在类家族中链中调用构造函数 ---");
            // 题目描述
            string line = "Employee类需要第二个构造函数，接收name参数，设置id为0。Manager类构造函数和基类Employee逻辑要一致";
            Console.WriteLine(line);

            // 准备一些测试数据

            Manager manager = new Manager("WK", "DesignPart");

            // 调用你的逻辑方法
            Console.WriteLine(manager.Name);
            Console.WriteLine(manager.Id);
            Console.WriteLine(manager.Department);

            // 输出结果


        }


        //题目知识：
        // 1. 类家族中链中调用构造函数是好的实践，子类构造函数中使用base调用基类构造函数，直接传入参数即可调用。自己的构造函数体内只需要额外处理自己的属性即可
        // 2. 一个类的多个构造函数之间，也最好要直接调用，使用this关键字调用本类中的构造函数，这样的好处是能够防止基类修改后，子类也需要更新代码。
        // 3. B的构造函数2调用构造函数1，B的构造函数1调用A的构造函数1，A的钩爪函数2调用构造函数1

    }
    public class Employee
    {
        public string Name { get; }
        public int Id { get; }
        public Employee(string name, int id)
        {
            Name = name;
            Id = id;
        }
        public Employee(string name) : this(name, 0)
        {
        }
    }
    public class Manager : Employee
    {
        public string Department { get; }
        public Manager(string name, int id, string department) : base(name, id)
        {
            Department = department;
        }

        public Manager(string name, string department) : this(name, 0, department)
        {
        }



    }
}
