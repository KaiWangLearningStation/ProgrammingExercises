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
    internal class Ex084 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 084: 将字符串数组转换为csv行 ---");
            // 题目描述
            string line = "csv comma-separated values 逗号分割值 是一种简单的文本格式，csv用来存储和交换数据，可以表示为表格" +
                "实现ToCsvLine方法，接收string[] 返回csv格式的行作为string。需要过滤空值或空条目，最后用逗号连接起来";
            Console.WriteLine(line);

            // 准备一些测试数据

            string?[] strings = { "Name", "Age", null, "", "City", "Alice", "30", "London", "Bob", "25", "Paris", "Carol", "20", "Berlin" };

            // 调用你的逻辑方法
            var result = CsvUtil.ToCsvLine(strings);

            // 输出结果
            Console.WriteLine(result);
        }


        //题目知识：
        // 1. string.Join方法接收一个分隔符，后面是一个params参数，可以把传入的都看作是一个数组。用分隔符，分割数组的每个值
        // 2. value != null && value != string.Empty 也可以写为 value => !string.IsNullOrWhiteSpace(value) 这个把空格也省略了，如果是IsNullOrEmpty则不会抛弃多个空格
    }
    public static class CsvUtil
    {
        public static string ToCsvLine(string?[] values)
        {
            return string.Join(",", values
                .Where(value => value != null && value != string.Empty)
                //.Where(value => !string.IsNullOrWhiteSpace(value))
                .Select(value => value?.Trim()));
        }
    }
}
