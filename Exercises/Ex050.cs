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
    internal class Ex050 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 050: 展平嵌套的数字列表 ---");
            // 题目描述
            string line = "实现FlattenList方法，把一个嵌套List<List<int>>展平成List<int>";
            Console.WriteLine(line);

            // 准备一些测试数据

            var nestedList = new List<List<int>>()
            {
                new List<int>(){ 1, 2, 3 },
                new List<int>(){ 4, 5, 6 },
                new List<int>(){ 7, 8 }
            };

            // 调用你的逻辑方法
            List<int> resultList = FlattenList1(nestedList);

            // 输出结果
            foreach (int i in resultList)
            {
                Console.WriteLine(i);
            }

        }

        // 方法1：嵌套for
        public static List<int> FlattenList1(List<List<int>> nestedList)
        {
            if (nestedList == null)
                throw new ArgumentNullException();
            List<int> resultList = new List<int>();
            for (int i = 0; i < nestedList.Count; i++)
            {
                for (int j = 0; j < nestedList[i].Count; j++)
                {
                    resultList.Add(nestedList[i][j]);
                }
            }
            return resultList;
        }
        // 方法2：嵌套foreach
        public static List<int> FlattenList2(List<List<int>> nestedList)
        {
            if (nestedList == null)
                throw new ArgumentNullException();
            List<int> resultList = new List<int>();
            foreach (var innerList in nestedList)
            {
                foreach (var item in innerList)
                {
                    resultList.Add(item);
                }
            }
            return resultList;
        }
        // 方法3：LINQ SelectMany
        public static List<int> FlattenList3(List<List<int>> nestedList)
        {
            if (nestedList == null)
                throw new ArgumentNullException();
            
            return nestedList
                .Where(innerList => innerList != null)
                .SelectMany(innerList => innerList)
                .ToList();
        }
        //题目知识：
        // 1. 展平可以用循环，有几层就有几个循环
        // 2. LINQ的SelectMany专门用来展平，SelectMany和Select内部遍历的是每个子对象，如果是嵌套List，则遍历的是内层List，不能继续下探到内层List内的元素。但是返回类型是不同的，Select返回的是子对象的类型，即IEnumerable<List<T>>,而SelectMany直接进行扁平化，返回的是子对象中泛型的类型，即IEnumerable<int>


    }
}
