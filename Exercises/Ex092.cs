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
    internal class Ex092 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 092: 从员工收入中计算统计信息 ---");
            // 题目描述
            string line = "实现CalculateIncomeStatistics方法，接收employee收入列表，返回一个元组。元组包括Average income平均数 Mdian incom中位数，Modeincome 众数，最小、最大值";
            Console.WriteLine(line);

            // 准备一些测试数据

            List<decimal> incomes = new List<decimal>() { 1000, 8000, 5000, 2400, 2400, 6900, 10000, 500, 500 };

            // 调用你的逻辑方法
            var result = EmployeeStatistics.CalculateIncomeStatistics(incomes);

            // 输出结果
            Console.WriteLine(result.mean);
            Console.WriteLine(result.median);
            Console.WriteLine(result.mode);
            Console.WriteLine(result.min);
            Console.WriteLine(result.max);
        }


        //题目知识：
        // 1. 把复杂的操作分成方法，提高代码可读性
        // 2. 计算中位数需要区分奇数偶数长度
        // 3. GroupBy(item,item)返回的Grouping对象，是以item为Key，Key对应item本身的结构
        // 4. OrderBy  ThenBy 多因素排序
    }
    public static class EmployeeStatistics
    {
        public static IncomeStatistics CalculateIncomeStatistics(List<decimal> incomes)
        {
            List<decimal> orderedList = incomes.OrderBy(income => income).ToList();
            decimal minIncome = orderedList.First();
            decimal maxIncome = orderedList.Last();

            decimal averageIncome = orderedList.Average();

            decimal medianIncome = CalculateMedian(orderedList);

            decimal modeIncome = CalculateMode(orderedList);
            return new IncomeStatistics(averageIncome, medianIncome, modeIncome, minIncome, maxIncome);
        }
        private static decimal CalculateMedian(List<decimal> decimals)
        {
            int count = decimals.Count();
            decimal medianIncome = 0;
            if (count % 2 == 0)
            {
                medianIncome = (decimals[count / 2 - 1] + decimals[count / 2]) / 2;
                return medianIncome;
            }

            return medianIncome = decimals[count / 2 - 1];

        }
        private static decimal CalculateMode(List<decimal> decimals)
        {
            return decimals
                .GroupBy(income => income)
                .OrderByDescending(group => group.Count())
                .ThenBy(group => group.Key)
                .First()
                .Key;
        }

    }
    public record IncomeStatistics(decimal mean, decimal median, decimal mode, decimal min, decimal max);

}
