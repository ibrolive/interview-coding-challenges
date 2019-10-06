using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question1102
    {
        public static void EntryPoint()
        {
            (new Question1102()).MaximumMinimumPath(utility.ConvertStringToIntArray("[5,4,5],[1,2,6],[7,4,6]"));
        }

        // https://leetcode.com/problems/path-with-maximum-minimum-value/discuss/329062/Clean-Solution-in-Java-using-Max-Heap
        public int MaximumMinimumPath(int[][] A)
        {
            int result = Int32.MaxValue;
            bool[][] visited = new bool[A.Length][];
            List<int[]> pq = new List<int[]>();
            int[] rowDirection = { 0, 0, 1, -1 },
                  colDirection = { 1, -1, 0, 0 };

            for (int i = 0; i < A.Length; i++)
                visited[i] = new bool[A[0].Length];
            visited[0][0] = true;

            pq.Add(new int[] { A[0][0], 0, 0 });

            while (pq.Count != 0)
            {
                pq.Sort((a, b) => b[0] - a[0]);

                int[] temp = pq[0];
                pq.RemoveAt(0);

                result = Math.Min(result, temp[0]);

                if (temp[1] == A.Length - 1 && temp[2] == A[0].Length - 1)
                    return result;

                for (int i = 0; i < 4; i++)
                {
                    int nextR = temp[1] + rowDirection[i],
                        nextC = temp[2] + colDirection[i];

                    if (nextR > -1 && nextR < A.Length &&
                        nextC > -1 && nextC < A[0].Length &&
                        !visited[nextR][nextC])
                    {
                        visited[nextR][nextC] = true;
                        pq.Add(new int[] { A[nextR][nextC], nextR, nextC });
                    }
                }
            }

            return result;
        }
    }
}
