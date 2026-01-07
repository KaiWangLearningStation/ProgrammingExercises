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
    internal class Ex037 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 037: 使用IComparable实现自定义数据排序 ---");
            // 题目描述
            string line = "IComparable<T> 接口用于定义对象的自然排序顺序，使得在列表或数组等集合中能够自动进行比较，例如在房地产目录中按房屋的建筑面积对房屋进行排序。你的任务是在 House 类中实现 IComparable<House> 接口，以根据两个 House 对象的 FloorArea 属性（按升序）进行比较。提供的 House 类包含 Address（字符串类型）和 FloorArea（十进制，单位为平方米）属性。该方法应返回一个整数，指示顺序（如果当前对象小于另一对象则返回负数，相等则返回零，大于则返回正数）。";
            Console.WriteLine(line);

            // 准备一些测试数据
            House house1 = new House("wangkai", 123);
            House house2 = new House("wangkai", 223);
            House house3 = new House("zzzz", 321);

            // 调用你的逻辑方法

            List<House> houses1 = new List<House>() { house1, house2, house3 };

            houses1.Sort();
            // 输出结果
            foreach (House house in houses1)
            {
                Console.WriteLine(house.FloorArea);
            }
            Console.WriteLine();

        }

        //题目知识：
        // 1. IComparable直接把排序的逻辑内置于待排序的类中，而IComparar需要单独创建一个比较类来实现这个接口，调用Sort的时候，必须实现IComparable才不会有异常
        // 2. List<T>调用Sort方法，实际是需要T满足IComparable
        // 3. A.Compare(B)，负数表示A在b前，正数表示B在A前
    }


    public class House : IComparable<House>
    {
        public string Address { get;}
        public decimal FloorArea { get;}

        public House(string address, decimal floorArea)
        {
            Address = address;
            FloorArea = floorArea;
        }
        public int CompareTo(House? other)
        {
            if (other == null)
                return 1;
            return FloorArea.CompareTo(other.FloorArea);
        }
    }

}
