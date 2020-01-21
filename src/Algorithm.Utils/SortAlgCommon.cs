using System;

namespace Algorithm.Utils
{
    public class SortAlgCommon
    {
        /// <summary>
        /// 插入排序
        /// </summary>
        /// <param name="arrary"></param>
        /// <returns></returns>
        public static int[] InserSortAlg(int[] arrary)
        {
            // 相较于冒泡排序，插入排序减少了元素值“交换”的次数。
            // 插入排序利用变量t暂时存储a[j]的值，等到本轮次排序结束之后再把t的值赋给a[j];
            // 从而以“值变换”替代“值互换”减少开销。
            for (int i = 1; i < arrary.Length; i++)
            {
                //当前值（插入值）
                int inserter = arrary[i];
                //当前索引位
                int index = i;
                //从次往前比较
                while ((index > 0) && arrary[index - 1] > inserter)
                {
                    arrary[index] = arrary[index - 1];
                    --index;
                }
                arrary[index] = inserter;
            }
            return arrary;




        }


        /// <summary>
        /// 归并排序（目标数组，子表的起始位置，子表的终止位置）
        /// </summary>
        /// <param name="array"></param>
        /// <param name="first"></param>
        /// <param name="last"></param>
        public static void MergeSortFunction(int[] array, int first, int last)
        {
            if (first < last)   //子表的长度大于1，则进入下面的递归处理
            {
                int mid = (first + last) / 2;   //子表划分的位置
                MergeSortFunction(array, first, mid);   //对划分出来的左侧子表进行递归划分
                MergeSortFunction(array, mid + 1, last);    //对划分出来的右侧子表进行递归划分
                MergeSortCore(array, first, mid, last); //对左右子表进行有序的整合（归并排序的核心部分）
            }
        }
        /// <summary>
        /// 归并排序的核心部分：将两个有序的左右子表（以mid区分），合并成一个有序的表
        /// </summary>
        /// <param name="array"></param>
        /// <param name="first"></param>
        /// <param name="mid"></param>
        /// <param name="last"></param>
        private static void MergeSortCore(int[] array, int first, int mid, int last)
        {

            //左侧子表的起始位置
            int indexA = first;
            //右侧子表的起始位置
            int indexB = mid + 1;
            //声明数组（暂存左右子表的所有有序数列）：长度等于左右子表的长度之和。
            int[] temp = new int[last + 1];
            int tempIndex = 0;
            //进行左右子表的遍历，如果其中有一个子表遍历完，则跳出循环
            while (indexA <= mid && indexB <= last)
            {
                ////此时左子表的数 <= 右子表的数
                if (array[indexA] <= array[indexB])
                {
                    //将左子表的数放入暂存数组中，遍历左子表下标++
                    temp[tempIndex++] = array[indexA++];
                }
                //此时左子表的数 > 右子表的数
                else
                {
                    //将右子表的数放入暂存数组中，遍历右子表下标++
                    temp[tempIndex++] = array[indexB++];
                }
            }
            //有一侧子表遍历完后，跳出循环，将另外一侧子表剩下的数一次放入暂存数组中（有序）
            while (indexA <= mid)
            {
                temp[tempIndex++] = array[indexA++];
            }
            while (indexB <= last)
            {
                temp[tempIndex++] = array[indexB++];
            }
            //将暂存数组中有序的数列写入目标数组的制定位置，使进行归并的数组段有序
            tempIndex = 0;
            for (int i = first; i <= last; i++)
            {
                array[i] = temp[tempIndex++];
            }
        }


        /// <summary>
        /// 一次排序单元，完成此方法，key左边都比key小，key右边都比key大。
        /// </summary>
        /// <param name="array">array排序数组 </param>
        /// <param name="low">low排序起始位置 </param>
        /// <param name="high">high排序结束位置</param>
        public static int SortOfUnit(int[] array, int low, int high)
        {
            int key = array[low];
            while (low < high)
            {
                //从后向前搜索比key小的值
                while (array[high] >= key && high > low)
                    --high;
                //比key小的放左边
                array[low] = array[high];
                //从前向后搜索比key大的值，比key大的放右边
                while (array[low] <= key && high > low)
                    ++low;
                //比key大的放右边
                array[high] = array[low];
            }
            //左边都比key小，右边都比key大。
            //将key放在游标当前位置。
            //此时low等于high
            array[low] = key;
            foreach (int i in array)
            {
                Console.Write("{0}\t", i);
            }
            Console.WriteLine();
            return high;
        }
        /// <summary>
        /// 快速排序
        /// </summary>
        /// <param name="array">array排序数组 </param>
        /// <param name="low">low排序起始位置 </param>
        /// <param name="high">high排序结束位置</param>
        public static void QuickSort(int[] array, int low, int high)
        {
            if (low >= high)
                return;
            //完成一次单元排序
            int index = SortOfUnit(array, low, high);
            //对左边单元进行排序
            QuickSort(array, low, index - 1);
            //对右边单元进行排序
            QuickSort(array, index + 1, high);
        }


        /// <summary>
        /// 选择排序
        /// </summary>
        /// <param name="arr"></param>
        public static void SelectionSort(int[] arr)
        {
            int i, j, min, len = arr.Length;
            int temp;
            for (i = 0; i < len - 1; i++)
            {
                min = i;
                for (j = i + 1; j < len; j++)
                    if (arr[min].CompareTo(arr[j]) > 0)
                        min = j;
                temp = arr[min];
                arr[min] = arr[i];
                arr[i] = temp;
            }
        }
    }
}

