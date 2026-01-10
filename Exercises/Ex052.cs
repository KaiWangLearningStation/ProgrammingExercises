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
    internal class Ex052 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 052: 用非硬编码描述类 ---");
            // 题目描述
            string line = "原本使用类中的属性来进行编码，属于硬编码，现在需要用非硬编码模式来描述类的数据";
            Console.WriteLine(line);

            // 准备一些测试数据
            Person p = new Person("wk",25);

            // 调用你的逻辑方法
            Console.WriteLine(p.Describe1());
            Console.WriteLine(p.Describe2());

            // 输出结果

        }


        //题目知识：
        // 1. 使用字符串插值可能在后期更新了属性名称，这样不会有编译时错误，可能会忘记修改。类名变换后也是一样的
        // 2. 使用nameof关键词，可以用来显示类、变量、属性的名称，如果这些内容发生了修改，编译会出现错误，提醒开发者修改

    }
    public class Person
    {
        public string Name { get; }
        public int Age { get; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Describe1()
        {
            return $"This is a Person with the following properties: Name = {Name}, Age = {Age}";
        }
        public string Describe2()
        {
            return $"This is a {nameof(Person)} with the following properties: {nameof(Name)} = {Name}, {nameof(Age)} = {Age}";
        }
    }
}
