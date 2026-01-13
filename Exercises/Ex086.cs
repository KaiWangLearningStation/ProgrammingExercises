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
    internal class Ex086 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 086: 将句子中的每个单词首字母大写 ---");
            // 题目描述
            string line = "实现CapitalizeWords方法，接收一个string句子，返回一个首字母大写的句子。额外要去除空格";
            Console.WriteLine(line);

            // 准备一些测试数据

            string str = "Lorem  ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";

            // 调用你的逻辑方法
            Console.WriteLine(TextTransformer.CapitalizeWords(str));

            // 输出结果

        }


        //题目知识：
        // 1. 首字母大写使用char.ToUpper静态方法传入string[index], 后续部分使用substring方法截取，再用ToLower实例方法即可
        // 2. string.Join静态方法能够用分隔符连接params参数
        // 3. 文本中如果有两个空格，使用split单空格分割后，会得到一个包含三个空字符串的数组，每个都是空的，不包含任何空格。最后Join的时候，在这三个空白之间插入空格，还原了最初的样子
    }
    public static class TextTransformer
    {
        public static string CapitalizeWords(string sentence)
        {
            var words = sentence
                .Trim()
                .Split(' ')
                .Select(word =>
                    string.IsNullOrEmpty(word) ?
                    word :
                    char.ToUpper(word[0]) + word.Substring(1).ToLower());

            return string.Join(" ", words);
        }
    }
}
