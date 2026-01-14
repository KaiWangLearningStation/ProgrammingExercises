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
    internal class Ex097 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 097: 在烘培产品层次中重写虚方法和抽象方法 ---");
            // 题目描述
            string line = "给烘焙产品设计一个类层级。BakedProduct抽象基类有抽象方法GetBakingInstruction，返回string; 一个virtural readonly属性Description，默认返回A generic baked product" +
                "创建两个派生类Bread和Cake" +
                "重写GetBakingInstruction方法，重写Description属性";
            Console.WriteLine(line);

            // 准备一些测试数据
            Bread bread = new Bread();
            Cake cake = new Cake();


            // 调用你的逻辑方法
            Console.WriteLine(bread.GetBakingInstruction());
            Console.WriteLine(bread.Description);
            // 输出结果
            Console.WriteLine(cake.GetBakingInstruction());
            Console.WriteLine(cake.Description);
        }


        //题目知识：
        // 1. 抽象方法完全没有实现，虚方法提供了基础实现
        // 2. public virtual string Description => "A generic baked product.";这个很像方法。但是实际上是属性，这里箭头表达式表示这个属性只有一个get访问器，访问器的return内容是 "A generic baked product."
    }
    public abstract class BakedProduct
    {
        public abstract string GetBakingInstruction();
        public virtual string Description
        {
            get
            {
                return "A generic baked product.";
            }
        }
        //public virtual string Description => "A generic baked product.";
    }
    public class Bread : BakedProduct
    {
        public override string GetBakingInstruction()
        {
            return "Bake at 220C for 30 minutes";
        }
    }

    public class Cake : BakedProduct
    {
        public override string GetBakingInstruction()
        {
            return "Bake at 180C for 45 minutes";
        }
        public override string Description => "A sweet and festive cake";
    }
}
