using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingExercises100.Exercises
{
    internal class Ex003 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 003: 给一个string变量计算字母频率 ---");
            // 题目描述
            string line = "请编写一个方法，接受一个字符串作为参数，统计每个字母的频率，以字典形式返回。";
            Console.WriteLine(line);

            // 准备一些测试数据
            var result1 = "Hello";
            var result2 = "Andy Wang";

            // 调用你的逻辑方法
            var dic1 = CountCharacterFrequenciesLinq(result1);
            var dic2 = CountCharacterFrequenciesLinq(result2);

            // 输出结果
            foreach (var item in dic1)
            {
                Console.Write($"['{item.Key}'] = {item.Value} ");
            }
            Console.WriteLine();

            foreach (var item in dic2)
            {
                Console.Write($"['{item.Key}'] = {item.Value} ");
            }

        }

        //方法1：访问字典的键，存在则值加1，不存在则值赋1
        public static Dictionary<char, int> CountCharacterFrequencies(string input)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();

            foreach (var item in input)
            {
                if (dic.ContainsKey(item))
                {
                    dic[item]++;
                }
                else
                {
                    dic.Add(item, 1);
                }
            }
            return dic;
        }

        //方法2：使用LINQ
        public static Dictionary<char, int> CountCharacterFrequenciesLinq(string input)
        {
            return input
                .GroupBy(character => character)
                .ToDictionary(group => group.Key, group => group.Count());
        }

        //题目知识：
        //1. 字典键值对的访问
        //2. LINQ中的GroupBy方法，把可迭代的内容按照本身分组，组名为本身，组的内容也为本身，如果有多个内容，都放在这个组内
        //3. LINQ中的ToDictionary方法，可以把组类型的数据，转化为字典，组可以作为键，组的Count可以作为计数
    }

}
