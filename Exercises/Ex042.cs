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
    internal class Ex042 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 043: 使用表达式体成员定义温度转换器 ---");
            // 题目描述
            string line = "表达式体成员提供建议语法的属性、方法、构造器的简易语法。任务是实现TemperatureConverter类，其中包含一个表达式体构造函数set一个开尔文值，一个readonly的表达实体Kelvin属性，一个Celsius摄氏度属性，然后从Kelvin转化过来";
            Console.WriteLine(line);

            // 准备一些测试数据

            double kelvin = 300;

            // 调用你的逻辑方法
            TemperatureConverter temperatureConverter = new(kelvin);


            // 输出结果
            Console.WriteLine(temperatureConverter.Kelvin);
            Console.WriteLine(temperatureConverter.Celsius);
            Console.WriteLine(temperatureConverter.ToFahrenheit());

        }


        //题目知识：
        // 1. 表达式体可以用于简单的构造函数、方法、属性、索引器，简化语法，不用写{}，直接写返回值即可
        // 2. 属性如果只有get访问器，可以省略get，直接箭头表达式 public double Kelvin => _kelvin; 

    }
    public class TemperatureConverter
    {
        private double _kelvin;

        public double Kelvin { get => _kelvin; }
        //public double Kelvin => _kelvin; 
        public double Celsius
        {
            get => _kelvin - 273.15;
            set => _kelvin = value + 273.15;
        }
        public TemperatureConverter(double kelvin) => _kelvin = kelvin;

        public double ToFahrenheit() => Celsius * 9 / 5 + 32;
    }
}
