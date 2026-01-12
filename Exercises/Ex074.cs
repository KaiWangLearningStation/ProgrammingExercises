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
    internal class Ex074 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 074: 按类别汇总销售数据 ---");
            // 题目描述
            string line = "实现GetCategoryStatistics方法，接收Sale对象集合，每个Sale对象有以下属性：Category，Amount，返回一个CategoryStatistics对象列表，每个包含Category名称，总Amount量，Sale个数，平均销售量(Amount/Sale个数)" +
                "resultlist应该按照category名字排序" +
                "如果一个category没有sales，不应该出现在结果中" +
                "如果input是空的，抛出异常";
            Console.WriteLine(line);

            // 准备一些测试数据
            Sale sale1 = new Sale("Category1", 200m);
            Sale sale2 = new Sale("Category2", 300m);
            Sale sale3 = new Sale("Category1", 800m);
            Sale sale4 = new Sale("Category3", 800m);
            Sale sale5 = new Sale("Category4", 100m);

            // 调用你的逻辑方法
            var result = SalesAnalyzer.GetCategoryStatistics(new List<Sale>() { sale1, sale2, sale3, sale4, sale5 });

            // 输出结果
            foreach (var item in result)
            {
                Console.WriteLine($"Category: {item.Category}, Total: {item.Total}, Count: {item.Count}, Average: {item.Average}");
            }
            //Category: Category1, Total: 1000, Count: 2, Average: 500
            //Category: Category2, Total: 300, Count: 1, Average: 300
            //Category: Category3, Total: 800, Count: 1, Average: 800
            //Category: Category4, Total: 100, Count: 1, Average: 100
        }


        //题目知识：
        // 1. LINQ综合练习，GroupBy方法按照Func中的输出作为分组依据进行分组，返回的是IGrouping类型的IEnumerable，IGrouping 是一个包含多个元素的集合（IEnumerable<TElement>），并且带有一个 Key 属性。Key是LINQ中指定的Key，分组对象是Sale对象，有几个Sale对象就有几个值。不是一对一的关系。
        // 2. 这个分组对象可以用Select方法，选择每个组，用这个组去生成CategoryStatistics，其中Key就是Category，Sum方法计算Amount就是最终的Amount，Count方法计算的是Sale的个数，Average方法接收的是每个Sale对象的Amount，来计算Average。Select方法处理后，结果是IEnumerable<CategoryStatistics>了。
        // 3. OrderBy需要传入排序Key，这里就是IEnumerable<CategoryStatistics>中每个CategoryStatistics的Category默认排序。
    }
    public static class SalesAnalyzer
    {
        public static List<CategoryStatistics> GetCategoryStatistics(IEnumerable<Sale> sales)
        {
            if (sales is null)
            {
                throw new ArgumentNullException();
            }

            return sales
                .GroupBy(sale => sale.Category)
                .Select(group => new CategoryStatistics(
                    group.Key,
                    group.Sum(sale => sale.Amount),
                    group.Count(),
                    group.Average(sale => sale.Amount)))
                .OrderBy(result => result.Category)
                .ToList();
        }
    }
    public record Sale(string Category, decimal Amount);
    public record CategoryStatistics(string Category, decimal Total, int Count, decimal Average);
}
