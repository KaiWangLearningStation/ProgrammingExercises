using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingExercises100.Exercises
{
    internal class Ex093 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 093: 对订单和客户执行内连接 ---");
            // 题目描述
            string line = "Joins连接在处理分开存储但需要共同处理的关联数据时，十分有用。" +
                "实现JoinOrdersWithCustomers方法，接收Order对象列表和Customer对象列表，返回一个元组列表(int OrderId， int CustomerId， string CustomerName)。这两个对象列表有一个共同的CustomerId。";
            Console.WriteLine(line);

            // 准备一些测试数据

            List<Order> orders = new List<Order>()
            {
                new Order(1,1,10m),
                new Order(2,1,10m),
                new Order(3,2,10m)
            };

            List<Customer> customers = new List<Customer>()
            {
                new Customer(1,"Name1"),
                new Customer(2,"Name2"),
                new Customer(3,"Name3")
            };

            // 调用你的逻辑方法
            var result = JoinOrder.JoinOrdersWithCustomers(orders, customers);

            // 输出结果
            foreach (var item in result)
            {
                Console.WriteLine(item.OrderId);
                Console.WriteLine(item.CustomerId);
                Console.WriteLine(item.CustomerName);
                Console.WriteLine();
            }
        }


        //题目知识：
        // 1. Join方法，需要四个参数 调用者.Join(要组合者，调用者的键选择，组合者的键选择，输出的结果)
    }
    public static class JoinOrder
    {
        public static List<(int OrderId, int CustomerId, string CustomerName)> JoinOrdersWithCustomers(List<Order> orders, List<Customer> customers)
        {
            return orders
                .Join(
                customers, 
                order => order.CustomerId, 
                customer => customer.CustomerId, 
                (order, customer) => (order.OrderId, order.CustomerId, customer.Name))
                .ToList();
        }
    }
    public record Order(int OrderId, int CustomerId, decimal Amount);
    public record Customer(int CustomerId, string Name);
}
