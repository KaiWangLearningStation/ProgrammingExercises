using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingExercises100.Exercises
{
    internal class Ex078 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 078: 使用字符串插值可视化列 对其表格 ---");
            // 题目描述
            string line = "实现FormatProductTable方法，接收Product列表，每个Product有Name, Quantity, Price属性。Name小于15字符，并且填充至8字符，price（带有货币标识）填充至10字符。方法返回一个string table每行包括product name左对齐，宽度15 quantity 右对齐宽度8，price右对齐宽度10。列用|分割";
            Console.WriteLine(line);

            // 准备一些测试数据
            var products = new List<ProductToFormat>
            {
                new ProductToFormat("Apple", 5, 1.99m),
                new ProductToFormat("Banana", 120, 0.39m),
                new ProductToFormat("Cherry", 15, 2.47m)
            };


            // 调用你的逻辑方法
            var result = TableFormatter.FormatProductTable(products);

            // 输出结果
            Console.WriteLine(result);
        }


        //题目知识：
        // 1. 格式化输出可以有标准长度，在{}传入打印对象后，还能加一个int类型整数，标识输出的长度，不够要补齐，-号表示左对齐，+表示右对齐
        // 2. decimal小数有ToString方法，可以接收format参数，即用"0.00"来表示输出小数的格式
        // 3. Select中，花括号中甚至能有多个语句作为局部变量，还能有return关键字返回内容，作为Func的返回类型
    }
    public static class TableFormatter
    {
        public static string FormatProductTable(List<ProductToFormat> products)
        {
            if (products is null)
            {
                throw new ArgumentNullException();
            }
            var lines = products.Select(product =>
            {
                string formattedPrice = $"${product.Price.ToString("0.00")}";
                return $"{product.Name,-15}|{product.Quantity,8}|{formattedPrice,10}";
            });
            return string.Join(Environment.NewLine, lines);
        }
    }
    public record ProductToFormat(string Name, int Quantity, decimal Price);
}
