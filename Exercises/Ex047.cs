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
    internal class Ex047 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 047: 为书籍实现拷贝构造函数 ---");
            // 题目描述
            string line = "实现一个Copy Constructor在Book类中，拷贝构造函数用来创建一个存在对象的副本对象，保证独立的两个对象有着相同的数据";
            Console.WriteLine(line);

            // 准备一些测试数据
            Book1 book1 = new Book1("Once","wk",500);
            Book1 book2 = new Book1(book1);


            // 调用你的逻辑方法


            // 输出结果
            Console.WriteLine(book1.ToString());
            Console.WriteLine(book2.ToString());

        }


        //题目知识：
        // 1. 复制构造函数，即写一个构造函数，参数为另一个对象，然后把这个对象的属性创建到新的对象中
        // 2. 重写ToString 方法在输出对象的时候自动调用
   

    }
    public class Book1
    {
        public string Title { get; }
        public string Auther { get; }
        public int PageCount { get; }

        public Book1(string title, string author, int pageCount)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(author) || pageCount <= 0)
            {
                throw new ArgumentException();
            }
            Title = title; 
            Auther = author; 
            PageCount = pageCount;
        }

        public Book1(Book1 other)
        {
            if (other is null)
            {
                throw new ArgumentNullException();
            }
            Title = other.Title;
            Auther = other.Auther;
            PageCount = other.PageCount;
        }

        public override string ToString()
        {
            return $"{Title} {Auther} {PageCount}";
        }

    }
}
