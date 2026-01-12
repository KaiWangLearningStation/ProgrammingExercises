using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingExercises100.Exercises
{
    internal class Ex070 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 070: 使用方法隐藏启用基础日志方法 ---");
            // 题目描述
            string line = "在许多类库中，新的特定被加入派生类中，让老的API被隐藏。有一个Logging System，基类是Logger，有一个Log(string message)方法，打印一个前缀。现在要派生一个AdvancedLogger，需要隐藏这个方法。";
            Console.WriteLine(line);

            // 准备一些测试数据

            AdvancedLogger advancedLogger = new AdvancedLogger();
            advancedLogger.Log("wangkai");

            // 调用你的逻辑方法


            // 输出结果


        }


        //题目知识：
        // 1. 基类的方法被继承后，子类中天然有这个方法。如果创建一个签名完全一样的方法，是可行的，覆盖了基类的方法。但是最好要用new关键字来显式表明，这样更加可读
        // 2. 覆盖了基类方法后，可以在方法内调用本类自己的另外的方法，减少代码量，是好的实践
    }
    public class LoggerTest
    {
        public void Log(string message)
        {
            Console.WriteLine($"[Default] {message}");
        }
    }
    public class AdvancedLogger : LoggerTest
    {
        public new void Log(string message)
        {
            Log(message, Loglevel.Info);
        }
        public void Log(string message, Loglevel logLevel)
        {
            Console.WriteLine($"[{logLevel}] {message}");
        }
    }
    public enum Loglevel
    {
        Debug, Info, Warning, Error
    }

}
