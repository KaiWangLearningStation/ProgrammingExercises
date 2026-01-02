using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingExercises100.Exercises
{
    internal class Ex001 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 001: 检查集合中是否存在负数 ---");

            //题目描述
            string line = "\n请编写一个方法，接受一个整数集合作为参数，判断集合中是否存在负数。如果存在负数，返回 true；否则返回 false。\n";
            Console.WriteLine(line);

            // 准备一些测试数据
            var testList1 = new List<int> { 1, 2, 3, 4, 5 };
            var testList2 = new List<int> { 1, 2, -3, 4, 5 };

            // 调用你的逻辑方法
            bool result1 = ContainsNegative(testList1);
            bool result2 = ContainsNegative(testList2);

            // 输出结果
            Console.WriteLine($"测试列表 [1, 2, 3, 4, 5] 结果: {result1}");
            Console.WriteLine($"测试列表 [1, 2, -3, 4, 5] 结果: {result2}");
        }

        //方法1：使用foreach循环遍历集合，检查是否存在负数
        public static bool ContainsNegative(IEnumerable<int> numbers)
        {
            foreach (var number in numbers)
            {
                if (number < 0)
                {
                    return true; //提前return，能够提高性能
                }
            }
            return false;
        }

        //方法2：使用LINQ的Any方法简化检查过程
        public static bool ContainsNegativeLinq(IEnumerable<int> numbers)
        {
            return numbers.Any(n => n < 0);
            //any方法表明：如果存在一个n满足n<0，整体返回true
        }

        //题目知识：
        //1. foreach 循环：用于遍历集合中的每个元素。
        //2. LINQ 的 Any 方法：用于检查集合中是否存在满足特定条件的元素。
    }

}
