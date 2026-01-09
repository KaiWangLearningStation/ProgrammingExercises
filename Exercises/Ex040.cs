using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingExercises100.Exercises
{
    internal class Ex040 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 040: 使用异常筛选处理网络请求错误 ---");
            // 题目描述
            string line = "网络状态码有专门的定义，本联系模拟网络服务中常见的挑战，处理不同方式失败的HTTP请求，每种错误对应特殊的HTTP状态码";
            Console.WriteLine(line);

            // 准备一些测试数据
            string url1 = "www.wangkai.com";
            string url2 = "www.wangkai.com.notfound";
            string url3 = "www.wangkai.com.servererror";
            string url4 = "www.wk.com";
            Console.WriteLine(ProcessWebRequest(url1));
            Console.WriteLine(ProcessWebRequest(url2));
            Console.WriteLine(ProcessWebRequest(url3));
            Console.WriteLine(ProcessWebRequest(url4));

            // 调用你的逻辑方法


            // 输出结果


        }
        public static string ProcessWebRequest(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentException("URL cannot be null or empty.", nameof(url));
            }
            try
            {
                return SimulateRequest(url);
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                return "404: The request resource was not found.";
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.InternalServerError)
            {
                return "500: An internal server error occurred.";
            }
            catch (HttpRequestException) 
            {
                return "An unexpected HTTP error occurred.";
            }

        }

        private static string SimulateRequest(string url)
        {
            if (url.Contains("notfound"))
            {
                throw new HttpRequestException("Resorce not found", null, HttpStatusCode.NotFound);
            }
            if (url.Contains("servererror"))
            {
                throw new HttpRequestException("Server error", null, HttpStatusCode.InternalServerError);
            }
            if (url.Contains("wk"))
            {
                throw new HttpRequestException();
            }
            return url;
        }

        //题目知识：
        // 1. 练习C#异常捕获的机制：使用的是 Catch-When 异常过滤器，在做catch的时候已经筛选了一次异常的种类，如果异常种类一样，还能通过when进一步筛选，题目中就是通过ex实例对象的HttpStatusCode来进行筛选


    }
}
