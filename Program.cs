namespace ProgrammingExercises100
{
    internal class Program
    {

        static void Main(string[] args)
        {
            bool continueRunning = true;
            while (continueRunning)
            {
                Console.Clear(); // 清屏，使界面更清晰
                Console.WriteLine("========== 编程练习选择器 ==========");
                Console.Write("请输入题号 (输入 'q' 退出): ");

                // 1. 处理 Console.ReadLine 可能返回 null 的情况
                string? id = Console.ReadLine();
                Console.WriteLine();

                // 检查是否退出
                if (id?.ToLower() == "q")
                {
                    Console.WriteLine("程序退出，再见！");
                    continueRunning = false;
                    continue;
                }

                // 验证输入是否为空
                if (string.IsNullOrWhiteSpace(id))
                {
                    Console.WriteLine("输入不能为空！");
                    Console.WriteLine("按任意键重新输入...");
                    Console.ReadKey();
                    continue;
                }

                // 验证输入是否为数字
                if (!int.TryParse(id, out int exerciseId) || exerciseId <= 0)
                {
                    Console.WriteLine($"输入 '{id}' 不是有效的题号，请输入正整数！");
                    Console.WriteLine("按任意键重新输入...");
                    Console.ReadKey();
                    continue;
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

                // 询问是否继续
                Console.WriteLine("\n===================================");
                Console.Write("是否继续选择其他题目？(y/n): ");
                string? continueChoice = Console.ReadLine();

                if (continueChoice?.ToLower() != "y")
                {
                    Console.WriteLine("程序退出，再见！");
                    continueRunning = false;
                }
            }

            Console.WriteLine("\n按任意键退出...");
            Console.ReadKey();


        }

    }
}
