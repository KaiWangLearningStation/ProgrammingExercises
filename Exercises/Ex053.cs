using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace ProgrammingExercises100.Exercises
{
    internal class Ex053 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 053: 合并两个序列并使用默认回退值（fallback） ---");
            // 题目描述
            string line = "实现MergeNamesAndScores方法，接收两个列表，返回一个KeyValuePair<string,int>列表，把名字和分数匹配起来。如果两个列表的长度不同，则用默认值填充，缺失的name用null，缺失的int用0";
            Console.WriteLine(line);

            // 准备一些测试数据

            List<string?> names = new()
            {
                "name1", "name2", "name3"
            };
            List<int> scores = new()
            {
                1, 2, 3, 4, 5
            };

            // 调用你的逻辑方法

            var result = Merger.MergeNamesAndScores2(names, scores);

            // 输出结果
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key} : {item.Value}");
            }

        }


        //题目知识：
        // 1. 创建的是静态类，静态类不能创建实例，需要静态调用里面的方法
        // 2. 手动实现：创建键值对列表，每个键值对要用Create静态方法创建，在相同索引的时候直接创建，在超过公共索引的部分需要用if else控制，在创建这部分的时候，引入default关键字，填充默认值，记得把键值对都add到list中
        // 3. default关键字有的时候必须要使用，因为如果传入的是null，泛型有的时候不能自动推断类型，如果手动给KeyValuePair加上泛型内容，则这个时候就不是作为类来使用了，而是作为结构体来使用，此时不能调用Create方法， 因此必须要用default关键字来帮助确定类型
        // 4. LINQ中可以使用Concat串联来处理这样的两个列表对象，首先计算两者中最长的列表，然后使用Concat把两者都进行串联，串联的内容是default(type),长度是最长值-当前值。这样就能把不齐的两个列表变成长度相等。然后用zip来咬合起来，此时两个列表长度相等，使用zip不会丢弃内容，zip需要传入第二个列表，然后传入Func委托，有参数有返回值，这里需要根据最后的要求，返回值为KeyValuePair类型.
        // 5. KeyValuePair.Create(names, scores) 是调用静态方法创建对象，而new KeyValuePair<string?, int>(names, scores) 是创建结构体的实例，略有不同，两者均可

    }
    public static class Merger
    {
        // 方法1，手动实现
        public static List<KeyValuePair<string?, int>> MergeNamesAndScores1(List<string?> names, List<int> scores)
        {
            List<KeyValuePair<string?, int>> list = new List<KeyValuePair<string?, int>>();
            int maxLength = Math.Max(names.Count, scores.Count);
            int minLength = Math.Min(maxLength, names.Count);
            int namesCount = names.Count;
            int scoresCount = scores.Count;


            for (int i = 0; i < minLength; i++)
            {
                list.Add(KeyValuePair.Create(names[i], scores[i]));
            }
            if (namesCount == scoresCount)
            {
                return list;
            }
            else if (namesCount < scoresCount)
            {
                for (int j = minLength; j < maxLength; j++)
                {
                    list.Add(KeyValuePair.Create(default(string), scores[j]));
                }
            }
            else
            {
                for (int j = minLength; j < maxLength; j++)
                {
                    list.Add(KeyValuePair.Create(names[j], default(int)));
                }
            }
            return list;

        }
        // 方法2，使用LINQ的 Concat、Repeat、Zip、ToList
        public static List<KeyValuePair<string?, int>> MergeNamesAndScores2(List<string?> names, List<int> scores)
        {
            int maxLength = Math.Max(names.Count, scores.Count);

            var paddedNames = names
                .Concat(Enumerable.Repeat(default(string), maxLength - names.Count));

            var paddedScores = scores
                .Concat(Enumerable.Repeat(default(int), maxLength - scores.Count));

            return paddedNames
                .Zip(paddedScores, (names, scores) => new KeyValuePair<string?, int>(names, scores))
                //.Zip(paddedScores, (names, scores) => KeyValuePair.Create(names, scores))
                .ToList();

        }
    }
}
