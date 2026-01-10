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
    internal class Ex056 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 056: 定义自定义特性（Attributes） ---");
            // 题目描述
            string line = "特性是可用于应用程序的元数据注解，例如类、方法、属性都是特性。可以在运行时或编译时检索的附加信息。实现MaxLengthAttribute类，这个类可以注释string类型的属性，用一个最大允许长度。这个Attribute应该包含一个Length和一个构造器";
            Console.WriteLine(line);

            // 准备一些测试数据



            // 调用你的逻辑方法


            // 输出结果


        }


        //题目知识：
        // 1. Attribute特性是用来注解类、方法、属性的，用到特性的类必须继承自基类Attribute类型
        // 2. 创建类继承Attribute基类，然后这个类用AttributeUsage来注释，表明AttributeTargets是Property，说明只能用于Property
        // 3. 为了强制执行此限制，需要使用另一个内置特性AttributeUsage

    }
    [AttributeUsage(AttributeTargets.Property)]
    public class MaxLengthAttribute : Attribute
    {
        public int Length { get;  }
        public MaxLengthAttribute(int length)
        {
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            Length = length;
        }
    }

    public class AttributeTest
    {
        [MaxLength(25)]
        public string? MyProperty { get; set; }
    }
}
