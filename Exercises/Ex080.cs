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
    internal class Ex080 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 80: 将整数划分为等大小的块 ---");
            // 题目描述
            string line = "实现GetFullChunks方法，接收一个int数组和一个int类型的chunkSize分块大小。这个方法就是把input分割成sub-arrays，每个片段长度是chunkSize。最后的chunk比chunkSize小的话，不包括这个块。如果chunkSize比input都长，结果应该为空。返回数组列表，";
            Console.WriteLine(line);

            // 准备一些测试数据



            // 调用你的逻辑方法


            // 输出结果

        }


        //题目知识：
        // 1. 可以使用for循环，每次跳过i*chunkSize个元素，取chunkSize个元素，然后可以转化为数组，每次循环做一次列表Add操作。最后循环结束能够获得块数组。这里利用了除法的特性，控制循环次数，忽略余数就恰好是忽略掉最后不满足的块
        // 2. 直接使用chunk方法是最简单的，参数为size，chunk是带有不足的块的，需要用Where额外处理
    }
    public static class ChunkUtils
    { 
        public static List<int[]> GetFullChunks1(int[] input, int chunkSize)
        {
            if (input == null)
            {
                throw new ArgumentNullException();
            }
            List<int[]> result = new List<int[]>();
            int chunkCount = input.Length / chunkSize;
            for (int i = 0; i < chunkCount; i++)
            {
                var chunk = input
                    .Skip(i * chunkSize)
                    .Take(chunkSize)
                    .ToArray();
                result.Add(chunk);
            }
            return result;
        }

        public static List<int[]> GetFullChunks2(int[] input, int chunkSize)
        {
            if (input == null)
            {
                throw new ArgumentNullException();
            }

            return input
                .Chunk(chunkSize)
                .Where(chunk => chunk.Length == chunkSize)
                .ToList();
        }
    }
}
