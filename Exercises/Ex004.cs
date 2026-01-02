using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingExercises100.Exercises
{
    internal class Ex004 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 004: 字典内容筛选 ---");
            // 题目描述
            string line = "请编写一个方法，接受一个字典作为参数，根据字典值来进行筛选，记录超过50分的名字，但是如果遇到一个100分，则停止记录，后续的内容抛弃，以列表形式返回。";
            Console.WriteLine(line);

            // 准备一些测试数据
            Dictionary<string, int> dic1 = new Dictionary<string, int>()
            {
                { "Anna", 45 },
                { "Ben", 80 },
                { "Uki", 70 },
                { "Cara", 100 },
                { "Derek", 90 },
                { "Ella", 70 },
            };


            // 调用你的逻辑方法
            var list1 = GetQualifiedPlayers(dic1);
            var list2 = GetQualifiedPlayersLinq(dic1);

            // 输出结果
            foreach (var item in list1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            foreach (var item in list2)
            {
                Console.WriteLine(item);
            }

        }

        //方法1：循环访问字典的每个键值对，通过条件来进行筛选，使用列表Add方法写入列表
        public static List<string> GetQualifiedPlayers(Dictionary<string, int> playerScores)
        {
            const int minScore = 50;
            const int maxScore = 100;

            List<string> result = new List<string>();

            foreach (var item in playerScores)
            {
                if (item.Value < minScore)
                {
                    continue;  //跳出本次循环
                }

                if (item.Value >= maxScore)
                {
                    break;     //停止循环
                }

                result.Add(item.Key);
                
            }
            return result;
        }

        //方法2：使用LINQ
        public static List<string> GetQualifiedPlayersLinq(Dictionary<string, int> playerScores)
        {
            const int minScore = 50;
            const int maxScore = 100;

            return playerScores
                .TakeWhile(item => item.Value < maxScore)
                .Where(item => item.Value > minScore)
                .Select(item => item.Key)
                .ToList();
        }

        //题目知识：
        //1. 遍历字典，使用continue和break来做循环处理，提高性能
        //2. LINQ的TakeWhile方法，从可遍历对象循环，抓取符合条件的项，直到不符合条件，后续就不抓取了
        //3. LINQ的Where方法做筛选，Select可以从字典中只选择键或者值，最后转换成List
        //4. 使用const是好的编程习惯
    }
}
