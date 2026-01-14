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
    internal class Ex094 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 094: 验证竞赛参与者 ---");
            // 题目描述
            string line = "实现ValidateParticipants方法，接收paticipants列表，返回值为bool，当验证有效时返回true。" +
                "验证规则，大于等于18岁，name和email非空或空白，email必须是唯一的";
            Console.WriteLine(line);

            // 准备一些测试数据
            List<Participant> participants = new List<Participant>()
            {
                new Participant("Name1", 20, "Email1"),
                new Participant("Name2", 20, "Email1"),
                new Participant("Name3", 20, "Email3"),
                new Participant("Name4", 20, "Email4"),
                new Participant("Name5", 20, "Email5"),
            };

            // 调用你的逻辑方法
            bool result1 = ParticipantValidator.ValidateParticipants1(participants);
            bool result2 = ParticipantValidator.ValidateParticipants2(participants);
            // 输出结果
            Console.WriteLine(result1);
            Console.WriteLine(result2);
        }


        //题目知识：
        // 1. LINQ组合应用
        // 2. 去重可以用DistinctBy，也可以转化成HashSet自动去重，因为这个数据类型不允许重复值。
    }
    public static class ParticipantValidator
    {
        public static bool ValidateParticipants1(List<Participant> participants)
        {
            if (participants is null)
            {
                throw new ArgumentNullException();
            }
            if (participants.Count == 0)
            {
                return false;
            }
            var validCount = participants
                .Where(participant => participant.Age >= 18)
                .Where(participant => !string.IsNullOrWhiteSpace(participant.Name) && !string.IsNullOrWhiteSpace(participant.Email))
                .DistinctBy(participant => participant.Email)
                .Count();

            return validCount == participants.Count;    
        }
        public static bool ValidateParticipants2(List<Participant> participants)
        {
            if (participants is null)
            {
                throw new ArgumentNullException();
            }
            if (participants.Count == 0)
            {
                return false;
            }
            bool areAllValid = participants
                .All(participant => participant is not null && participant.Age >= 18 && !string.IsNullOrWhiteSpace(participant.Name) && !string.IsNullOrWhiteSpace(participant.Email));
            if (!areAllValid )
            {
                return false;
            }

            var validCount = participants
                .Select(participant => participant.Email)
                .ToHashSet()
                .Count();

            return validCount == participants.Count;
        }
    }
    public record Participant(string Name, int Age, string Email);
}
