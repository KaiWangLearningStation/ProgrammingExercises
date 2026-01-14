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
    internal class Ex095 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 095: 模拟代阈值警报的温度传感器 ---");
            // 题目描述
            string line = "实现TemperatureSensor类，包含一个OverThreshold事件，当一个温度值超过Threshold值的时候触发事件（必须修改过Threshold值，不能是null）";
            Console.WriteLine(line);

            // 准备一些测试数据
            TemperatureSensor temperatureSensor = new TemperatureSensor();
            temperatureSensor.OverThreshold += (sender, e) 
                => Console.WriteLine($"Temperatrue {e.Temperature} Over The Threshold");

            // 调用你的逻辑方法

            temperatureSensor.RegisterTemperature(80);   //不触发事件，因为Threshold==null
            temperatureSensor.Threshold = 60;
            temperatureSensor.RegisterTemperature(50);   //不触发事件，因为Threshold > Temperatrue
            temperatureSensor.RegisterTemperature(70);   //触发事件

            // 输出结果

        }


        //题目知识：
        // 1. 事件在发布者中定义的时候，使用Invoke方法前需要用空条件运算符，相当于在调用之前加了一个if为空的时候的判断。
        // 2. 发布者类中需要Invoke事件，Invoke参数要传入sender和EventArg，一般来说传入的是this表示sender就是本类，EventArg是需要传递的其他数据。
        // 3. 订阅者类中需要订阅事件，方法是发布者的事件 += 到一个lambda表达式，传入的参数固定是sender和e，分别是sender的对象和EventArgs，可以通过他们访问发布者的信息
    }
    public class TemperatureSensor
    {
        public double? Threshold { get; set; } = null;
        public event EventHandler<TemperatureEventArgs>? OverThreshold;

        public void RegisterTemperature(double value)
        {
            if (Threshold == null)
            {
                return;
            }
            if (value > Threshold)
            {
                OverThreshold?.Invoke(this, new TemperatureEventArgs(value));
            }
        }
    }
    public class TemperatureEventArgs : EventArgs
    {
        public double Temperature { get; }
        public TemperatureEventArgs(double temperature) => Temperature = temperature;
    }
}
