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
    internal class Ex045 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 045: 使用抽象类实现形状计算 ---");
            // 题目描述
            string line = "有一个Shape抽象类，有两个抽象方法，CalculateArea和CalculatePerimeter。继承这个抽象类，实现自己形状的这两个方法";
            Console.WriteLine(line);

            // 准备一些测试数据
            Circle circle = new Circle(5);
            Rectangle rectangle = new Rectangle(3, 4);


            // 调用你的逻辑方法


            // 输出结果
            Console.WriteLine(circle.CalculateArea());
            Console.WriteLine(circle.CalculatePerimeter());
            Console.WriteLine();
            Console.WriteLine(rectangle.CalculateArea());
            Console.WriteLine(rectangle.CalculatePerimeter());

        }

        //题目知识：
    }
    public abstract class Shape
    {
        public abstract double CalculateArea();
        public abstract double CalculatePerimeter();
    }
    public class Circle : Shape
    {
        private readonly double _radius;
        public Circle(double radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentException();
            }
            _radius = radius;
        }
        public override double CalculateArea()
        {
            return Math.PI * _radius * _radius;
        }

        public override double CalculatePerimeter()
        {
            return Math.PI * 2 * _radius;
        }
    }

    public class Rectangle : Shape
    {
        private readonly double _width;
        private readonly double _height;

        public Rectangle(double width, double height)
        {
            if (width <= 0 || height <= 0)
            {
                throw new ArgumentException();
            }
            _height = height;
            _width = width;
        }
        public override double CalculateArea()
        {
            return _width * _height;
        }

        public override double CalculatePerimeter()
        {
            return (_height + _width) * 2;
        }
    }
}
