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
    internal class Ex031 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 030: 检查井字棋的游戏结果 ---");
            // 题目描述
            string line = "井字棋Tic-Tac-Toe 游戏需要判断结果，实现GetTicTacToeResult方法，检查是否一个玩家获胜或平局，棋盘是3*3的，获胜条件是垂直水平斜diagonal line（对角线）的方向上三个元素连在一起";
            Console.WriteLine(line);

            // 准备一些测试数据

            char[,] test1 = new char[3, 3]
            {
                {'X', 'X', 'X'},
                {'O', 'O', 'X'},
                {'X', 'O', 'O'}
            };

            char[,] test2 = new char[3, 3]
            {
                {'O', 'X', 'X'},
                {'O', 'O', 'X'},
                {'X', 'O', 'O'}
            };


            // 调用你的逻辑方法



            // 输出结果
            Console.WriteLine(GetTicTacToeResult(test1));
            Console.WriteLine(GetTicTacToeResult(test2));
        }

        

        private static GameResult? CheckRows(char[,] grid)
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                if (grid[i, 0] == grid[i, 1] && grid[i, 0] == grid[i, 2])
                {
                    return grid[i, 0] == 'X' ? GameResult.XWins : GameResult.Owins;
                }
            }
            return null;
        }

        private static GameResult? CheckColumns(char[,] grid)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                if (grid[0, j] == grid[1, j] && grid[0, j] == grid[2, j])
                {
                    return grid[j, 0] == 'X' ? GameResult.XWins : GameResult.Owins;
                }
            }
            return null;
        }

        private static GameResult? CheckDiagonals(char[,] grid)
        {

            if (grid[0, 0] == grid[1, 1] && grid[0, 0] == grid[2, 2])
            {
                return grid[0, 0] == 'X' ? GameResult.XWins : GameResult.Owins;
            }
            if (grid[2, 0] == grid[1, 1] && grid[2, 0] == grid[0, 2])
            {
                return grid[0, 0] == 'X' ? GameResult.XWins : GameResult.Owins;
            }
            return null;
        }
        public GameResult GetTicTacToeResult(char[,] grid)
        {
            if (grid.GetLength(0) != 3 || grid.GetLength(1) != 3)
            {
                throw new ArgumentException("Grid is not 3*3", nameof(grid));
            }

            GameResult? rowWinner = CheckRows(grid);
            if (rowWinner != null)
            {
                return rowWinner.Value;
            }
            GameResult? columnWinner = CheckColumns(grid);
            if (columnWinner != null)
            {
                return columnWinner.Value;
            }
            GameResult? diagonalsWinner = CheckDiagonals(grid);
            if (diagonalsWinner != null)
            {
                return diagonalsWinner.Value;
            }
            return GameResult.Draw;

        }

        //题目知识：
        // 1. 一个复杂的方法可以拆分为几个private的内部方法，方便调用，提高可读性
        // 2. 二维数组初始化直接用{}分割维度就行，不用new关键字
        // 3. 枚举的值是具体的内容需要用.Value来访问
    }
    public enum GameResult
    {
        Draw,
        XWins,
        Owins
    }
}
