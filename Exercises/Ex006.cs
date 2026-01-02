using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingExercises100.Exercises
{
    internal class Ex006 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 006: 返回最高值，包含null值处理 ---");
            // 题目描述
            string line = "请编写一个方法，更新最高分并记录在player的Statistics中，player参数可空，他的statistics也可空。如果两者都为空，方法一个什么都不做，如果HighestScore为空，把他的值设置为newScore，如果存在HighestScore，且比newScore低，更新HighestScore";
            Console.WriteLine(line);

            // 准备一些测试数据
            Player? player1 = null;  //player为null
            var player2 = new Player();    //player的statisitic为空
            var player3 = new Player();    //player的statisitic为空
            player3.Statistics = new Statistics();  //player的statisitic的HighestScore为空
            player3.Statistics.HighestScore = null;

            var player4 = new Player();
            player4.Statistics = new Statistics();
            player3.Statistics.HighestScore = 50;

            var player5 = new Player();    //player的statisitic为空
            player5.Statistics = new Statistics();
            player5.Statistics.HighestScore = 80;

            // 调用你的逻辑方法
            UpdateHighestScore(player1, 75);
            //Console.WriteLine(player1.Statistics.HighestScore);  异常
            UpdateHighestScore(player2, 75);
            //Console.WriteLine(player2.Statistics.HighestScore);  异常
            UpdateHighestScore(player3, 75);
            Console.WriteLine(player3.Statistics.HighestScore);
            UpdateHighestScore(player4, 75);
            Console.WriteLine(player4.Statistics.HighestScore);
            UpdateHighestScore(player5, 75);
            Console.WriteLine(player5.Statistics.HighestScore);

            // 输出结果


        }



        //方法1：逐层条件判断
        public static void UpdateHighestScore(Player? player, int newScore)
        {
            if (player == null)
            {
                return;
            }
            if (player.Statistics == null)
            {
                return;
            }
            if (player.Statistics.HighestScore == null)
            {
                player.Statistics.HighestScore = newScore;
                return;
            }
            if (player.Statistics.HighestScore > newScore)
            {
                return;
            }
            player.Statistics.HighestScore = newScore;
        }

        //方法2：使用null相关的操作符
        // ?.空条件运算符，说明这个变量可能为空，不需要警告，代码允许这个变量为空，不会直接抛出异常
        // ??= 空合并赋值运算符，无返回值，左侧为空则把右侧赋给左边，否则为左边的值不变
        // ?? 空接合（合并）运算符，有返回值，左侧不为空返回左侧，否则返回右侧
        public static void UpdateHighestScore1(Player? player, int newScore)
        {
            if (player?.Statistics is null)
            {
                return;
            }

            player.Statistics.HighestScore ??= newScore;

            if (player.Statistics.HighestScore < newScore)
            {
                player.Statistics.HighestScore = newScore;
            }
        }

        //题目知识：
        // ?.空条件运算符，说明这个变量可能为空，不需要警告，代码允许这个变量为空，不会直接抛出异常
        // ??= 空合并赋值运算符，无返回值，左侧为空则把右侧赋给左边，否则为左边的值不变
        // ?? 空接合（合并）运算符，有返回值，左侧不为空返回左侧，否则返回右侧
    }
    class Player
    {
        public Statistics? Statistics { get; set; }
    }
    class Statistics
    {
        public int? HighestScore { get; set; }
    }

}
