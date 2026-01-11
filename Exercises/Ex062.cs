using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProgrammingExercises100.Exercises
{
    internal class Ex062 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 062: 使用System.Text.Json序列化和反序列化对象 ---");
            // 题目描述
            string line = "JsonConverter是一个转换Person对象和Json之间类。实现JsonConverterHelper类，一个用来ToJson，一个用来FromJson。Person类包含Name和Age属性";
            Console.WriteLine(line);

            // 准备一些测试数据



            // 调用你的逻辑方法


            // 输出结果


        }


        //题目知识：
        // 1. Json序列化与反序列化都在静态类JsonSerializer中
        // 2. Serialize把类序列化成Json，Deserialize把Json反序列化成对象
        // 3. Deserialize方法有两种反序列化方式，一种是使用泛型直接指定类型Deserialize<T>,另一种是使用两个参数(反序列化对象，typeof(类名))，这样反序列化后仍然需要拆箱成目标对象
    }
    public class PersonJson
    {
        public string Name { get; }
        public int Age { get; }

        public PersonJson(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    public static class JsonConverter
    { 
        public static string ToJson(PersonJson personJson)
        {
            return JsonSerializer.Serialize(personJson);

        }
        public static Person FromJson(string json)
        {
            if (json == null)
            {
                throw new ArgumentNullException(nameof(json));
            }

            var person = JsonSerializer.Deserialize<Person>(json);
            if (person == null)
            {
                throw new InvalidOperationException("Failed to deserialize JSON to Person object.");
            }

            return person;
        }
    }

}
