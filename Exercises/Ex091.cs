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
    internal class Ex091 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 091: 使用优先级队列按顺序处理任务 ---");
            // 题目描述
            string line = "实现ProcessJobs方法，接收jobs对象列表，每个job包含string Name和int Priority。要求按照优先级排序，返回jobs的名字列表";
            Console.WriteLine(line);

            // 准备一些测试数据
            List<Job> jobs = new List<Job>()
            {
                new Job("Job1", 1),
                new Job("Job2", 2),
                new Job("Job3", 3),
            };


            // 调用你的逻辑方法
            var result1 = JobQueue.ProcessJobs1(jobs);
            var result2 = JobQueue.ProcessJobs2(jobs);

            // 输出结果
            foreach (var item in result1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            foreach (var item in result2)
            {
                Console.WriteLine(item);
            }
        }


        //题目知识：
        // 1. 按照优先级排序可以用LINQ方法，用OrderByDescending选择优先级属性排序，再用select来操作即可
        // 2. 可以使用内置的PriorityQueue结构来处理，这个结构可以入列，出列的时候不是按照先后顺序，而是根据优先级的值，越小的值越先出列，如果要按照值越大的越先，需要传入自定义比较器
    }
    public static class JobQueue
    {
        public static List<string> ProcessJobs1(List<Job> jobs)
        {
            return
            jobs.OrderByDescending(job => job.Priority)
                .Select(job => job.Name)
                .ToList();
        }
        public static List<string> ProcessJobs2(List<Job> jobs)
        {
            var queue = new PriorityQueue<Job, int>();

            foreach (var job in jobs)
            {
                queue.Enqueue(job, job.Priority);
            }

            var result = new List<string>();
            while (queue.Count > 0)
            {
                var nextJob = queue.Dequeue();
                result.Add(nextJob.Name);
            }
            return result;
        }
    }
    public record Job(string Name, int Priority);
}
