using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question973
    {
        public static void EntryPoint()
        {
            //int[][] input = new int[2][];
            //input[0] = new int[] { 1, 3 };
            //input[1] = new int[] { -2, 2 };

            int[][] input = new int[3][];
            input[0] = new int[] { 3, 3 };
            input[1] = new int[] { 5, -1 };
            input[2] = new int[] { -2, 4 };

            (new Question973()).KClosest(input, 1);
        }

        // https://leetcode.com/problems/k-closest-points-to-origin/discuss/229297/Partition-with-O(n)-time-beating-100-using-C
        // https://leetcode.com/articles/k-closest-points-to-origin/
        public int[][] KClosest(int[][] points, int K)
        {
            SortedList<int, int[]> heap = new SortedList<int, int[]>();

            foreach (var item in points)
            {

                heap.Add(item[0] * item[0] + item[1] * item[1], item);

                if (heap.Count > K)
                    heap.RemoveAt(heap.Count - 1);
            }

            return heap.Values.ToArray<int[]>();
        }
    }
}
