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
    internal class Ex099 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 099: 将罗马数字转化为整数 ---");
            // 题目描述
            string line = "实现RomanToInt方法，接收一个string罗马数字，返回int。";
            Console.WriteLine(line);

            // 准备一些测试数据

            string str1 = "IX";
            string str2 = "CD";
            string str3 = "MDII";

            // 调用你的逻辑方法


            // 输出结果
            Console.WriteLine(RomanConverter.RomanToInt(str1));
            Console.WriteLine(RomanConverter.RomanToInt(str2));
            Console.WriteLine(RomanConverter.RomanToInt(str3));
        }


        //题目知识：
        // 1. 关键是理解罗马数字转换int的逻辑，如果前一个比后一个大，总值是加法。如果前一个比后一个小，总值是减法
        // 2. 注意防止越界
    }
    public static class RomanConverter
    {
        private static readonly Dictionary<char, int> RomanMap = new Dictionary<char, int>()
        {
            {'I', 1 },
            {'V', 5 },
            {'X', 10 },
            {'l', 50 },
            {'C', 100 },
            {'D', 500 },
            {'M', 1000 }
        };
        public static int RomanToInt(string roman)
        {
            int result = 0;
            int length = roman.Length;
            for (int i = 0; i < length - 1; i++)
            {
                if (RomanMap[roman[i]] >= RomanMap[roman[i + 1]])
                {
                    result += RomanMap[roman[i]];
                }
                else
                {
                    result -= RomanMap[roman[i]];
                }
            }
            result += RomanMap[roman[length - 1]];
            return result;
        }
    }
}
