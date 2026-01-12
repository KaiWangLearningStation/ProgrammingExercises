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
    internal class Ex072 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 072: 使用SortedList创建简单单词词典 ---");
            // 题目描述
            string line = "SortedList是存储排序的key-value pairs的数据结构。在添加元素等操作的时候，基于key自动排序。" +
                "实现WordDictionary类，key是word，大小敏感，唯一。value是单词定义";
            Console.WriteLine(line);

            // 准备一些测试数据

            WordDictionary wordDictionary = new WordDictionary();
            wordDictionary.AddWord("wangkai", "Designer");

            // 调用你的逻辑方法


            // 输出结果
            Console.WriteLine(wordDictionary.GetDefinition("wangkai"));
            var all = wordDictionary.GetAllWords();
            foreach (var item in all)
            {
                Console.WriteLine(item);
            }

        }


        //题目知识：
        // 1. SortedList和字典几乎一样，内部在Add的时候会进行排序
        // 2. SortedList不能有重复key，抛出异常
    }
    public class WordDictionary
    {
        private readonly SortedList<string, string> _words = new SortedList<string,string>();

        public void AddWord(string word, string definition)
        {
            if (_words.ContainsKey(word))
            {
                throw new ArgumentException("this word already existed");
            }
            _words.Add(word, definition);
        }
        public string GetDefinition(string key)
        {
            if (!_words.ContainsKey(key))
            {
                throw new KeyNotFoundException();
            }
            return _words[key];
        }
        public List<string> GetAllWords()
        {
            return new List<string>(_words.Keys);
        }
    }
}
