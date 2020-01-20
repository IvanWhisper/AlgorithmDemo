# 常规算法之数列排序算法
## Sorting Algorithm 数列排序算法
数列排序算法是指将由n个数字（默认为正整数）组成的数列以从小到大的方式排列并输出。
排序算法可以分为内部排序和外部排序，内部排序是数据记录在内存中进行排序，而外部排序是因排序的数据很大，一次不能容纳全部的排序记录，在排序过程中需要访问外存。常见的内部排序算法有：插入排序、希尔排序、选择排序、冒泡排序、归并排序、快速排序、堆排序、基数排序等。
#### 十大经典排序算法
1. 冒泡排序
2. 选择排序
3. 插入排序
4. 希尔排序
5. 归并排序
6. 快速排序
7. 堆排序
8. 计数排序
9. 桶排序
10. 基数排序
#### 时间复杂度 
|算法|平均时间复杂度|稳定性|
|-|-|-|
|插入排序 (Insert Sort)|O(n^2)|稳定|
|合并排序 (Merge Sort)|O(n*logn)|稳定|
|快速排序 (Quick Sort)|O(n*logn)|不稳定|
|选择排序 (Selection Sort) |O(n^2)|不稳定|
#### 1. 插入排序
插入排序（Insertion sort）是一种简单直观且稳定的排序算法。如果有一个已经有序的数据序列，要求在这个已经排好的数据序列中插入一个数，但要求插入后此数据序列仍然有序，这个时候就要用到一种新的排序方法——插入排序法,插入排序的基本操作就是将一个数据插入到已经排好序的有序数据中，从而得到一个新的、个数加一的有序数据，算法适用于少量数据的排序，时间复杂度为O(n^2)。是稳定的排序方法。插入算法把要排序的数组分成两部分：第一部分包含了这个数组的所有元素，但将最后一个元素除外（让数组多一个空间才有插入的位置），而第二部分就只包含这一个元素（即待插入元素）。在第一部分排序完成后，再将这个最后元素插入到已排好序的第一部分中。

##### a. 基本思想
每步将一个待排序的记录，按其关键码值的大小插入前面已经排序的文件中适当位置上，直到全部插入完为止。

##### b. 模拟样例
数列：{9，8，7，6，5，4，3，2，1}
1. {<font color="red">8，9，</font><font color="green">7，</font>6，5，4，3，2，1}
2. {<font color="red">7，8，9，</font><font color="green">6，</font>5，4，3，2，1}
3. {<font color="red">6，7，8，9，</font><font color="green">5，</font>4，3，2，1}
4. {<font color="red">5，6，7，8，9，</font><font color="green">4，</font>3，2，1}
5. {<font color="red">4，5，6，7，8，9，</font><font color="green">3，</font>2，1}
6. {<font color="red">3，4，5，6，7，8，9，</font><font color="green">2，</font>1}
7. {<font color="red">2，3，4，5，6，7，8，9，</font><font color="green">1</font>}
8. {<font color="red">1，2，3，4，5，6，7，8，9</font>}

##### c. C#代码实现
```C#
/// <summary>
/// 插入排序
/// </summary>
/// <param name="arrary"></param>
/// <returns></returns>
public static int[] InserSortAlg(int[] arrary)
{
// 相较于冒泡排序，插入排序减少了元素值“交换”的次数。
// 插入排序利用变量t暂时存储a[j]的值，
// 等到本轮次排序结束之后再把t的值赋给a[j];
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
```

#### 2. 合并排序
合并排序是建立在归并操作上的一种有效的排序算法。该算法是采用分治法（Divide and Conquer）的一个非常典型的应用。
合并排序法是将两个（或两个以上）有序表合并成一个新的有序表，即把待排序序列分为若干个子序列，每个子序列是有序的。然后再把有序子序列合并为整体有序序列。
将已有序的子序列合并，得到完全有序的序列；即先使每个子序列有序，再使子序列段间有序。若将两个有序表合并成一个有序表，称为2-路归并。合并排序也叫归并排序。
##### a. 基本思想
合并排序是采用分治策略实现对 n 个元素进行排序的算法，是分治法的一个典型应用和
完美体现。它是一种平衡、简单的二分分治策略，过程大致分为：
+ 分解 — 将待排序元素分成大小大致相同的两个子序列。
+ 治理 — 对两个子序列进行合并排序。
+ 合并 — 将排好序的有序子序列进行合并，得到最终的有序序列。
##### b. 模拟样例
原数组 {2，4，7，5，8，1，3，6}
1. 分解 {2，4，7，5} {8，1，3，6}
2. 分解 {2，4} {7，5} {8，1} {3，6}
3. 分解 {2} {4} {7} {5} {8} {1} {3} {6}
4. 合并 {2，4} {5，7} {1，8} {3，6}
5. 合并 {2,4,5,7} {1,3,6,8}
6. 合并 {1，2，3，4，5，6，7，8}
##### c. C#实现代码
```C#
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
```

#### 3. 快速排序
快速排序（Quicksort）是对冒泡排序的一种改进。
快速排序由C. A. R. Hoare在1960年提出。它的基本思想是：通过一趟排序将要排序的数据分割成独立的两部分，其中一部分的所有数据都比另外一部分的所有数据都要小，然后再按此方法对这两部分数据分别进行快速排序，整个排序过程可以递归进行，以此达到整个数据变成有序序列。
##### a. 基本思想
快速排序算法通过多次比较和交换来实现排序，其排序流程如下：
1. 首先设定一个分界值，通过该分界值将数组分成左右两部分。
2. 将大于或等于分界值的数据集中到数组右边，小于分界值的数据集中到数组的左边。此时，左边部分中各元素都小于或等于分界值，而右边部分中各元素都大于或等于分界值。
3. 然后，左边和右边的数据可以独立排序。对于左侧的数组数据，又可以取一个分界值，将该部分数据分成左右两部分，同样在左边放置较小值，右边放置较大值。右侧的数组数据也可以做类似处理。
4. 重复上述过程，可以看出，这是一个递归定义。通过递归将左侧部分排好序后，再递归排好右侧部分的顺序。当左、右两个部分各数据排序完成后，整个数组的排序也就完成了。
##### b. 模拟样例
原数组 {5，3，7，6，4，1，0，2，9，10，8}
单元排序：取首位，key=5
1. {2，3，7，6，4，1，0，<font color="red">5</font>，9，10，8}
2. {2，3，<font color="red">5</font>，6，4，1，0，<font color="green">7</font>，9，10，8}
3. {2，3，<font color="green">0</font>，6，4，1，<font color="red">5</font>，7，9，10，8}
4. {2，3，0，<font color="red">5</font>，4，1，<font color="green">6</font>，7，9，10，8}
4. {2，3，0，<font color="green">1</font>，4，<font color="red">5</font>，6，7，9，10，8}
分左右子组分别重复快速排序
key=2
......
key=6
......
##### c. C#代码实现
```C#
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
```

#### 4. 选择排序
选择排序是一种简单直观的排序算法，无论什么数据进去都是O(n^2)的时间复杂度。所以用到它的时候，数据规模越小越好。唯一的好处可能就是不占用额外的内存空间了吧。
##### a. 基本思想
1. 首先在未排序序列中找到最小（大）元素，存放到排序序列的起始位置。
2. 再从剩余未排序元素中继续寻找最小（大）元素，然后放到已排序序列的末尾。
3. 重复第二步，直到所有元素均排序完毕。
##### c. C#代码实现
```C#
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

```
