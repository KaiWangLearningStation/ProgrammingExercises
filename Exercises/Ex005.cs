using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingExercises100.Exercises
{
    internal class Ex005 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 005: 从TimeRanges时间点 计算 TimeSpan时间跨度 ---");
            // 题目描述
            string line = "请编写一个方法，接受一个元组列表参数，包含两个信息，休息开始时间和休息结束时间，计算休息时间跨度并返回。";
            Console.WriteLine(line);

            // 准备一些测试数据
            var result1 = new List<(DateTime Start, DateTime End)>()
            {
                (DateTime.Parse("2023-1-10"), DateTime.Parse("2023-1-12")),   //可以通过DateTime的Parse方法转换字符串
                (new DateTime(2023, 2, 1), new DateTime(2023, 2, 28)),        //也可以直接创建DateTime对象，用逗号隔开int值即可
                (new DateTime(2023, 3, 1), new DateTime(2023, 3, 10))
            };

            // 调用你的逻辑方法
            var timeSpan1 = CalculateTotalBreakTime(result1);

            // 输出结果
            Console.WriteLine(timeSpan1.TotalDays);

        }

        //方法1：遍历列表内的每个元组，元组做减法累加到总的timespan上即可
        public static TimeSpan CalculateTotalBreakTime(List<(DateTime Start, DateTime End)> breaks)
        {
            TimeSpan totalBreakTime = TimeSpan.Zero;

            foreach (var (start, end) in breaks)  //元组列表的遍历，元组有解构deconstruct方法，可以提取里面的值
            {
                totalBreakTime += end - start;
            }
            return totalBreakTime;
        }

        //题目知识：
        //1. DateTime可以直接生成对象，传入int即可，也可以通过string来转换，使用DateTime.Parse方法
        //2. DateTime相减可以生成TimeSpan，TimeSpan有zero属性
        //3. 元组列表可以遍历，获取元组的值
    }

}
