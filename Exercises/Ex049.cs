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

            // 冒泡排序
            int[] Bubble = new int[ints1.Length];
            ints1.CopyTo(Bubble, 0);
            BubbleSort(Bubble);
            Console.Write("BubbleSort: ");
            foreach (int i in Bubble)
            {
                Console.Write($"{i}  ");
            }
            Console.WriteLine();

            // 选择排序
            int[] Selection = (int[])ints1.Clone();
            SelectionSort(Selection);
            Console.Write("SelectionSort: ");
            foreach (int i in Selection)
            {
                Console.Write($"{i}  ");
            }
            Console.WriteLine();

            // 插入排序
            int[] Insertion = (int[])ints1.Clone();
            InsertionSort(Insertion);
            Console.Write("InsertionSort: ");
            foreach (int i in Insertion)
            {
                Console.Write($"{i}  ");
            }
            Console.WriteLine();

            // 快速排序
            int[] Quick = (int[])ints1.Clone();
            QuickSort(Quick, 0, Quick.Length - 1);
            Console.Write("QuickSort: ");
            foreach (int i in Quick)
            {
                Console.Write($"{i}  ");
            }
            Console.WriteLine();

            // 归并排序
            int[] Merge = (int[])ints1.Clone();
            MergeSort(Merge, 0, Merge.Length - 1);
            Console.Write("MergeSort: ");
            foreach (int i in Merge)
            {
                Console.Write($"{i}  ");
            }
            Console.WriteLine();

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
        public static void QuickSort(int[] arr, int low, int high) //low起始索引，high结束索引
        {
            if (low < high)
            {
                // （13, 3, 11, 2, 12, 4, 5, 9, 6, 7, 8, 10）
                int pi = Partition(arr, low, high);
                // （3, 2, 4, 5, 9, 6, 7, 8, 10, 13, 12, 11）

                //pi = 9

                // （3, 2, 4, 5, 9, 6, 7, 8}
                QuickSort(arr, low, pi - 1);
                // （3, 2, 4, 5, 6, 7, 8, 9}  pi = 6
                //  (3, 2, 4, 5, 6, 7) (9) 对于9来说，low=0 high = 0,不进入循环了
                //  (3, 2, 4, 5, 6) 
                //  (3, 2, 4, 5) 
                //  (3, 2, 4) 
                //  (3, 2) 
                //  (2, 3) 
                //  (3)

                // （13, 12, 11}
                QuickSort(arr, pi + 1, high);
                //  (11, 13, 12)
                //  (13, 12)
                //  (12, 13)
                //  (13)
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
                    Swap(arr, i, j);
                    //int temp = arr[i];
                    //arr[i] = arr[j];
                    //arr[j] = temp;
                }
            }
            // （13, 3, 11, 2, 12, 4, 5, 9, 6, 7, 8, 10）
            // （3, 13, 11, 2, 12, 4, 5, 9, 6, 7, 8, 10）
            // （3, 2, 11, 13, 12, 4, 5, 9, 6, 7, 8, 10）
            // （3, 2, 4, 13, 12, 11, 5, 9, 6, 7, 8, 10）
            // （3, 2, 4, 5, 12, 11, 13, 9, 6, 7, 8, 10）
            // （3, 2, 4, 5, 9, 11, 13, 12, 6, 7, 8, 10）
            // （3, 2, 4, 5, 9, 6, 13, 12, 11, 7, 8, 10）
            // （3, 2, 4, 5, 9, 6, 7, 12, 11, 13, 8, 10）
            // （3, 2, 4, 5, 9, 6, 7, 8, 11, 13, 12, 10）
            // 将枢轴放到正确位置
            Swap(arr, i + 1, high);
            //int temp1 = arr[i + 1];
            //arr[i + 1] = arr[high];
            //arr[high] = temp1;
            // （3, 2, 4, 5, 9, 6, 7, 8, 10, 13, 12, 11）
            return i + 1;
            // return轴所在的索引 9
        }
        private static void Swap(int[] nums, int i, int j)
        {
            (nums[j], nums[i]) = (nums[i], nums[j]);
        }

        // 原始数据：13, 3, 11, 2, 12, 4, 5, 9, 6, 7, 8, 10 
        // low = 0，high = 11
        // 第一次循环：pivot = arr[11] == 10, i = -1;  从low到high前一位遍历（13, 3, 11, 2, 12, 4, 5, 9, 6, 7, 8,）（不用和自己比较）
        // 如果 arr[j] < pivot, 左边指针i++，交换元素i和j指针的位置，如果不满足条件，继续循环
        // 此次arr[j] = 3 < pivot, i++ 变成1，交换arr[0]和arr[2]  （3, 13, 11, 2, 12, 4, 5, 9, 6, 7, 8, 10）


        // 方法5：归并排序 MergeSort
        public static void MergeSort(int[] arr, int left, int right) // left起始索引0，right终止索引11
        {
            //（13, 3, 11, 2, 12, 4, 5, 9, 6, 7, 8, 10）
            // left = 0  right = 11  mid = 5
            if (left < right)  // 当子数组长度为 1 时终止递归
            {
                // 划分阶段
                int mid = left + (right - left) / 2;

                MergeSort(arr, left, mid);// 递归左子数组
                //(13, 3, 11, 2, 12, 4)
                //(13, 3, 11),(2, 12, 4)
                //(13, 3) (11), (2, 12) (4)
                
                MergeSort(arr, mid + 1, right);// 递归右子数组
                // 5, 9, 6, 7, 8, 10
                //...
                //

                // 合并阶段
                Merge(arr, left, mid, right);
                //[(13) (3)] (11) [(2) (12)] (4)
                //[(3,13 (11)] [(2,12) (4)]
                //[3,11,13] [2,4,12]
                //[2,3,4,11,12,13]
                //[5,6,7,8,9,10]
                //[2,3,4,5,6,7,8,9,10,11,12,13]

            }
        }

        private static void Merge(int[] arr, int left, int mid, int right)
        {
            // 左子数组区间为 [left, mid], 右子数组区间为 [mid+1, right]
            // 创建一个临时数组 tmp ，用于存放合并后的结果
            int[] tmp = new int[right - left + 1];
            // 初始化左子数组和右子数组的起始索引
            int i = left, j = mid + 1, k = 0;
            // 当左右子数组都还有元素时，进行比较并将较小的元素复制到临时数组中
            while (i <= mid && j <= right)
            {
                if (arr[i] <= arr[j])
                    tmp[k++] = arr[i++];
                else
                    tmp[k++] = arr[j++];
            }
            // 将左子数组和右子数组的剩余元素复制到临时数组中
            while (i <= mid)
            {
                tmp[k++] = arr[i++];
            }
            while (j <= right)
            {
                tmp[k++] = arr[j++];
            }
            // 将临时数组 tmp 中的元素复制回原数组 nums 的对应区间
            for (k = 0; k < tmp.Length; ++k)
            {
                arr[left + k] = tmp[k];
            }
        }


        //题目知识：
        // 1. 冒泡排序：每次循环把最大值冒泡到最后一位，下一次循环可以忽略掉最后一位，因此用双重for循环，外层设置bool值为false，当内层发生交换时把bool置为true，内层循环结束后检查bool是否仍未false，如果是则说明这一次没有发生任何交换，说明已经排序完成了，剩下的外层循环就能跳过了
        // 2. 选择排序：找到最小元素的索引，把这个索引对应的值放在最前方，然后从下一个位置开始循环这个过程。外层循环i把arr[i]的i先看作最小值的索引，然后从下一个开始内层循环，循环比较arr[i]和内层的arr[j]，查找比arr[i]小的时候，把索引交给i继续比较，最终能比较出来最小索引，然后做交换即可
        // 3. 插入排序：外层循环从第二个元素开始，把这个元素作为key，然后从这个元素的前一个元素开始，比较每个值和key的关系，如果比key大，则说明key的值应该插入到这个找到的元素前，则意味着可以反过来，把这个值往后推一个即arr[j+1] = arr[j],每次循环j--，即往前遍历，直到找不到值比key大，或者j已经是负数了，就停止，这个时候，要做的就是把key的值赋给最后做了后推操作的哪个位置。即最后一次满足条件的arr[j]，因为j做了--操作，所以最后的赋值应该是arr[j+1] = key
        // 4. 快速排序：传入arr和index的范围0 - arr.Length-1。首先确定pivot枢轴为最后一个元素，然后开始对前面的元素进行遍历，设置左指针从-1开始，右指针为0，如果右指针处的值比pivot值小，左指针+1，交换左右指针的值，如果右指针比pivot大则开始下次循环左指针不变。这样循环后，再把pivot枢轴和循环后的左指针i的下一位 i+1交换，此时priov已经在最终的位置了，左侧都比他小，右侧都比他大。用分治的思想，分别处理左侧的区域和右侧的区域，即调用自身方法，控制low和high的范围即可，最后的循环停止条件是，low = high时，即拿掉枢轴后，只剩下一个元素时。此时排序就完成了。
        // 5. 归并排序：思想是把数组一分为二，如果两边都已经排好序了，则直接用一个合并方法合并起来即可。但是显然没有直接排好序，则可以循环这个过程，把左右两侧的重复这个过程，直到子数组长度为 1 时终止递归。开始合并操作。合并操作先创建一个临时数组，长度是左右两个数组长度只和，设置左侧数组的指针i = left，右侧数组的指针j = mid + 1，k = 0。当左右两侧数组都有元素的时候，比较左侧第一个值和右侧第一个值，把较小的放在最前面，从哪里取出哪个数组指针向后一位，k也向后一位。当某一个数组已经取完的时候，说明不用再比较了，可以把剩余元素的数组剩下的值全都加载临时数组的最后了。然后把临时数组赋值到left标号为起点的对应长度的位置上即可
    }
}
