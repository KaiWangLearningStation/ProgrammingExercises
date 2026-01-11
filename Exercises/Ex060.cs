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
    internal class Ex060 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 060: 检查类型是否实现特定接口 ---");
            // 题目描述
            string line = "实现ImplementsInterface方法，接收Type参数表示类和Type参数表示Interface，如果这个方法实现了这个接口返回true";
            Console.WriteLine(line);

            // 准备一些测试数据


            bool result = ImplementsInterface(typeof(List<int>), typeof(IEnumerable<int>));


            // 调用你的逻辑方法


            // 输出结果

            Console.WriteLine(result);
        }
        //题目知识：
        // 1. 使用反射可以处理Type类型的参数，GetInterfaces可以获取类所有实现的接口，作为接口数组，然后可以用Any方法返回布尔值】
        // 2. Type类型的参数需要用typeof关键字来获取
        public static bool ImplementsInterface(Type type, Type interfaceType)
        {
            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }
            if (interfaceType is null)
            {
                throw new ArgumentNullException(nameof(interfaceType));
            }
            if (!interfaceType.IsInterface)
            {
                return false;
            }
            return type.GetInterfaces()
                .Any(interfaceName => interfaceName == interfaceType);
        }
        

    }
}
