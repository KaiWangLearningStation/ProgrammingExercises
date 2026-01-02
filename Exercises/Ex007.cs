using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingExercises100.Exercises
{
    internal class Ex007 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 007: 多条件判断 ---");
            // 题目描述
            string line = "请编写一个方法，接受一个decimal参数和布尔值，如果参数在50以下且布尔值为false，返回10；如果参数在50以下，且布尔值为true，返回5；如果参数在50以上且布尔值为false，返回5，如果参数在50以上且布尔值为true，返回0";
            Console.WriteLine(line);

            // 准备一些测试数据


            // 调用你的逻辑方法
            var result1 = CalculateShippingCost(30, true);
            var result2 = CalculateShippingCost(80, true);
            var result3 = CalculateShippingCost(30, false);
            var result4 = CalculateShippingCost(80, false);

            // 输出结果
            Console.WriteLine(result1);
            Console.WriteLine(result2);
            Console.WriteLine(result3);
            Console.WriteLine(result4);
        }

        //方法1：简单的if else语句
        public static decimal CalculateShippingCost(decimal orderTotal, bool isPremiumCustomer)
        {
            if (isPremiumCustomer)
            {
                if (orderTotal < 50)
                    return 5;
                else
                    return 10;
            }
            else
            {
                if (orderTotal >= 50)
                    return 0;
                else
                    return 5;
            }
        }

        //方法2：模式匹配的 Switch-Expression Pattern
        public static decimal CalculateShippingCostPattern(decimal orderTotal, bool isPremiumCustomer)
        {
            return orderTotal switch
            {
                < 50 when !isPremiumCustomer => 10,
                < 50 when isPremiumCustomer => 5,
                >= 50 when !isPremiumCustomer => 5,
                >= 50 when isPremiumCustomer => 0,
                _ => 0,
            };
        }

        //题目知识：
        //1. 模式匹配的Switch表达式，里面有when模式
    }

}
