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
    internal class Ex048 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 048: 使用IDisposable记录器处理消息 ---");
            // 题目描述
            string line = "让一个对象实现IDisposable接口，就能够让对象不再使用的时候，释放这个资源，Dispose方法再被回收的时候调用。";
            Console.WriteLine(line);

            // 准备一些测试数据

            string[] str = { "1", "2", "3", "4", "5", "6", "7", "8" };

            // 调用你的逻辑方法

            ProcessMessages("Log1", str);

            // 输出结果


        }
        public static void ProcessMessages(string logName, string[] messages)
        {
            if (string.IsNullOrEmpty(logName))
            {
                throw new ArgumentException();
            }
            if (messages is null)
            {
                throw new ArgumentNullException();
            }

            using (LogWriter logWriter = new LogWriter(logName))
            {
                foreach (var message in messages)
                {
                    logWriter.WriteMessage(message);
                }
            }
            // using LogWriter logWriter = new LogWriter(logName); 一样
        }

        //题目知识：
        // 1.IDisposable接口有Dispose销毁方法，用来清除非托管资源。
        // 2.需要手动调用这个方法或者使用using语句包裹，在using后自动调用Dispose方法
        // 3.using(){} 的简单版本是 using声明，即using + 创建对象；在这个对象不再使用的时候，自动调用

    }
    public class LogWriter : IDisposable
    {
        private bool _isDispoesd;
        private readonly string _logName;

        public LogWriter(string logName)
        {
            if (string.IsNullOrEmpty(logName))
            {
                throw new ArgumentNullException();
            }
            _logName = logName;
            Console.WriteLine($"Log {_logName} opened");
        }

        public void WriteMessage(string message)
        {
            if (_isDispoesd)
            {
                throw new ObjectDisposedException(nameof(LogWriter), "Cannot write to a disposed log");
            }
            Console.WriteLine($"[{_logName} {message}]");
        }

        public void Dispose()
        {
            if (!_isDispoesd)
            {
                Console.WriteLine($"[{_logName}] closed");
                _isDispoesd = true;
            }
        }
    }
}
