using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingExercises100.Exercises
{
    internal class Ex011 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 011: 实现安全读取文件内容 ---");
            // 题目描述
            string line = "请编写一个方法，传入一个文件名，如果文存在返回内容，如果文件不存在，抛出异常，并且记录一个log warning并且再次抛出异常，无论文件是否找到，都要记录一个“Attempted to read file：filename。";
            Console.WriteLine(line);

            // 准备一些测试数据
            ActualFileSystem actualFileSystem = new ActualFileSystem();
            ConsoleLogger logger = new ConsoleLogger();

            Exercise exercise = new Exercise(actualFileSystem, logger);
            string fileName = "test.txt";
            try
            {
                exercise.TryReadFile(fileName);
            }
            catch (Exception)
            {
            }
            

            // 调用你的逻辑方法


            // 输出结果


        }

        //题目知识：
        // 1. 构造器参数接收接口类型变量，为了实现解耦或者叫松耦合，类之间通过接口通信，而不是具体的实现类
        // 2. 依赖倒置原则（D）：高层模块不依赖低层模块，二者都依赖抽象
        // 3. try catch finally的使用以及throw到调用部分的逻辑

    }

    public class Exercise
    {
        private readonly IFileSystem _fileSystem;
        private readonly ILogger _logger;

        public Exercise(IFileSystem fileSystem, ILogger logger)
        {
            _fileSystem = fileSystem;
            _logger = logger;
        }

        public string TryReadFile(string fileName)
        {
            try
            {
                return _fileSystem.ReadFile(fileName);
            }
            catch (FileNotFoundException ex)
            {
                _logger.Log($"{ex.Message}");
                throw;
            }
            finally
            {
                _logger.Log($"Attempted to read file：{fileName}");
            }

        }

    }
    public interface IFileSystem
    {
        string ReadFile(string fileName);
    }
    public interface ILogger
    {
        void Log(string message);
    }


    // 实际的 IFileSystem 实现
    public class ActualFileSystem : IFileSystem
    {
        public string ReadFile(string fileName)
        {
            return File.ReadAllText(fileName);
        }
    }

    // 控制台日志记录器
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"[LOG] {DateTime.Now:HH:mm:ss.fff}: {message}");
        }
    }
}
