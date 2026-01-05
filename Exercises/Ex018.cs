using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingExercises100.Exercises
{
    internal class Ex018 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 018: 扩展DayOfWeek来检测周末 ---");
            // 题目描述
            string line = "请编写一个类，其中包含一个IsWeekEnd拓展方法，当日期是Saturday或Sunday时返回true，如果不是返回false";
            Console.WriteLine(line);

            // 准备一些测试数据

            var result1 = DayOfWeek.Sunday.IsWeekEnd();
            var result2 = DayOfWeek.Monday.IsWeekEnd();

            // 调用你的逻辑方法


            // 输出结果
            Console.WriteLine(result1);
            Console.WriteLine(result2);

        }

       

        //题目知识：
        // 1.拓展方法允许给现有的类或者结构体、枚举添加方法，而不用改他们的代码
        // 拓展方法需要以this关键字作为第一个参数的标志，表明是拓展方法，然后是拓展方法要用在的类或结构体或枚举的类型，以及一个局部变量
        // 拓展方法必须在静态类中，以便直接用对应的类调用，而不是需要拓展类的实例

    }
    //方法1 ：拓展方法
    public static class DayOfWeekExtensions
    {
        public static bool IsWeekEnd(this DayOfWeek dayOfWeek)
        {
            if (dayOfWeek == DayOfWeek.Sunday || dayOfWeek == DayOfWeek.Saturday)
                return true;
            return false;
            // return dayOfWeek == DayOfWeek.Sunday || dayOfWeek == DayOfWeek.Saturday  也可以
        }
    }

}
