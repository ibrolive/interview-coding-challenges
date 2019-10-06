using System;

namespace Interview.Algorithm.Sort
{
    class QuickSort
    {
        public static void Entry()
        {
            //int[] data = { 5, 13, 6, 7, 9, 3, 1 };
            //int[] data = { 7, 5, 3, 1 };
            //int[] data = { 5 };
            //int[] data = { 1, 3, 5, 7 };
            //int[] data = { 2, 2, 2, 2 };
            int[] data = { 1, 3, 5, 7, 3, 7, 5 };
            QuickSort obj = new QuickSort();

            int[] output = obj.Sort(data);

            foreach (var item in data)
            {
                Console.WriteLine(item);
            }
        }

        public int[] Sort(int[] input)
        {
            if (input != null)
                Sort(input, 0, (input.Length - 1));
            return input;
        }

        private static void Sort(int[] input, int start, int end)
        {
            // 防止数组越界，保证每次计算都在当前数组的范围内。
            if (start < end)
            {
                int pivotLocatoin = Partition(input, start, end);
                Sort(input, start, pivotLocatoin - 1);
                Sort(input, pivotLocatoin + 1, end);
            }
        }

        private static int Partition(int[] input, int start, int end)
        {
            int pivot = input[start];

            while (start < end)
            {
                while (start < end && pivot < input[end])
                    end--;
                input[start] = input[end];

                //用>=解决重复数字问题
                while (start < end && pivot >= input[start])
                    start++;
                input[end] = input[start];
            }

            input[start] = pivot;

            return start;
        }
    }
}