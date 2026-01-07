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
    internal class Ex039 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 039: 定义基于值的房屋数据结构 ---");
            // 题目描述
            string line = "定义一个House类型，带有Address属性、FloorArea属性、BedroomCount属性和HasGarage属性。需要满足基于值的相等性、不可变性、ToString方法、解构方法等。";
            Console.WriteLine(line);

            // 准备一些测试数据
            // 创建不可变对象
            var house1 = new House1("123 Main St", (decimal)150.5, 3, true);
            var house2 = new House1("123 Main St", (decimal)150.5, 3, true);
            var house3 = new House1("456 Oak Ave", (decimal)200.0, 4, false);

            // 测试基于值的相等性
            Console.WriteLine($"house1 == house2: {house1 == house2}"); // true
            Console.WriteLine($"house1 == house3: {house1 == house3}"); // false

            // 使用ToString方法
            Console.WriteLine(house1); // 自动调用ToString()
            Console.WriteLine(house3.ToString());

            // 使用解构方法
            var (address, area, bedrooms, hasGarage) = house1;
            Console.WriteLine($"解构结果: {address}, {area}平方米, {bedrooms}卧室, 车库: {hasGarage}");


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

    // 实现1：用类实现
    public class House1 : IEquatable<House1> 
    {
        public string Address { get; }
        public decimal FloorArea { get; }
        public int BedroomCount { get; }
        public bool HasGarage { get; }

        public House1(string address, decimal floorArea, int badroomCount, bool hasGarage)
        {
            Address = address;
            FloorArea = floorArea;
            BedroomCount = badroomCount;
            HasGarage = hasGarage;
        }
        // 重写Equals方法，当引用变量为基类object时候，调用实际对象类型的Equals方法，判断是否传入的比较对象是House1类型，如果是则调用Equals(House1? other)
        public override bool Equals(object? obj)
        {
            return Equals(obj as House1);
        }
        // 实现IEquatable接口，满足值类型比较
        public bool Equals(House1? other)
        {
            if (other == null) return false;
           

            return Address == other.Address &&
                   FloorArea == other.FloorArea &&
                   BedroomCount == other.BedroomCount &&
                   HasGarage == other.HasGarage;
        }

        // 重写GetHashCode
        public override int GetHashCode()
        {
            return HashCode.Combine(Address, FloorArea, BedroomCount, HasGarage);
        }
        // 5. 可选：重载运算符，重写了Equals最好也要重载运算符
        public static bool operator ==(House1? left, House1? right)
        {
            if (left is null) return right is null;
            return left.Equals(right);
        }

        //ToString方法实现
        public static bool operator !=(House1? left, House1? right)
        {
            return !(left == right);
        }
        public override string ToString()
        {
            return $"House at {Address}: {FloorArea:F1} sq.m, {BedroomCount} bedroom(s), Garage: {(HasGarage ? "Yes" : "No")}";
        }

        // 3. 解构方法实现（允许将对象分解为多个变量）
        public void Deconstruct(out string address, out decimal floorArea, out int bedroomCount, out bool hasGarage)
        {
            address = Address;
            floorArea = FloorArea;
            bedroomCount = BedroomCount;
            hasGarage = HasGarage;
        }
    }
    // 实现2：用record记录实现
    public record House2(string address, decimal floorArea, int badroomCount, bool hasGarage);

}
