using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingExercises100.Exercises
{
    internal class Ex010 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 010: 在类中实现一个自定义索引器 ---");
            // 题目描述
            string line = "请编写一个类，允许使用两个自定义索引器 存储和检索(Retrieving)周中的天数，第一个索引器接收DayOfWeek枚举参数，第二个索引器接收字符串并解析为DayOfWeek，如果转换失败，抛出ArgumentExcepion异常";
            Console.WriteLine(line);

            // 准备一些测试数据
            string str1 = "monday";
            string str2 = "MoNDAY";
            DayOfWeek day1 = DayOfWeek.Monday;

            // 调用你的逻辑方法
            WeekSchedule weekSchedule = new WeekSchedule();
            
            weekSchedule[str1] = "wangkai";

            // 输出结果

            Console.WriteLine(weekSchedule[str1]);
            Console.WriteLine(weekSchedule[str2]);
            Console.WriteLine(weekSchedule[day1]);

        }


        //题目知识：
        // 1. 索引器是用来访问字典等数据的，编写索引器能够在内部做一些额外的逻辑
        // 2. 字典的ContainsKey方法能判断是否有这个键
        // 3. readonly关键字是修饰引用变量的，_plans这个变量是只读的，但是字典本身是可以修改的
        // 4. 索引器可以调用其他索引器，调用索引器能减少错误发生概率
        // 5. Enum.TryParse方法把string转换成枚举，返回值是bool，额外返回值和Parse一样，包含一个ignoreCase bool值，可以用来忽略大小写影响
    }

    public class WeekSchedule
    {
        private readonly Dictionary<DayOfWeek, string?> _plans = new();


        // weekSchedule[DayOfWeek.Monday] = "..."
        public string? this[DayOfWeek dayOfWeek]    //使用DayOfWeek类型的作为索引时，正确返回索引对应的值
        {
            get { return _plans.ContainsKey(dayOfWeek) ? _plans[dayOfWeek] : null; }  //包含这个键则返回对应的值，否则返回null
            set { _plans[dayOfWeek] = value; }   //设置value给这个值
        }

        // weekSchdule["Monday"] = "..."
        public string? this[string dayName]     //使用字符串作为索引时，返回索引对应的值
        {
            get { return this[ParseDay(dayName)]; }   //返回字典的键对应的值，其中键调用了一个方法ParseDay把string转化为DayOfWeek
            set { this[ParseDay(dayName)] = value; }   //这里可以用this调用上面的索引器，也可以直接使用_plans访问的是字典本身
        }

        private DayOfWeek ParseDay(string input)
        {
            if (!Enum.TryParse(input, ignoreCase: true, out DayOfWeek result))
            {
                throw new ArgumentException($"{input} is not a valid day name");
            }
            return result;
        }
    }
}
