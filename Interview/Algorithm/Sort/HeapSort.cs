using System;
using System.Text;
using Interview.DataStructure;

namespace Interview.Algorithm.Sort
{
    public class HeapSortTest
    {
        public static void EntryPoint()
        {
            int[] input = { 3, 10, 9, 4, 399, 1, 49 };
            //int[] input = { 1, 1, 1, 1, 1 };
            MaxHeap heap = new MaxHeap(input);

            heap.SortByASC();

            Console.WriteLine(heap.ToString());
        }
    }
}