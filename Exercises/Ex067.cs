using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingExercises100.Exercises
{
    internal class Ex067 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 067: 使用反射和自定义属性Attribute查找标记方法 ---");
            // 题目描述
            string line = "实现一个[RunMe]特性，和一个静态方法GetMarkedMethodNames。特性只能使用在方法上，GetMarkedMethodNames接收一个Type，返回带有[RunMe]方法名称列表。";
            Console.WriteLine(line);

            // 准备一些测试数据
            var result1 = RunMeFinder.GetMarkedMethodNames1(typeof(Demo));
            var result2 = RunMeFinder.GetMarkedMethodNames2(typeof(Demo));

            // 调用你的逻辑方法


            // 输出结果
            foreach (var item in result1)
            {
                Console.WriteLine(item);
            }
            foreach (var item in result2)
            {
                Console.WriteLine(item);
            }

        }


        //题目知识：
        // 1. 创建Attribute要注意命名public class NameAttribute，一定要继承：Attribute。最后要在类上方加入AttributeUsage: AttributeTarget.etc
        // 2. 反射获取方法集合要使用GetMethods方法，注意如果要访问所有方法，需要传入BindingFlags，用 | 隔开
        // 3. 获取方法集合后，用LINQ可以遍历每个方法，此时可以调用GetCustomAttributes方法，获取特性，可以用泛型方法直接传入类型，这样返回的就是T类型的IEnumerable[]，如果不用泛型，而是用typeof+特性名，有一个object[]转化为IEnumerable[]的过程，有一些性能损耗
        // 4. GetCustomAttributes 后返回的是IEnumerable，此时要注意，集合可以是空，但是不是null，区别是空表示有对象，但是对象里面没有元素，而null表示没有对象。即一个是空引用，一个是有引用，引用指向空值。
        // 5. MethodInfo类型包含很多信息，如果只需要Name需要Select Name 出来

    }

    public class Demo
    {
        [RunMe]
        public void Start() { }
        public void Helper() { }
        [RunMe]
        private void Secret() { }
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class RunMeAttribute : Attribute
    {

    }

    public static class RunMeFinder
    {
        public static List<string> GetMarkedMethodNames1(Type type)
        {
            var methodsInfo = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

            return methodsInfo
                .Where(method => method.GetCustomAttributes(typeof(RunMeAttribute)).Count() > 0)
                .Select(method => method.Name)
                .ToList();
        }
        public static List<string> GetMarkedMethodNames2(Type type)
        {
            var methodsInfo = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

            return methodsInfo
                .Where(method => method.GetCustomAttributes<RunMeAttribute>().Count() > 0)
                .Select(method => method.Name)
                .ToList();
        }
    }

}
