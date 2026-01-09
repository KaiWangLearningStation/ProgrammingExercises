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
    internal class Ex049 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("--- 练习 049: 实现排序算法 ---");
            // 题目描述
            string line = "手动实现排序算法";
            Console.WriteLine(line);

            // 准备一些测试数据

            int[] ints1 = { 13, 3, 11, 2, 12, 4, 5, 9, 6, 7, 8, 10 };

            // 调用你的逻辑方法

            int[] Bubble = new int[ints1.Length];
            ints1.CopyTo(Bubble, 0);
            BubbleSort(Bubble);
            Console.Write("BubbleSort: ");
            foreach (int i in Bubble)
            {
                Console.Write($"{i}  ");
            }
            Console.WriteLine();

            int[] Selection = (int[])ints1.Clone();
            SelectionSort(Bubble);
            Console.Write("SelectionSort: ");
            foreach (int i in Bubble)
            {
                Console.Write($"{i}  ");
            }
            Console.WriteLine();

            // 输出结果


        }
        // 方法1：冒泡排序 BubbleSort 最简单但是性能不好
        public static void BubbleSort(int[] numbers)
        {
            int n = numbers.Length;
            for (int i = 0; i < n - 1; i++)
            {
                bool swapped = false;
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        int tmp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = tmp;
                        swapped = true;
                    }
                }
                if (swapped == false)
                {
                    break;
                }
            }
        }

        // 方法2：选择排序 SelectionSort
        public static void SelectionSort(int[] arr)
        {
            int n = arr.Length;

            for (int i = 0; i < n - 1; i++)
            {
                // 找到最小元素的索引
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[minIndex] > arr[j])
                    {
                        minIndex = j;
                    }
                }
                // 交换元素
                if (minIndex != i)
                {
                    int tmp = arr[i];
                    arr[i] = arr[minIndex];
                    arr[minIndex] = tmp;
                }
            }
        }
        // 方法3：插入排序 InsertionSort
        public static void InsertionSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; i++)
            {
                int key = arr[i];
                int j = i - 1;
                // 将比key大的元素向后移动1位
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j + 1] = key;
            }
        }
        //初始： [5] 2 4 6 1 3   ← 5单独时是已排序的
        //第1步： [2 5] 4 6 1 3  ← 2插入到5前面
        //第2步： [2 4 5] 6 1 3  ← 4插入到2和5之间
        //第3步： [2 4 5 6] 1 3  ← 6插入到最后
        //第4步： [1 2 4 5 6] 3  ← 1插入到最前面
        //第5步： [1 2 3 4 5 6]  ← 3插入到2和4之间
       


        // 方法4：快速排序 QuickSort
        public static void QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(arr, low, high);

                QuickSort(arr, low, pi - 1);
                QuickSort(arr, pi + 1, high);
            }
        }

        private static int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    // 交换元素
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            // 将枢轴放到正确位置
            int temp1 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp1;

            return i + 1;
        }



        //题目知识：
        // 1. 冒泡排序：每次循环把最大值冒泡到最后一位，下一次循环可以忽略掉最后一位，因此用双重for循环，外层设置bool值为false，当内层发生交换时把bool置为true，内层循环结束后检查bool是否仍未false，如果是则说明这一次没有发生任何交换，说明已经排序完成了，剩下的外层循环就能跳过了
        // 2. 选择排序：找到最小元素的索引，把这个索引对应的值放在最前方，然后从下一个位置开始循环这个过程。外层循环i把arr[i]的i先看作最小值的索引，然后从下一个开始内层循环，循环比较arr[i]和内层的arr[j]，查找比arr[i]小的时候，把索引交给i继续比较，最终能比较出来最小索引，然后做交换即可
        // 3. 插入排序：外层循环从第二个元素开始，把这个元素作为key，然后从这个元素的前一个元素开始，比较每个值和key的关系，如果比key大，则说明key的值应该插入到这个找到的元素前，则意味着可以反过来，把这个值往后推一个即arr[j+1] = arr[j],每次循环j--，即往前遍历，直到找不到值比key大，或者j已经是负数了，就停止，这个时候，要做的就是把key的值赋给最后做了后推操作的哪个位置。即最后一次满足条件的arr[j]，因为j做了--操作，所以最后的赋值应该是arr[j+1] = key

    }
}
