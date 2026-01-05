using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingExercises100.Exercises
{
    internal class Ex014 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 014: 整数求和并进行严格整数溢出检查 ---");
            // 题目描述
            string line = "请编写一个方法，接受一个整数集合，返回他们的和。如果整数溢出Integer Overflow发生，抛出OverflowException";
            Console.WriteLine(line);

            // 准备一些测试数据

            List<int> ints1 = new List<int>() { 1, int.MaxValue };
            List<int> ints2 = new List<int>() { 1, 2 };

            // 调用你的逻辑方法
            try
            {
                int result2 = StrictSum2(ints2);
                Console.WriteLine(result2);

                int result1 = StrictSum3(ints1);
                Console.WriteLine(result1);
                
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }


            // 输出结果

        }

        //方法1 ：循环，加上checked关键字，防止隐式溢出而没有提示
        public static int StrictSum1(IEnumerable<int> numbers)
        {
            int sum = 0;
            foreach (int number in numbers)
            {
                checked { sum += number; }
            }
            return sum;
        }

        //方法2 ：LINQ的Sum方法，让代码简单
        public static int StrictSum2(IEnumerable<int> numbers)
        {
            return checked(numbers.Sum());
        }

        //方法3 ：LINQ Sum自带checked不需要手动
        public static int StrictSum3(IEnumerable<int> numbers)
        {
            return numbers.Sum();  //sum自带checked
        }

        //题目知识：
        // 1. 看下面的代码，如果已经完成了加和，再判断是否溢出是没有意义的！
        // 2. checked可以检查代码是否发生溢出，防止溢出发生但是隐式处理异常
        // 3. LINQ sum方法代码内部自带checked，可以无需手动添加checked

        //try
        //{
        //    int sum = numbers.Sum();
        //    if (sum > int.MaxValue) //这样是不能捕获溢出的，因为已经完成了赋值，如果溢出也不能在这里判断
        //        throw new OverflowException();
        //    return sum;
        //}
        //catch (OverflowException)
        //{
        //    throw;
        //}
    }

}
