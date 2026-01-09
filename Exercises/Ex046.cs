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
    internal class Ex046 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 046: 按类别查找最便宜的产品 ---");
            // 题目描述
            string line = "实现FindCheapestCategory方法，接受Product集合和一个category字符串，返回最便宜的product的category或者null";
            Console.WriteLine(line);

            // 准备一些测试数据
            List<Product> products = new List<Product>()
            {
                new Product(productName:"c1", price:15.99m, category:"Clothing"),
                new Product(productName:"c2", price:18.99m, category:"Clothing"),
                new Product(productName:"c3", price:1.99m, category:"Clothing"),
                new Product(productName:"a", price:0.99m, category:"Vegetable"),
                new Product(productName:"b", price:15.99m, category:"Vegetable"),
                new Product(productName:"c", price:30.99m, category:"Vegetable"),

            };


            // 调用你的逻辑方法

            Console.WriteLine(FindCheapestInCategory1(products, "Clothing"));
            Console.WriteLine(FindCheapestInCategory2(products, "Vegetable"));
            // 输出结果


        }

        public static Product? FindCheapestInCategory1(IEnumerable<Product> products, string category)
        {
            if (products is null)
            {
                throw new ArgumentNullException();
            }
            if (string.IsNullOrEmpty(category))
            {
                throw new ArgumentException();
            }

            return products
                .Where(product => product.category == category)
                .OrderBy(product => product.price)
                .FirstOrDefault();   
        }
        public static Product? FindCheapestInCategory2(IEnumerable<Product> products, string category)
        {
            if (products is null)
            {
                throw new ArgumentNullException();
            }
            if (string.IsNullOrEmpty(category))
            {
                throw new ArgumentException();
            }

            return products
                .Where(product => product.category == category)
                .MinBy(product => product.price);
                
        }
        //题目知识
        // 1.类如果只用来存储内容，用record十分方便快捷，省区很多繁琐的操作
        // 2.Where是筛选的首选
        // 3.OrderBy排序从低到高，MinBy直接返回一个最低值的对象，MaxBy相反
        // 4.First取第一个对象，FirstOrDefault能够避免错误，取不到也不会报错

    }
    public record Product(string productName, decimal price, string category);

}
