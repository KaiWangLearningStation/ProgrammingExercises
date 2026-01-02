using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingExercises100.Exercises
{
    internal class Ex002 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 002: 检查集合中是否存在负数 ---");
            string line = "请编写一个方法，接受一个整数集合作为参数，判断集合中是否存在负数。如果存在负数，返回 true；否则返回 false。";
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

        public static bool ContainsNegative(IEnumerable<int> numbers)
        {
            foreach (var number in numbers)
            {
                if (number < 0)
                {
                    return true;
                }
            }
            return false;
        }
    }

}
