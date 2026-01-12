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
    internal class Ex068 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 068: 合并两个用户集合并保证邮箱唯一 ---");
            // 题目描述
            string line = "实现MergeUniqueEmails方法，接收两个User对象列表。每个User都包含Id和Email，假设两个集合中的User都是唯一的，但是可能有重复的Email。该方法返回唯一Email的User列表，如果有重复Email只保留第一个集合的元素。";
            Console.WriteLine(line);

            // 准备一些测试数据

            List<User> list1 = new List<User>()
            {
                new User(1,"email1"),
                new User(2,"email2"),
                new User(3,"email3"),
                new User(4,"email4"),
            };
            List<User> list2 = new List<User>()
            {
                new User(1,"email1"),
                new User(2,"email2"),
                new User(3,"email5"),
                new User(4,"email6"),
            };

            // 调用你的逻辑方法

            var result1 = UserUtils.MergeUniqueEmails1(list1, list2);
            var result2 = UserUtils.MergeUniqueEmails2(list1, list2);
            var result3 = UserUtils.MergeUniqueEmails3(list1, list2);
            // 输出结果

            foreach (var item in result1)
            {
                Console.WriteLine($"{item.Id}: {item.Email}");
            }
            Console.WriteLine();
            foreach (var item in result2)
            {
                Console.WriteLine($"{item.Id}: {item.Email}");
            }
            Console.WriteLine();
            foreach (var item in result3)
            {
                Console.WriteLine($"{item.Id}: {item.Email}");
            }
        }


        //题目知识：
        // 1. 手动实现列表合并并去重，可以多个数据结构，如果用List，则把一个集合全都加入进来，在加入另一个集合元素的时候，判断某个key是否也就存在：使用LINQ Select遍历结果列表的key，看他是否包含contains这个结果。
        // 2. 使用Dictionary结构的时候，考虑清楚，要把key作为唯一值，存放的是用来标识唯一值的结构，例如本例中的email，而不能是id。
        // 3. 要时刻理解现在正在操作的是数据结构中的什么内容。foreach (User user in user1) 是每个元素，则与之匹配的也应该是元素，result.Select(n => n.Email).Contains(user.Email)  、result.Keys.Contains(user.Email)
        // 4. LINQ中有集合操作的方法 Distinct去重 Except差集 Intersect交集 Union并集 这四个方法都只能操作同一类型的集合。但是加上By后的四个方法可以操作不同类型的集合，只要有能够用来比较的key就行。
    }
    public class User
    {
        public int Id { get; private set; }
        public string Email { get; private set; }
        public User(int id, string email)
        {
            Id = id;
            Email = email;
        }
    }
    public static class UserUtils
    {
        public static List<User> MergeUniqueEmails1(IEnumerable<User> user1, IEnumerable<User> user2)
        {
            List<User> result = new List<User>();
            foreach (User user in user1)
            {
                result.Add(user);
            }
            foreach (User user in user2)
            {
                if (result.Select(n => n.Email).Contains(user.Email))
                {
                    continue;
                }
                result.Add(user);
            }
            return result;
        }
        public static List<User> MergeUniqueEmails2(IEnumerable<User> user1, IEnumerable<User> user2)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            foreach (User user in user1)
            {
                result.Add(user.Email, user.Id);
            }
            foreach (User user in user2)
            {
                if (result.Keys.Contains(user.Email))
                {
                    continue;
                }
                result.Add(user.Email, user.Id);
            }
            return result.Select(n => new User(n.Value, n.Key)).ToList();
        }
        public static List<User> MergeUniqueEmails3(IEnumerable<User> user1, IEnumerable<User> user2)
        {
            return user1.UnionBy(user2, User => User.Email).ToList();
        }
    }

}
