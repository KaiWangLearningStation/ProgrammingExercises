using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingExercises100.Exercises
{
    internal class Ex016 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 016: virtual虚方法和override重写方法 ---");
            // 题目描述
            string line = "请编写一个类，ShoutFormatter类能够把字符串的空格去除，转化为大写并且在末尾添加三个!，WhisperFormatter能够把字符串空格取出，转化为小写，并且用括号括起来";
            Console.WriteLine(line);

            // 准备一些测试数据

            string test = "   hello   ";

            // 调用你的逻辑方法

            TextFormatter formatter = new TextFormatter();
            ShoutFormatter shoutFormatter = new ShoutFormatter();
            WhisperFormatter whisperFormatter = new WhisperFormatter();

            Console.WriteLine(formatter.Format(test));
            Console.WriteLine(shoutFormatter.Format(test));
            Console.WriteLine(whisperFormatter.Format(test));

            // 输出结果


        }


        //题目知识：
        // 1. 字符串操作方法联系
        // Trim去除前后空格（TrimStart和TrimEnd去除前、后空格）
        // ToUpper ToLower变大写或小写
        // Insert方法在第一个参数位置插入第二个参数的内容
        // Join方法不能直接在一个字符串上面使用，需要两个字符串才能操作

        // 2. virtual虚方法，可以被重写，不会影响这个方法的调用
        // override重写方法，保证调用时候的方法签名一致

        // 3. 直接用格式化输出，$
        // return $"SHOUT: {processed}!!!"; 
        // return $"whisper: ({processed})";
    }
    public class TextFormatter
    {
        public virtual string Format(string message)
        {
            string processed = message.Trim();
            return $"Message: {processed}";
        }
    }
    public class ShoutFormatter: TextFormatter
    {
        public override string Format(string message)
        {
            string processed = message.Trim().ToUpper();
            string result = string.Join("", processed, "!!!");
            string result1 = processed.Insert(processed.Length, "!!!");
            return $"SHOUT: {result1}"; 
        }
    }

    public  class WhisperFormatter: TextFormatter
    {
        public override string Format(string message)
        {
            string processed = message.Trim().ToLower();
            string result = processed.Insert(0, "(").Insert(processed.Length + 1, ")");
            return $"whisper: {result}";
        }
    }
}
