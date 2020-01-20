using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmDemo
{
    public class InsertSort
    {
        int e;
        int times, count;
        int[] a = { 15, 13, 12, 8, 7, 5, 3, 2, 1 };
        public void InserSortForPrint()
        {
            for (int i = 1; i < a.Length; ++i)
            {
                Console.WriteLine($"第{i }轮次排序");
                int t = a[i];
                int j = i;
                while ((j > 0) && a[j - 1] > t)
                {
                    times++;
                    ///相较于冒泡排序，插入排序减少了元素值“交换”的次数。
                    ///插入排序利用变量t暂时存储a[j]的值，等到本轮次排序结束之后再把t的值赋给a[j];
                    ///从而以“值变换”替代“值互换”减少开销。
                    a[j] = a[j - 1];
                    Console.Write($"j= {j}  t= {t} a[j] ={ a[j]}\ta[j-1]= { a[j - 1] } \t");
                    foreachArray();
                    --j;
                }
                Console.Write($"第{i }轮次排序一共进行了{times}次元素值变换。\t");
                a[j] = t;
                foreachArray();
                count += times;
                times = 0;
            }
            Console.WriteLine($"一共进行了{count}次值变换。");
        }

        /// <summary>
        /// 插入排序
        /// </summary>
        /// <param name="arrary"></param>
        /// <returns></returns>
        public int[] InserSortAlg(int[] arrary)
        {
            for(int i = 1; i < arrary.Length; i++)
            {
                int inserter = arrary[i];
                int index = i;
                while((index>0) &&  a[index-1]> inserter)
                {
                    a[index] = a[index - 1];
                    --index;
                }
                a[index] = inserter;
            }
            return arrary;
        }



        public void foreachArray()
        {
            for (e = 0; e < a.Length; e++)
            {
                Console.Write($"{a[e]}\t");
                if (e == a.Length - 1)
                {
                    Console.WriteLine();
                }
            }
        }

    }
}
