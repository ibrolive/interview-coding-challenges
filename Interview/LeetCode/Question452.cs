using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question452
    {
        public static void EntryPoint()
        {
            (new Question452()).FindMinArrowShots(utility.ConvertStringToIntArray("[3,9],[7,12],[3,8],[6,8],[9,10],[2,9],[0,9],[3,9],[0,6],[2,8]"));
        }

        public int FindMinArrowShots(int[][] points)
        {
            if (points.Length == 0)
                return 0;

            Array.Sort(points, new MyComparer());

            int arrows = 1,
                xStart,
                xEnd,
                firstEnd = points[0][1];

            foreach (int[] p in points)
            {
                xStart = p[0];
                xEnd = p[1];

                if (firstEnd < xStart)
                {
                    arrows++;
                    firstEnd = xEnd;
                }
            }

            return arrows;
        }

        public class MyComparer : IComparer<int[]>
        {
            public int Compare(int[] x, int[] y)
            {
                return x[1] - y[1];
            }
        }
    }
}
