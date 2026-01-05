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
    internal class Ex024 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 024: 通过运算符重载实现矩阵相加 ---");
            // 题目描述
            string line = "实现一个类Matrix：能够完成两个矩阵的相加，这个类用二维数组存储整数值，包含两个属性行数和列数，两个属性在构造器中初始化。任务是：添加一个indexer索引器，实现访问和修改元素，通过matrix[row,column]语法；重载+运算符，来实现矩阵加法";
            Console.WriteLine(line);

            // 准备一些测试数据

            Matrix m1 = new Matrix(3,4);
            Matrix m2 = new Matrix(3,4);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    m1[i, j] = i;
                    m2[i, j] = j;
                }
            }
            //0000
            //1111
            //2222
            
            //0123
            //0123
            //0123


            // 调用你的逻辑方法

            Matrix m3 = m1 + m2;

            // 输出结果
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(m3[i,j]);
                }
                Console.WriteLine();
            }
            //0123
            //1234
            //2345

        }


        //题目知识：
        // 1.自定义数据解构的方法：定义类，字段，构造器，索引器，数据解构特殊的操作符
        // 2.int[,]表示二维数组，构造器的意义是在创建实例的时候，传入什么参数，需要怎么把传入的参数和字段联系起来
        // 3.索引器使用this关键字（可以理解为作为方法名），里面包含get和set访问器，get表示输入[]参数后获得值的规则，set表示怎么从外界给里面的数据赋值，注意有一个value可以使用。
        // 4.字段的readonly表示 局部变量的引用本身不可变（不能重新赋值），即_data永远指向一个数组对象，而不能重新指向另一个对象，而对象内部的值是不受这个readonly管理的，所以索引器中可以set值
        // 5.方法重载overload 和 方法重写override是完全不同的概念，重载是方法签名不一致但是方法名一致的时候选择哪个具体方法的情况，而重写是在继承链上，拥有同样的方法签名。重载不需要有特殊的修饰符，而重写一定是abstract或virtual与override搭配使用。重载是编译时绑定（静态绑定），是静态多态，重写是运行时绑定（动态绑定），是动态多态

    }
    public class Matrix
    {
        private readonly int[,] _data;
        private readonly int _rowsCount;
        private readonly int _columnsCount;

        public Matrix(int rowsCount, int columnsCount)
        {
            _rowsCount = rowsCount;
            _columnsCount = columnsCount;
            _data = new int[_rowsCount, _columnsCount];   //这里初始化后，_data只能指向这个对象，而不能指向别的对象了
        }

        public int this[int row, int column]
        {
            get
            {
                return _data[row, column];
            }
            set
            {
                _data[row, column] = value;
            }
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a._rowsCount == b._rowsCount && a._columnsCount == b._columnsCount)
            {
                Matrix result = new Matrix(a._rowsCount, a._columnsCount);
                for (int i = 0; i < a._rowsCount; i++)
                {
                    for (int j = 0; j < a._columnsCount; j++)
                    {
                       result[i,j] = a[i,j] + b[i,j];
                    }
                    
                }
                return result;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }


}
