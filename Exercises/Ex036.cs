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
    internal class Ex036 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 036: 使用IComparer实现自定义数据排序 ---");
            // 题目描述
            string line = "IComparer<T>常常用来自定义集合排序，例如按照对象特殊属性进行排序等。任务：实现Compare方法，用来基于Title属性比较两个Book对象，方法返回int类型如果x<y 返回负数，x=y返回0，x>y返回整数";
            Console.WriteLine(line);

            // 准备一些测试数据
            Book book1 = new Book("wangkai", 123);
            Book book2 = new Book("wangkai", 123);
            Book book3 = new Book("zzzz", 321);

            // 调用你的逻辑方法

            List<Book> books1 = new List<Book>() { book1, book2, book3 };

            books1.Sort(new BookTitleComparer1());
            // 输出结果
            foreach (Book book in books1)
            {
                Console.WriteLine(book.Title);
            }
            Console.WriteLine();

            List<Book> books2 = new List<Book>() { book1, book2, book3 };

            books2.Sort(new BookTitleComparer2());
            foreach (Book book in books2)
            {
                Console.WriteLine(book.Title);
            }
        }

        //题目知识：
        // 1. 当使用Sort方法的时候，如果什么参数都不提供，调用默认的comparer比较器：对于数值类型，按照从小到大结果排序，对于字符串类型，按照字母顺序排序a在最前面，大小写和文化有关系；对于DateTime：时间从前到后排序
        // 2. IComparer接口是为了实现自定义排序用的，Sort方法中有一个重载就是需要传入一个实现IComparer接口的对象。实现这个接口需要实现Compare方法，这个方法返回值是int类型，如果想要第一个元素排在前面，返回负数，如果想要第二个元素在前面，返回正数，如果一样则返回0
        // 3. 这样在调用Sort方法的时候，可以(new)这个对象，则按照自定义的比较器进行排序
        // 4. 内部可以用定义好的Compare方法或CompareTo方法，区别是Compare方法是静态方法，用类名调用，接受两个要比较的对象，而Compare是实例方法，只接受一个对象
        // 5. Compare方法有几个重载，第三个参数可以传入bool来决定是否忽略大小写，或者第三个参数传入枚举StringComparison.OrdinalIgnoreCase也是忽略大小写

    }
    public class Book
    {
        public string Title { get; }
        public int PageCount { get; }
        public Book(string title, int pageCount)
        {
            PageCount = pageCount;
            Title = title;
        }
    }

    public class BookTitleComparer1 : IComparer<Book>
    {
        public int Compare(Book? x, Book? y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            return x.Title.CompareTo(y.Title);
        }
    }
    public class BookTitleComparer2 : IComparer<Book>
    {
        public int Compare(Book? x, Book? y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            return string.Compare(x.Title, y.Title, true);
            //return string.Compare(x.Title, y.Title,StringComparison.OrdinalIgnoreCase);
        }
    }
}
