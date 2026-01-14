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
    internal class Ex100 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 100: 生成随机巫师名字 ---");
            // 题目描述
            string line = "实现GenerateWizardName方法，用两个预定义列表：巫师名字和巫师头衔。方法随机选择一个名字和一个头衔，返回string类型的标准格式";
            Console.WriteLine(line);

            // 准备一些测试数据

            var names = new List<string>()
            {
                "Name1", "Name2", "Name3", "Name4", "Name5", "Name6"
            };


            var titles = new List<string>()
            {
                "Title1", "Title2", "Title3", "Title4", "Title5", "Title6"
            };

            // 调用你的逻辑方法
            var result = WizardNameGenerator.GenerateWizardName(names, titles, new Random());

            // 输出结果
            Console.WriteLine(result);
        }


        //题目知识：
        // 1. Random.Next接收一个int，生成从0到int左闭右开的整数
    }
    public static class WizardNameGenerator
    {
        public static string GenerateWizardName(List<string> names, List<string> titles, Random random)
        {
            ValidateInput(names, titles, random);
            var randomNameIndex = random.Next(names.Count);
            var Name = names[randomNameIndex];
            var randomTitleIndex = random.Next(titles.Count);
            var title = titles[randomTitleIndex];
            return $"{Name} the {title}";

        }

        private static void ValidateInput(List<string> names, List<string> titles, Random random)
        {
            if (names is null)
            {
                throw new ArgumentNullException();
            }
            if (titles is null)
            {
                throw new ArgumentNullException();
            }
            if (random is null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}
