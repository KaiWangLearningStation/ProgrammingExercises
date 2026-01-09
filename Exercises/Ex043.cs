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
    internal class Ex043 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 043: 使用double和decimal计算土地价格 ---");
            // 题目描述
            string line = "double和decimal在范围和精度上有差异，这个会影响计算。" +
                "任务：实现PlotOfLand类型，" +
                "1.包含一个TotalPrice属性，计算AreaInAcres * PricePerAcre" +
                "2.一个IsAreaEqualTo方法，获取另一个PlotOfLand，返回bool类型，";
            Console.WriteLine(line);

            // 准备一些测试数据

            PlotOfLand p1 = new PlotOfLand(10.0005, 1.55M);
            PlotOfLand p2 = new PlotOfLand(10.0006, 1.55M);

            // 调用你的逻辑方法
            Console.WriteLine(p1.IsAreaEqualTo(p2));
            Console.WriteLine(p1.IsPriceEqualTo(p2));

            // 输出结果


        }

        //题目知识：
        // 1. 双精度浮点值 double精度有限，不应该直接比较两个值是否完全相等，而是应该比较差值是否小于精度，使用Math方法
        // 2. TotalPrice属性是动态计算的，get访问器里面放着一个返回值，返回另外属性的乘积，只有get访问器，因此可以用表达式体简写为
        // public decimal TotalPrice => AreaInArces * PricePerAcre;
    }
    public class PlotOfLand
    {
        private const double Margin = 0.0001;

        public double AreaInArces { get; }
        public decimal PricePerAcre { get; }

        public PlotOfLand(double areaInAcres, decimal pricePerAcre)
        {
            if (areaInAcres < 0 || pricePerAcre < 0)
            {
                throw new ArgumentOutOfRangeException("Area and price must be non-negative");
            }
            AreaInArces = areaInAcres;
            PricePerAcre = pricePerAcre;
        }
        public decimal TotalPrice
        {
            get { return (decimal)AreaInArces * PricePerAcre; }
        }

        public bool IsAreaEqualTo(PlotOfLand other)
        {
            if (other == null)
            {
                return false;
            }
            return Math.Abs(AreaInArces - other.AreaInArces) < Margin;
        }

        public bool IsPriceEqualTo(PlotOfLand other)
        {
            if (other == null)
            {
                return false;
            }
            return TotalPrice == other.TotalPrice;
        }
    }
}


