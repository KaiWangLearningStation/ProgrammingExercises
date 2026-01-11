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
    internal class Ex061 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 061: 当超过阈值时出发事件 ---");
            // 题目描述
            string line = "实现ThresholdCounter类，有一个公共的Increment方法，当内部计数超过给定的阈值时，触发一个自定义事件ThresholdExceeded。阈值应该在构造器传入，这个类应该有公共的Count属性跟踪Increment方法被调用多少次，还有一个EventHandler类的事件";
            Console.WriteLine(line);

            // 准备一些测试数据

            // 测试1: 基本功能测试
            Console.WriteLine("测试1: 基本功能测试");
            Console.WriteLine("创建阈值=5的计数器");
            ThresholdCounter counter1 = new ThresholdCounter(5);

            // 订阅事件
            counter1.ThresholdExceeded += (sender, e) =>
            {
                if (sender != null)
                {
                    Console.WriteLine($"事件触发: 计数已超过阈值！当前计数: {((ThresholdCounter)sender).Count}");
                }
            };
            //3. 事件订阅
            //+= 操作符添加事件处理器（订阅事件）
            //使用lambda表达式作为事件处理方法
            //sender是触发事件的对象
            //e是事件参数（这里为空）

            // 执行6次递增（应该在第6次触发事件）
            Console.WriteLine("执行7次Increment():");
            for (int i = 0; i < 7; i++)
            {
                counter1.Increment();
                Console.WriteLine($"  第{i + 1}次调用 - Count = {counter1.Count}");
            }
            Console.WriteLine();


            // 调用你的逻辑方法


            // 输出结果


        }


        //题目知识：
        // 1. 事件（Event）是C#中的一种特殊委托，用于实现发布-订阅（Publisher-Subscriber）模式：发布者（Publisher）：触发事件的类（这里是ThresholdCounter）（Subscriber）：响应事件的代码
        // 2. 执行过程：执行Increment() → Count++ → 检查条件 → 触发事件 → 执行订阅者的代码
        // 3. ?. null条件运算符：只有当左侧事件ThresholdExceeded不为null（即有订阅者）时才调用
        // 4. Invoke()触发事件，通知所有订阅者 ，this是事件源（谁触发了事件），EventArgs.Empty表示不传递额外数据
        // 5. 订阅事件：左侧是事件  +=是订阅操作符   右侧是事件发生后要调用的方法名，这里是用lambda来表示匿名方法了，表示方法接收从发布者处传来的object? sender和 EventArgs e，因为sender是this也就是事件源ThresholdCounter的对象，所以sender包含了这个类的属性，因此可以进行拆箱后调用
        // 6. 标识符是巧妙的方法，让事件只触发一次

    }

    public class ThresholdCounter
    {
        private readonly int _threshold;
        private bool _eventRaised = false;
        public int Count { get; private set; }
        public event EventHandler? ThresholdExceeded;
        //1. 定义事件
        //EventHandler是内置的委托类型，用于处理不包含事件数据的事件
        //? 表示事件可以为null（当没有订阅者时）
        //这是事件的发布者端声明
        public ThresholdCounter(int threshold)
        {
            _threshold = threshold;
        }

        public void Increment()
        {
            Count++;

            if (!_eventRaised && Count > _threshold)
            {
                _eventRaised = true;
                ThresholdExceeded?.Invoke(this, EventArgs.Empty);
                //2. 事件触发
                //?.是null条件运算符：只有当ThresholdExceeded不为null（即有订阅者）时才调用
                //Invoke()触发事件，通知所有订阅者
                //this是事件源（谁触发了事件）
                //EventArgs.Empty表示不传递额外数据
            }
        }
    }
}
