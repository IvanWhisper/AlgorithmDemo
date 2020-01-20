using System;

namespace AlgorithmDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            InsertSort shell = new InsertSort();
            Console.WriteLine("排序前的数组:");
            shell.foreachArray();
            shell.InserSortForPrint();
            Console.Read();

            Console.WriteLine("Hello World!");
        }
    }
}
