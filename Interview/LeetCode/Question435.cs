using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question435
    {
        public static void EntryPoint()
        {
            (new Question435()).EraseOverlapIntervals(utility.ConvertStringToIntArray("[1,3],[4,7],[8,10],[2,5]"));
        }

        public int EraseOverlapIntervals(int[][] intervals)
        {
            if (intervals.Length == 0)
                return 0;

            Array.Sort(intervals, new myComparator());

            int prev = 0,
                count = 0;

            for (int i = 1; i < intervals.Length; i++)
                if (intervals[prev][1] > intervals[i][0])
                {
                    if (intervals[prev][1] > intervals[i][1])
                        prev = i;

                    count++;
                }
                else
                    prev = i;

            return count;
        }

        class myComparator : IComparer<int[]>
        {
            public int Compare(int[] x, int[] y)
            {
                return x[0] - y[0];
            }
        }
    }
}
