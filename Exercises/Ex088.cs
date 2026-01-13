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
    internal class Ex088 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 088: 格式化二维数组中的主对角线单词 ---");
            // 题目描述
            string line = "实现FormatDiagonalWords方法，接收一个方形二维string数组，所有的words都是大写的。方法需要让主对角线（左上到右下）元素转化为首字母大写，剩下是小写的形式。只要对角线元素List。";
            Console.WriteLine(line);

            // 准备一些测试数据

            string[,] words =
            {
                {"RONECONE","RONECTWO","RONECTHREE" },
                {"RTWOCONE","RTWOCTWO","RTWOCTHREE" },
                {"RTHREECONE","RTHREECTWO","RTHREECTHREE" }
            };

            // 调用你的逻辑方法
            var result1 = ArrayLinqPractice.FormatDiagonalWords1(words);
            var result2 = ArrayLinqPractice.FormatDiagonalWords2(words);
            var result3 = ArrayLinqPractice.FormatDiagonalWords3(words);

            // 输出结果
            foreach ( var word in result1)
            {
                Console.WriteLine(word);
            }
            Console.WriteLine();
            foreach (var word in result2)
            {
                Console.WriteLine(word);
            }
            Console.WriteLine();
            foreach (var word in result3)
            {
                Console.WriteLine(word);
            }
        }


        //题目知识：
        // 1. 注意二维数组不能用 words.Length来获取行，这个属性是所有元素是长度。如果要获取第一维度的长度，要用GetLength(0)。
        // 2. 如果用循环，注意是方形二维数组，只需要循环一次即可
        // 3. LINQ方法和Enumerable.Range联动，先生成索引序列，然后在这个索引序列上select即可取出对角线元素，然后可以再用select来进行格式化输出。这里还是用到了char.ToUpper静态方法和 string类型的实例substring和ToLower方法了
    }
    public static class ArrayLinqPractice
    {
        public static List<string> FormatDiagonalWords1(string[,] words)
        {
            int rows = words.GetLength(0);
            int cols = words.GetLength(1);
            List<string> result = new List<string>();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (i == j)
                    {
                        result.Add(words[i, j][0] + words[i, j].Substring(1).ToLower());
                    }
                }
            }
            return result;
        }
        public static List<string> FormatDiagonalWords2(string[,] words)
        {
            int rows = words.GetLength(0);
            List<string> result = new List<string>();

            for (int i = 0; i < rows; i++)
            {
                result.Add(words[i, i][0] + words[i, i].Substring(1).ToLower());
            }
            return result;
        }
        public static List<string> FormatDiagonalWords3(string[,] words)
        {
            int size = words.GetLength(0);

            return Enumerable.Range(0, size)
                .Select(i => words[i, i])
                .Where(word => !string.IsNullOrEmpty(word))
                .Select(word => char.ToUpper(word[0]) + word.Substring(1).ToLower())
                .ToList();
        }
    }
}
