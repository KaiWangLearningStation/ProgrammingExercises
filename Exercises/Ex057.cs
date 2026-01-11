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
    internal class Ex057 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 057: 用队列逐个处理任务 ---");
            // 题目描述
            string line = "实现TaskQueue类，QueueTask方法把Task添加到队列中，RunTask方法处理队列中的第一个任务，如果没有任务打印消息，如果有任务，打印任务信息，在处理任务后队列变成空，打印空消息信息";
            Console.WriteLine(line);

            // 准备一些测试数据

            TaskQueue taskQueue = new TaskQueue();
            taskQueue.QueueTask("Task1");
            taskQueue.RunTask1();
            taskQueue.RunTask1();
            taskQueue.QueueTask("Task2");
            taskQueue.QueueTask("Task3");
            taskQueue.RunTask2();
            taskQueue.RunTask2();
            taskQueue.RunTask2();

            // 调用你的逻辑方法


            // 输出结果


        }


        //题目知识：
        // 1. Queue先进先出结构，Enqueue入队，Dequeue出队，Peek取出要出队的那个元素
        // 2. void方法可以return提前结束
    }
    public class TaskQueue
    {
        private readonly Queue<string> _tasks = new Queue<string>();

        public void QueueTask(string task)
        {
            _tasks.Enqueue(task);
        }
        public void RunTask1()
        {
            if (_tasks.Count == 0)
            {
                Console.WriteLine("No tasks to run");
                return;
            }

            var task = _tasks.Dequeue();
            Console.WriteLine($"Processing: {task}");

            if (_tasks.Count == 0)
            {
                Console.WriteLine("All tasks completed");
            }
        }

        public void RunTask2()
        {
            if (_tasks.Count == 0)
            {
                Console.WriteLine("No tasks to run");
                return;
            }
         
            Console.WriteLine($"Processing: {_tasks.Peek()}");
            _tasks.Dequeue();

            if (_tasks.Count == 0)
            {
                Console.WriteLine("All tasks completed");
            }
        }
    }
}
