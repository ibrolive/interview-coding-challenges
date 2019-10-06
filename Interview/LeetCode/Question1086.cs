using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.DataStructure;

namespace Interview.LeetCode
{
    class Question1086
    {
        public int[][] HighFive(int[][] items)
        {
            List<int[]> result = new List<int[]>();
            SortedList<int, List<int>> list = new SortedList<int, List<int>>();

            foreach (var item in items)
            {
                if (!list.ContainsKey(item[0]))
                    list.Add(item[0], new List<int>());

                list[item[0]].Add(item[1]);
            }

            foreach (var item in list)
            {
                int temp = 0;
                MaxHeap heap = new MaxHeap(item.Value.ToArray());

                for (int i = 0; i < 5; i++)
                    temp += heap.Extract();

                result.Add(new int[] { item.Key, temp /= 5 });
            }

            return result.ToArray();
        }
    }
}
