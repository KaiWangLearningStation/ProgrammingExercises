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
    internal class Ex030 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 030: 递归计算阶乘 ---");
            // 题目描述
            string line = "计算一个非负数字的阶乘factorial（n* n-1 * ....2*1），其中0的阶乘是1";
            Console.WriteLine(line);

            // 准备一些测试数据

            int resutl1 = CalculateFactorial1(3);
            int result2 = CalculateFactorial2(3);

            // 调用你的逻辑方法



            // 输出结果
            Console.WriteLine(resutl1);
            Console.WriteLine(result2);
        }

        // 方法1：循环法
        public static int CalculateFactorial1(int number)
        {
            int factorial = 1;
            for (int i = 1; i <= number; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
        // 方法2：递归
        public static int CalculateFactorial2(int number)
        {

            if (number < 0)
            {
                throw new ArgumentException();
            }
            if (number == 1 || number == 0)
            {
                return 1;
            }

            return number * CalculateFactorial2(number - 1);

        }
        //题目知识：
        // 1. 递归不能用number--，因为后置自增自减是先返回值再自增自减的，因此会陷入无限循环中，最好就是用number-1
        // 2. 递归最好在return中发生，这样阅读起来更加简单
        // 3. 一定要设置终止条件，即满足什么条件时，return返回不是方法，而是实际值作为终止条件


    }
}
