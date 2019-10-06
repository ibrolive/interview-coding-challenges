using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question939
    {
        public static void EntryPoint()
        {
            int[][] points = new int[5][];
            points[0] = new int[] { 1, 1 };
            points[1] = new int[] { 1, 3 };
            points[2] = new int[] { 3, 1 };
            points[3] = new int[] { 3, 3 };
            points[4] = new int[] { 2, 2 };

            (new Question939()).minAreaRect(points);
        }

        // https://leetcode.com/problems/minimum-area-rectangle/discuss/207498/Easy-Java-Solution
        public int minAreaRect(int[][] points)
        {
            int result = Int32.MaxValue;
            Dictionary<int, HashSet<int>> map = new Dictionary<int, HashSet<int>>();

            foreach (var p in points)
                if (map.ContainsKey(p[0]))
                    map[p[0]].Add(p[1]);
                else
                {
                    map.Add(p[0], new HashSet<int>());
                    map[p[0]].Add(p[1]);
                }

            foreach (var p0 in points)
                foreach (var p1 in points)
                    if (p1[0] > p0[0] && p1[1] > p0[1] && map[p0[0]].Contains(p1[1]) && map[p1[0]].Contains(p0[1]))
                        result = Math.Min(result, (p1[0] - p0[0]) * (p1[1] - p0[1]));

            return result == Int32.MaxValue ? 0 : result;
        }
    }
}
