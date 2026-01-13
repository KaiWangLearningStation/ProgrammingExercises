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
    internal class Ex081 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 81: 查找两个集合的交集 ---");
            // 题目描述
            string line = "GetEmployeesWhoAreVolunteers方法接收两个集合，employees和volunterrs，这两个类型都有firstname和lastname。返回一个employees中fullname和volunteer中fullname一样的列表/";
            Console.WriteLine(line);

            // 准备一些测试数据

            List<EmployeeIntersect> employees = new List<EmployeeIntersect>()
            {
                new EmployeeIntersect("First1", "Last1"),
                new EmployeeIntersect("First1", "Last2"),
                new EmployeeIntersect("First2", "Last3"),
                new EmployeeIntersect("First3", "Last3")
            };

            List<VolunteerIntersect> volunteers = new List<VolunteerIntersect>()
            {
                new VolunteerIntersect("First1", "Last1"),
                new VolunteerIntersect("First2", "Last2"),
                new VolunteerIntersect("First2", "Last3"),
                new VolunteerIntersect("First3", "Last3")
            };

            // 调用你的逻辑方法
            var result = Intersect.GetEmployeesWhoAreVolunteers1(employees, volunteers);

            // 输出结果
            foreach (var item in result)
            {
                Console.WriteLine($"{item.FirstName} : {item.LastName}");
            }
        }


        //题目知识：
        // 1. 交集用Intersect，因为不是同一类型要用IntersectBy，关键在于如何提取各项的用来比较的唯一键，即两个参数就是用来最终判断是否相等的，第一个参数必须是另一个集合，而且比较的内容是FirstName和LastName，所以可以提取出volunteers的该信息，可以用+也可以用元组形式。第二个参数就是employees本身的同一元素。
        // 2. 使用Where和Any，Where要生成比较结果，对于每个e，要看volunteers中是否存在v满足v和e的两个比较值相等，如果存在则把这个匹配到的e取出来。性能不好  
        // 3. 使用hashset，把volunteer先做成hashset元组，然后用where比较这个hashset元组中，是否包含employee的同样元组。
    }
    public static class Intersect
    {
        public static List<EmployeeIntersect> GetEmployeesWhoAreVolunteers1(IEnumerable<EmployeeIntersect> employees, IEnumerable<VolunteerIntersect> volunteers)
        {
            return employees
                .IntersectBy(volunteers.Select(volunteer => volunteer.FirstName + volunteer.LastName),
                employee => employee.FirstName + employee.LastName)
                .ToList();
        }
        public static List<EmployeeIntersect> GetEmployeesWhoAreVolunteers2(IEnumerable<EmployeeIntersect> employees, IEnumerable<VolunteerIntersect> volunteers)
        {
            return employees
                .Where(e => volunteers.Any(v =>
                    v.FirstName == e.FirstName &&
                    v.LastName == e.LastName))
                .ToList();
        }
        public static List<EmployeeIntersect> GetEmployeesWhoAreVolunteers3(IEnumerable<EmployeeIntersect> employees, IEnumerable<VolunteerIntersect> volunteers)
        {
            // 创建志愿者姓名的 HashSet
            var volunteerNames = new HashSet<(string FirstName, string LastName)>(
                volunteers.Select(v => (v.FirstName, v.LastName)));

            return employees
                .Where(e => volunteerNames.Contains((e.FirstName, e.LastName)))
                .ToList();
        }
    }
    public record EmployeeIntersect(string FirstName, string LastName);
    public record VolunteerIntersect(string FirstName, string LastName);
}
