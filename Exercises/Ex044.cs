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
    internal class Ex044 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 044: 二分查找算法 ---");
            // 题目描述
            string line = "实现BinarySearch算法。二分查找找到一个目标整数，找到返回index，找不到返回-1";
            Console.WriteLine(line);

            // 准备一些测试数据
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };

            int result1 = BinarySearch1(array, 3);
            int result2 = BinarySearch2(array, 3);
            int result3 = BinarySearch3(array, 3);
            int result4 = BinarySearch4(array, 3);


            // 调用你的逻辑方法


            // 输出结果
            Console.WriteLine(result1);
            Console.WriteLine(result2);
            Console.WriteLine(result3);
            Console.WriteLine(result4);

        }
        // 方法1，手动实现
        public static int BinarySearch1(int[] numbers, int target)
        {
            if (numbers is null)
            {
                throw new ArgumentNullException(nameof(numbers), "Array cannot be null");
            }

            int left = 0;
            int right = numbers.Length - 1;

            while (left < right)
            {
                int middle = (left + right) / 2;
                if (target == numbers[middle])
                {
                    return middle;
                }
                else if (target < numbers[middle])
                {
                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }
            }
            return -1;
        }

        // 方法2，手动实现，利用linq
        public static int BinarySearch2(int[] numbers, int target)
        {
            if (numbers is null)
            {
                throw new ArgumentNullException(nameof(numbers), "Array cannot be null");
            }

            while (numbers.Length > 0)
            {
                int middle = numbers.Length - 1;
                if (target == numbers[middle])
                {
                    return middle;
                }
                else if (target < numbers[middle])
                {
                    numbers = numbers.Take(middle - 1).ToArray();
                }
                else
                {
                    numbers = numbers.TakeLast(middle - 1).ToArray();
                }
            }
            return -1;
        }

        // 方法3：使用内部实现BinarySearch的数据结构：Array静态方法 List<T>实例方法
        public static int BinarySearch3(int[] numbers, int target)
        {
            return Array.BinarySearch(numbers, 3);
        }
        public static int BinarySearch4(int[] numbers, int target)
        {
            List<int> result = numbers.ToList();
            result.Sort();
            return result.BinarySearch(target);
        }
        // 自定义类型的BinarySearch，需要T实现IComparable接口即有自己的CompareTo方法
        // public static int BinarySearch<T>(IList<T> list, T value) where T : IComparable<T>


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
