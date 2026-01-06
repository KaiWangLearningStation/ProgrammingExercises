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
    internal class Ex028 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 028: 泛型配对类型 ---");
            // 题目描述
            string line = "创建一个能容纳任意两个同类型值的配对类，包含两个属性，First和Second，这两个属性应该是只读的；构造函数可以设置这两个值；有一个public Swap方法来转换值，First和Second的内容交换；这个类应该能容纳任何同类型的值";
            Console.WriteLine(line);

            // 准备一些测试数据
            Pair<int> p1 = new Pair<int>(1, 2);
            Pair<string> p2 = new Pair<string>("First", "Second");

            // 调用你的逻辑方法
            p1.Swap();
            p2.Swap();


            // 输出结果
            Console.WriteLine($"P1.First:{p1.First}, P1.Second:{p1.Second}");
            Console.WriteLine($"P2.First:{p2.First}, P2.Second:{p2.Second}");

        }


        //题目知识：
        // 1.泛型类定义时候加上<T>，构造函数不需要加<T>
        // 2.set访问器可以加private，在类内可以设置值：外部只读，内部可修改
    }
    public class Pair<T> 
    {
        public T First { get; private set; }
        public T Second { get; private set; }

        public Pair(T t1, T t2)
        {
            First = t1;
            Second = t2;
        }
        public void Swap()
        {
            T tmp = First;
            First = Second;
            Second = tmp;
        }

    }
}
