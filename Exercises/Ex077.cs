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
    internal class Ex077 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 077: 使用Lazy T实现延迟对象创建 ---");
            // 题目描述
            string line = "某些对象需要等到确切被使用时才需要创建，通常发生在对象创建操作性能开销大，且对象可能根本不会使用的情况下。Lazy<T>延迟是一种线程安全的类。创建延迟对象时，要指定内部实际对象的创建方式，但是创建操作不会立即执行，只有内部对象仅在首次没访问时才会创建。" +
                "实现ReportManager类，包含一个私有Lazy<Report>字段，表示一个耗时的操作。Report类接收一个string在构造函数中。ReportManager构造函数接收report名称，初始化Lazy<Report>当首次被访问的时候";
            Console.WriteLine(line);

            // 准备一些测试数据

            LazyReportManager lazyReportManager = new LazyReportManager("ReportName");

            // 调用你的逻辑方法
            var result = lazyReportManager.GetReport();

            // 输出结果
            Console.WriteLine(result.Name);
        }


        //题目知识：
        // 1. Lazy<T>延迟创建对象，当使用对象.Value时候才真正创建对象
        // 2. Lazy<T>可以不设置参数，也可以传入一个Func类型委托，没有参数只有<T>返回值
    }
    public class NormalReportManager
    {
        private readonly Report _report;
        public NormalReportManager(string name)
        {
            _report = new Report(name);
        }
        public Report GetReport()
        {
            return _report;
        }
    }
    public class LazyReportManager
    {
        private readonly Lazy<Report> _lazyReport;
        public LazyReportManager(string name)
        {
            _lazyReport = new Lazy<Report>(() => new Report(name));
        }
        public Report GetReport()
        {
            return _lazyReport.Value;
        }
    }
    public class Report
    {
        public static bool Created { get; private set; } = false;

        public string Name { get; }

        public Report(string name)
        {
            Name = name;
            Created = true;
        }
    }

}
