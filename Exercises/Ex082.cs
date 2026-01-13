using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingExercises100.Exercises
{
    internal class Ex082 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 082: 为产品相等性实现自定义IEqualityCompa接口 ---");
            // 题目描述
            string line = "实现ProductNameBrandComparer类，ProductToCompare类有Name Brand Price属性，比较器应该要求Name和Brand一致，而不用比较Price";
            Console.WriteLine(line);

            // 准备一些测试数据

            ProductToCompare p1 = new ProductToCompare("wk", "wk", 300);
            ProductToCompare p2 = new ProductToCompare("wk", "wk", 800);


            // 调用你的逻辑方法
            var comparer = new ProductNameBrandComparer();
            bool result = comparer.Equals(p1, p2);

            // 输出结果
            Console.WriteLine(p1 == p2);
            Console.WriteLine(result);
            Console.WriteLine(p1.Equals(p2));
            Console.WriteLine(p1.GetHashCode());
            Console.WriteLine(p2.GetHashCode());


            //HashSet去重
            var products = new List<ProductToCompare>
            {
                new("Laptop", "Dell", 999.99m),
                new("Laptop", "Dell", 899.99m),  // 这个会被视为重复
                new("Laptop", "HP", 999.99m),
                new("Mouse", "Dell", 49.99m),
                new("Laptop", "HP", 799.99m)     // 这个会被视为重复
            };

            // 使用比较器创建 HashSet，会自动去重
            var uniqueProducts = new HashSet<ProductToCompare>(products, new ProductNameBrandComparer());

            Console.WriteLine($"去重前: {products.Count} 个产品");
            Console.WriteLine($"去重后: {uniqueProducts.Count} 个产品");

            // 遍历唯一的产品
            foreach (var product in uniqueProducts)
            {
                Console.WriteLine($"{product.Brand} {product.Name} - ${product.Price}");
            }

            //LINQ的set operation
            // 使用 Distinct 去重
            var distinctProducts = products.Distinct(new ProductNameBrandComparer()).ToList();

            foreach (var product in distinctProducts)
            {
                Console.WriteLine($"{product.Brand} {product.Name}");
            }

            // 按品牌和名称分组（使用自定义比较器）
            var grouped = products
                .GroupBy(p => p, new ProductNameBrandComparer())
                .Select(g => new
                {
                    Product = g.Key,
                    Count = g.Count(),
                    AvgPrice = g.Average(p => p.Price)
                });

            foreach (var group in grouped)
            {
                Console.WriteLine($"{group.Product.Brand} {group.Product.Name}: {group.Count} 个，平均价格 ${group.AvgPrice:F2}");
            }

        }


        //题目知识：
        // 1. IEqualityComparer<T>接口实现后，可以用该类的Equals方法，按照需求进行比较
        // 2. ReferenceEquals方法直接比较引用是否相等
        // 3. GetHashCode要和Equals方法配合起来，如果Equals中只包含部分的检查，GetHashCode也应该只包含这些属性的Combine
        // 4. 实现IEqualityComparer<T>，就能在LINQ中的Set Operation中调用例如Distinct方法 等
        // 5. HashSet构造函数中，也可以传入这个比较器类
    }
    public class ProductNameBrandComparer : IEqualityComparer<ProductToCompare>
    {
        public bool Equals(ProductToCompare? x, ProductToCompare? y)
        {
            if (x is null || y is null)
            {
                return false;
            }
            if (ReferenceEquals(x, y))
            {
                return true;
            }
            return x.Name == y.Name && x.Brand == y.Brand;
        }

        public int GetHashCode(ProductToCompare obj)
        {
            return HashCode.Combine(obj.Name, obj.Brand);
        }
    }
    public record ProductToCompare(string Name, string Brand, decimal Price);
}
