using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingExercises100.Exercises
{
    internal class Ex008 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 008: 把一个字符串输入解析为日期时间，将年月日作为输出参数返回 ---");
            // 题目描述
            string line = "请编写一个方法，更新最高分并记录在player的Statistics中，player参数可空，他的statistics也可空。如果两者都为空，方法一个什么都不做，如果HighestScore为空，把他的值设置为newScore，如果存在HighestScore，且比newScore低，更新HighestScore";
            Console.WriteLine(line);

            // 准备一些测试数据
            string time1 = "2012-12-23";
            string time2 = "12-23-2012";

            // 调用你的逻辑方法

            TryExtractDataComponents(time1, out int year1, out int month1, out int day1);
            TryExtractDataComponents(time2, out int year2, out int month2, out int day2);

            // 输出结果
            Console.WriteLine(year1 + " " + month1 + " " + day1);
            Console.WriteLine(year2 + " " + month2 + " " + day2);
        }



        //方法1：直接TryParse
        public static bool TryExtractDataComponents(string deteInput, out int year, out int month, out int day)
        {
            //使用命名参数让参数列表更清晰
            bool result = DateTime.TryParse(deteInput, provider: CultureInfo.InvariantCulture, result: out DateTime time);
            //InvariantCulture表示解析使用一致的、与文化无关的格式，不管用户的区域设置是怎样的
            if (result)
            {
                year = time.Year;
                month = time.Month;
                day = time.Day;
                return result;
            }
            else
            {
                year = 0; month = 0; day = 0; return false;
            }
        }



        //题目知识：
        //1. TryParse方法传入字符串，文化信息，输出参数
        //2. TryParse方法返回值是布尔值，有一个out参数，能够额外返回一个DateTime类型的值，和Parse返回的一样
        //3. 使用命名参数能够提高可读性
    }

}
