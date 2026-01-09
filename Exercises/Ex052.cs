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
    internal class Ex052 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 040: 定义基于值的房屋数据结构 ---");
            // 题目描述
            string line = "定义一个House类型，带有Address属性、FloorArea属性、BedroomCount属性和HasGarage属性。需要满足基于值的相等性、不可变性、ToString方法、解构方法等。";
            Console.WriteLine(line);

            // 准备一些测试数据



            // 调用你的逻辑方法


            // 输出结果


        }


        //题目知识：
        // 1. 题目要求：
        // 基于值的相等性：比较两个House对象时，应该比较它们的属性值，而不是引用。实现IEquatable接口，实现Equals方法
        // 不可变性：创建后属性值不能更改
        // ToString方法：提供友好的字符串表示
        // 解构方法：可以方便地将属性分解到变量中

        // 实现1：用类实现
            // 1. 重写 object.Equals 是必须的：因为很多旧的 API 或非泛型的类库（以及 System.Object 本身）只知道 Equals(object)。如果不重写它，当你把 House 放在非泛型容器里时，逻辑就会出错。重写后，运行时多态会根据实际类型调用Equals方法。
            // 2. obj as House1：as安全地将object类型转换为House类型，转换成功返回一个House类型的对象，转换失败返回null
            // 3. 实现IEquatable的Equals(House1? other)方法，调用类型安全的Equals，避免装箱，编译时类型检查
            // 4. 重写了基类的Equals必须也要重写GetHashCode方法
            // 5. 可选：重载运算符，重写了Equals最好也要重载运算符
            // 6. 解构方法：把对象拆分为多个变量

        // 实现2：用record记录实现
            // record是基于值的比较，能够自动实现上述class实现的所有代码，无需显式编写

    }
}
