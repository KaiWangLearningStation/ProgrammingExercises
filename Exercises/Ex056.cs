using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Reflection;
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

            AttributeTest attributeTest = new AttributeTest();
            attributeTest.MyProperty = "11111111111111111111111111111111111111111";

            // 调用你的逻辑方法

            var validResult = Validator.Validate(attributeTest);
            // 输出结果
            foreach (var item in validResult)
            {
                Console.WriteLine(item);
            }

        }


        //题目知识：
        // 1. Attribute特性是用来注解类、方法、属性的，用到特性的类必须继承自基类Attribute类型
        // 2. 创建类继承Attribute基类，然后这个类用AttributeUsage来注释，表明AttributeTargets是Property，说明只能用于Property
        // 3. Attribute不能限制代码的运行，这个规则是用来方便后续统一验证的，验证是否超过限制，需要创建验证器类
        // 4. 验证器使用反射获取对象的类，进而获取类的属性列表，使用GetCustomAttribute<T>方法查找属性类型，然后在属性中就能实现验证的逻辑了

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

    public class Validator
    {
        public static List<string> Validate(object obj)
        {
            var errors = new List<string>();
            var properties = obj.GetType().GetProperties();

            foreach (var prop in properties)
            {
                // 1. 查找 MaxLength 特性
                var maxLengthAttr = prop.GetCustomAttribute<MaxLengthAttribute>();

                if (maxLengthAttr != null && prop.PropertyType == typeof(string))
                {
                    // 2. 获取属性当前值
                    string? value = (string?)prop.GetValue(obj);

                    // 3. 执行实际验证逻辑
                    if (value?.Length > maxLengthAttr.Length)
                    {
                        errors.Add($"属性 '{prop.Name}' 长度不能超过 {maxLengthAttr.Length}，当前长度：{value?.Length}");
                    }
                }
            }

            return errors;
        }
    }
}
