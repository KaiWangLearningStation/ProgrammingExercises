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
    internal class Ex085 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 085: 计算可空值的加权平均值 ---");
            // 题目描述
            string line = "实现WeightedAverage方法，接收元组(double? value, double weight)列表，返回加权平均值double。" +
                "忽略value是null的元组";
            Console.WriteLine(line);

            // 准备一些测试数据

            List<(double?, double)> data = new List<(double?, double)>()
            {
                new (null,12),
                new (12,5),
                new (15,10),
                new (13,20),
            };

            // 调用你的逻辑方法
            Console.WriteLine(NullableMath.WeightedAverage1(data));
            Console.WriteLine(NullableMath.WeightedAverage2(data));

            // 输出结果

        }


        //题目知识：
        // 1. 不要在LINQ上一条路走到黑，可以适当用变量盛放LINQ的结果
        // 2. Cast方法要接收IEnumerable类型，因此要在Sum前
        // 3. GetValueOrDefault方法可以获取一个类型的真实值，可以用来转化可空类型
    }
    public static class NullableMath
    {
        public static double WeightedAverage1(List<(double? value, double weight)> data)
        {
            if (data == null)
            {
                throw new ArgumentNullException();
            }
            return data
                .Where(item => item.value != null)
                .Select(item => item.value * item.weight)
                .Cast<double>()
                .Sum() / data
                .Where(item => item.value != null)
                .Select(item => item.weight)
                .Sum();
        }
        public static double WeightedAverage2(List<(double? value, double weight)> data)
        {
            if (data == null)
            {
                throw new ArgumentNullException();
            }
            var filtered = data.Where(pair => pair.value.HasValue).ToList();
            double weightedSum = filtered.Sum(pair => pair.value.GetValueOrDefault() * pair.weight);
            double totalWeight = filtered.Sum(pair => pair.weight);

            return weightedSum / totalWeight;
        }
    }
}
