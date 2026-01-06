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
    internal class Ex029 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 029: 使用字符串格式化的唯一任务标识符 ---");
            // 题目描述
            string line = "创建一个类，包含两个属性，ID和描述，这两个属性应该是只读的；使用GUID、静态工厂方法实际模式、重写ToString方法";
            Console.WriteLine(line);

            // 准备一些测试数据
            TaskItem taskItem = TaskItem.Create("Description:123123");


            // 调用你的逻辑方法



            // 输出结果
            Console.WriteLine(taskItem.ToString()); // Task[1e7e3fb1]: Description: 123123

        }


        //题目知识：
        // 1.使用Guid结构体可以创建唯一的识别码Guid.NewGuid()方法
        // 2.私有构造函数，不允许使用new关键字创建实例，而是需要借助类内的静态方法来调用私有构造函数来创建实例，即需要一个Create方法，这种模式叫做静态工厂方法
        // 3.每个object都有ToString方法，继承自Object基类，可以被重写override，重写后调用这个方法返回自己想要的内容，否则返回的是类名
    }
    public class TaskItem
    {
        public Guid Id { get; }
        public string Description { get; }

        private TaskItem(Guid id, string description)   //私有构造函数，需要通过其他公共方法来创建类的实例，例如静态工厂方法，即定义一个用于创建并返回新对象的静态方法，该方法接收desctiption作为参数，生成新的Guid
        {
            Id = id;
            Description = description;
        }

        public static TaskItem Create(string description)
        {
            return new TaskItem(Guid.NewGuid(), description);
        }
        
        public override string ToString()
        {
            var guidPrefix = Id.ToString().Substring(0, 8);
            return $"Task [{guidPrefix}]: {Description}";
        }
    }
}
