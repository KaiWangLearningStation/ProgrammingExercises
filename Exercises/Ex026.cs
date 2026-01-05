using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingExercises100.Exercises
{
    internal class Ex026 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 026: 自定义转换运算符 ---");
            // 题目描述
            string line = "任务：实现从 TimeDuration 到 TimeSpan 的隐式转换，以便在时间 API 中自动使用。实现从 TimeSpan 到 TimeDuration 的显式转换，以便允许转换回来，并截断小数秒（TimeSpan 允许小数秒，但 TimeDuration 不允许）。";
            Console.WriteLine(line);

            // 准备一些测试数据

            TimeDuration timeDuration1 = new TimeDuration(5);
            TimeSpan timeSpan1 = timeDuration1;

            TimeSpan timeSpan2 = TimeSpan.FromSeconds(1.5);
            TimeDuration timeDuration2 = (TimeDuration)timeSpan2;

            // 调用你的逻辑方法



            // 输出结果
            Console.WriteLine($"TimeDuration1:{timeDuration1.Seconds}");
            Console.WriteLine($"TimeSpan1:{timeSpan1}");
            Console.WriteLine($"TimeSpan2:{timeSpan2}");
            Console.WriteLine($"TimeDuration2:{timeDuration2.Seconds}");

        }


        //题目知识：
        // 1.用户自定义转换运算符有自己专门的语法

        // 2.从 A 到 B 的隐式转换(implicit)：也就是说 B 引用变量可以直接接受一个 A 类型的值：B b = a;
        // public static implicit operator B(A a) => B接受A值的操作;

        // 3.从 B 到 A 的显式转换(emplicit)：A a = (A)b;
        // public static explicit operator A(B b) => A接受B值的操作;


    }
    public class TimeDuration
    {
        public int Seconds { get; }
        public TimeDuration(int seconds)
        {
            Seconds = seconds;
        }

        public static implicit operator TimeSpan(TimeDuration timeDuration) => TimeSpan.FromSeconds(timeDuration.Seconds);
        public static explicit operator TimeDuration(TimeSpan timeSpan) => new TimeDuration((int)timeSpan.TotalSeconds);
    }
}
