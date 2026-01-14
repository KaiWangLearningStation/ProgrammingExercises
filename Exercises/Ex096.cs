using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ProgrammingExercises100.Exercises
{
    internal class Ex096 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 096: 创建代货币的金额值对象 ---");
            // 题目描述
            string line = "实现一个不可变Money record，封装decimal amount和string currency code。" +
                "支持基于值的相等性比较，重载+ -操作符，提供ToString方法";
            Console.WriteLine(line);

            // 准备一些测试数据
            MoneyClass moneyClass1 = new MoneyClass(10m, "CHN");
            MoneyClass moneyClass2 = new MoneyClass(10m, "CHN");

            MoneyRecord moneyRecord1 = new MoneyRecord(10m, "CHN");
            MoneyRecord moneyRecord2 = new MoneyRecord(10m, "CHN");

            // 调用你的逻辑方法
            Console.WriteLine(moneyClass1 == moneyClass2);   //False，因为这里是引用比较，没有重写==操作符
            Console.WriteLine(moneyClass1.Equals(moneyClass2));  //True 重写了这个方法
            Console.WriteLine(moneyRecord1 == moneyRecord2);     //true  自动重写了 == 
            Console.WriteLine(moneyRecord1.Equals(moneyRecord2));  //true   本身就是值类型比较
            // 输出结果
            Console.WriteLine(moneyClass1.ToString());
            Console.WriteLine(moneyRecord1.ToString());
        }


        //题目知识：
        // 1. record自动实现了基于值的比较（equals方法 和 == 操作符!=操作符， 以及重写object类的equals方法和gethashcode方法），重写了ToString方法
        // 2. class如果要实现Record一样的操作，需要处理很多代码
    }
    public class MoneyClass
    {
        public decimal Amount { get; }
        public string Currency { get; }
        public MoneyClass(decimal amount, string currency)
        {
            if (currency is null)
            {
                throw new ArgumentNullException();
            }
            Amount = amount;
            Currency = currency.ToUpperInvariant();
        }

        public bool Equals(MoneyClass? other)
        {
            if (other is null) return false;
            if (Amount == other.Amount && Currency == other.Currency)
            {
                return true;
            }
            return false;
        }
        public override bool Equals(object? obj)
        {
            return Equals(obj as MoneyClass);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Amount, Currency);
        }
        public static MoneyClass operator +(MoneyClass a, MoneyClass b)
        {
            if (a.Currency != b.Currency)
            {
                throw new InvalidOperationException();
            }
            return new MoneyClass(a.Amount + b.Amount, a.Currency);
        }
        public static MoneyClass operator -(MoneyClass a, MoneyClass b)
        {
            if (a.Currency != b.Currency)
            {
                throw new InvalidOperationException();
            }
            return new MoneyClass(a.Amount - b.Amount, a.Currency);
        }
        public override string ToString()
        {
            return $"{Amount:0.00} {Currency}";
        }
    }
    public record MoneyRecord
    {
        public decimal Amount { get; }
        public string Currency { get; }
        public MoneyRecord(decimal amount, string currency)
        {
            if (currency is null)
            {
                throw new ArgumentNullException();
            }
            Amount = amount;
            Currency = currency.ToUpperInvariant();
        }

        public static MoneyRecord operator +(MoneyRecord a, MoneyRecord b)
        {
            if (a.Currency != b.Currency)
            {
                throw new InvalidOperationException();
            }
            return new MoneyRecord(a.Amount + b.Amount, a.Currency);
        }
        public static MoneyRecord operator -(MoneyRecord a, MoneyRecord b)
        {
            if (a.Currency != b.Currency)
            {
                throw new InvalidOperationException();
            }
            return new MoneyRecord(a.Amount - b.Amount, a.Currency);
        }
        public override string ToString()
        {
            return $"{Amount:0.00} {Currency}";
        }
    }

}
