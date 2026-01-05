using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingExercises100.Exercises
{
    internal class Ex021 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 020: 生成随机折扣码 ---");
            // 题目描述
            string line = "每个客户都有一个随机且唯一的折扣码，随机码包含字母和数字，编写一个DiscouintCodeGenerator类，使用一个注入的IRandom接口来从一个预定义的结合中选择字母，IRandom的工作和Random类一样，只是能够提高DiscountCodeGenerator的可测试性。DiscouintCodeGenerator方法包含以下要求：必须生成指定长度的字符串作为参数，每个字符都是从ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789随机生成的";
            Console.WriteLine(line);

            // 准备一些测试数据
            SystemRandomWrapper systemRandomWrapper = new SystemRandomWrapper();

            DiscountCodeGenerator discountCodeGenerator = new DiscountCodeGenerator(systemRandomWrapper);


            // 调用你的逻辑方法

            string result = discountCodeGenerator.GenerateDiscountCode(10);

            // 输出结果
            Console.WriteLine(result);

        }




        //题目知识：
        // 1.Random类生成随机数的方法Next，生成左闭右开的整数。
        // 2.用IRandom接口来实现依赖倒置原则，不再直接依赖于 System.Random，而是通过抽象接口来生成随机数，这里用了一个SystemRange的包装器类Wrapper，里面具体的实现还是生成了Random类的对象，然后调用的是Random的Next方法，可以方便的替换成别的Next方法，而不依赖于System.Random类

        //可测试性：可以使用 Mock 进行单元测试
        //灵活性：可以轻松切换不同的随机数生成策略
        //解耦：业务逻辑不依赖于具体的随机数实现
        //依赖注入友好：便于在 DI 容器中管理
    }

    public class DiscountCodeGenerator
    {
        private readonly IRandom _random;
        private const string Characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public DiscountCodeGenerator(IRandom random)
        {
            _random = random;
        }
        public string GenerateDiscountCode(int length)
        {
            char[] code = new char[length];

            for (int i = 0; i < length; i++)
            {
                int j = _random.Next(0, Characters.Length);
                code[i] = Characters[j];
            }

            return new string(code);
        }
    }
    public interface IRandom
    {
        int Next(int minValue, int maxValue);
    }

    public class SystemRandomWrapper : IRandom
    {
        private readonly Random _random = new Random();

        public int Next(int minValue, int maxValue)
        {
            return _random.Next(minValue, maxValue);
        }
    }


}
