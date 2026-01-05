using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingExercises100.Exercises
{
    internal class Ex022 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 022: 确认用户注册数据 ---");
            // 题目描述
            string line = "请写一个方法：实现RegisterUser方法，验证注册信息，方法接受四个参数username，password，age，email。username需要满足：非null非空，否则抛出异常；password：至少八位，否则抛出异常；age：必须是18-120之间";
            Console.WriteLine(line);

            // 准备一些测试数据

            string username = "wangkai";
            string password = "123456789";
            string email = "wangkai@outlook.com";
            int age = 50;



            // 调用你的逻辑方法

            try
            {
                RegisterUser(username, password, age, email);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

            // 输出结果


        }

        //方法
        public void RegisterUser(string username, string password, int age, string email)
        {
            const int MinPasswordLength = 8;
            const int MinAge = 18;
            const int MaxAge = 120;

            if (username == null)
                throw new ArgumentNullException(nameof(username), "Username cannot be null");
            if (string.IsNullOrEmpty(username))  // username == string.Empty
                throw new ArgumentException("Username cannot be null", nameof(username));


            if (password.Length < MinPasswordLength)
                throw new ArgumentException($"Pssword must be at least {MinPasswordLength} characters long", nameof(password));

            if (age < MinAge || age > MaxAge)
                throw new ArgumentOutOfRangeException(nameof(age), $"Age must be between {MinAge} and {MaxAge}");

            if (string.IsNullOrEmpty(email) || !email.Contains('@') || !email.Contains('.'))
                throw new FormatException("Email must contain '@' and '.'");

            Console.WriteLine("User registered successfully");
        }


        //题目知识：
        // 1.多次使用的数字，应该定义为常量，防止多次修改时遗漏
        // 2.注意不同的异常对象，传入的参数的顺序可能不一样，例如ArgumentNullException和ArgumentException，参数名和message是相反的
        // 3.不能用is string.Empty要用== string.Empty
    }


}
