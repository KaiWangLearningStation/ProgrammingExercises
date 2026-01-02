using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingExercises100.Exercises
{
    internal class Ex002 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 002: 拆分一个full name ---");
            // 题目描述
            string line = "请编写一个方法，接受一个有空格字符串作为参数，把他拆分为两个部分，以元组形式返回。";
            Console.WriteLine(line);

            // 准备一些测试数据
            var fullName1 = "Alice Wang";
            var fullName2 = "Andy Wang";

            // 调用你的逻辑方法
            Console.WriteLine(SplitFullName(fullName1).firstName + " " + SplitFullName(fullName1).lastName);
            Console.WriteLine(SplitFullName(fullName2));

            // 输出结果
        }

        public static (string firstName, string lastName) SplitFullName(string fullName)
        {
            string[] split = fullName.Split(" ");
            return (firstName:split[0], lastName: split[1]);
            //可以给元组项指定名称
        }

        //题目知识：
        //1. split方法处理字符串
        //2. 元组作为返回值，元组可以指定项目名称，不会显示出来，方便调用，类似属性
    }

}
