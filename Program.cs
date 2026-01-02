namespace ProgrammingExercises100
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.Write("请输入题号: ");

            // 1. 处理 Console.ReadLine 可能返回 null 的情况
            string? id = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(id))
            {
                Console.WriteLine("输入不能为空！");
                return;
            }

            // 2. 拼接类名（确保你的命名空间和类名格式严格对应）
            // 注意：如果是当前程序集，Type.GetType 需要完整的“命名空间.类名”
            string className = $"ProgrammingExercises100.Exercises.Ex{id}";

            // 3. 获取类型
            Type? type = Type.GetType(className);


            // 4. 使用模式匹配来同时检查 null 和 类型转换
            // Activator.CreateInstance 可能返回 null，所以用 'is' 来安全检查
            if (type != null && typeof(IExercise).IsAssignableFrom(type))
            {
                // 创建实例并尝试转换为接口
                if (Activator.CreateInstance(type) is IExercise exe)
                {
                    exe.Run();
                }
                else
                {
                    Console.WriteLine("无法创建练习实例。");
                }
            }
            else
            {
                Console.WriteLine($"未找到题目类: {className}。请检查类名是否为 Ex{id}。");
            }

            Console.WriteLine("\n按任意键退出...");
            Console.ReadKey();
        }

    }
}
