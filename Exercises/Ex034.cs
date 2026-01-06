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
    internal class Ex034 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 034: 计算折扣价格 ---");
            // 题目描述
            string line = "计算商品应用折扣和税费后的最终价格，CalculateDiscountedPrice方法接受：基础价格、商品类型、折扣价格。ApplyTax方法接受：数量、额外税费." +
                "1.验证 basePrice 和 discountPercentage 是否非负，如果任意一个为负数，则抛出 ArgumentOutOfRangeException。同时验证 discountPercentage 不超过 100，如果超过，则抛出 ArgumentOutOfRangeException。" +
                "2.计算折扣后的价格。具体方法为：从基础价格中扣除相应的折扣比例。例如，若基础价格为 200，折扣比例为 20%，则折扣后价格为 160（即 200 的 80%）。" +
                "3.使用提供的 ApplyTax 方法，对折扣后的价格进行税费计算。";
            Console.WriteLine(line);

            // 准备一些测试数据


            // 调用你的逻辑方法

            Console.WriteLine(CalculateDiscountedPrice(100, GoodsType.BasicGoodsTax));
            Console.WriteLine(CalculateDiscountedPrice(100, GoodsType.LuxuryGoodsExtraTax));

            // 输出结果

        }

        private const int BasicGoodsTax = 7;
        private const int LuxuryGoodsExtraTax = 9;
        // 方法1：循环法，不能实现惰性求值lazily evaluated，没有使用yield return
        public static decimal CalculateDiscountedPrice(decimal basePrice, GoodsType goodsType, decimal discountPercentage = 10m)
        {
            if (basePrice < 0 || discountPercentage < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (discountPercentage > 100)
            {
                throw new ArgumentOutOfRangeException();
            }
            decimal priceAfterDiscount = basePrice * (100 - discountPercentage) / 100m;

            return goodsType == GoodsType.LuxuryGoodsExtraTax ? ApplyTax(priceAfterDiscount, LuxuryGoodsExtraTax) : ApplyTax(priceAfterDiscount);

        }

        public static decimal ApplyTax(decimal amount, decimal extraTax = 0m)
        {
            var taxRate = BasicGoodsTax + extraTax;
            if (amount < 0 || taxRate < 0)
            {
                throw new ArgumentException();
            }

            // 计算含税价格
            decimal priceWithTax = amount * (1 + taxRate / 100m);

            return priceWithTax;
        }

        //题目知识：
        // 1. 参数如果有默认值，则可以传入这个参数也可以不传入，不传入的时候就是默认值，很像多了重载
        // 2. 数值后加m是decimal的标志，d是double，f是float

    }
    public enum GoodsType
    {
        BasicGoodsTax,
        LuxuryGoodsExtraTax
    }
}
