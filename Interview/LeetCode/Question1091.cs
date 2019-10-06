using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question1091
    {
        public int ShortestPathBinaryMatrix(int[][] grid)
        {
            int result = -1;
            Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
            int[][] distance = new int[grid.Length][];
            int[] rowChange = new int[] { -1, 1, 0, 0, -1, 1, -1, 1 },
                  colChange = new int[] { 0, 0, -1, 1, 1, 1, -1, -1 };

            if (grid[0][0] != 1 && grid[grid.Length - 1][grid.Length - 1] != 1)
            {
                queue.Enqueue(new Tuple<int, int>(0, 0));

                for (int i = 0; i < grid.Length; i++)
                    distance[i] = Enumerable.Repeat(Int32.MaxValue, grid.Length).ToArray();

                distance[0][0] = 1;

                while (queue.Count > 0)
                {
                    Tuple<int, int> temp = queue.Dequeue();

                    if (temp.Item1 == grid.Length - 1 && temp.Item2 == grid.Length - 1)
                        return distance[temp.Item1][temp.Item2];

                    for (int i = 0; i < 8; i++)
                        if (temp.Item1 + rowChange[i] > -1 && temp.Item1 + rowChange[i] < grid.Length &&
                            temp.Item2 + colChange[i] > -1 && temp.Item2 + colChange[i] < grid.Length &&
                            grid[temp.Item1 + rowChange[i]][temp.Item2 + colChange[i]] != 1 &&
                            distance[temp.Item1][temp.Item2] + 1 < distance[temp.Item1 + rowChange[i]][temp.Item2 + colChange[i]])
                        {
                            distance[temp.Item1 + rowChange[i]][temp.Item2 + colChange[i]] = distance[temp.Item1][temp.Item2] + 1;
                            queue.Enqueue(new Tuple<int, int>(temp.Item1 + rowChange[i], temp.Item2 + colChange[i]));
                        }
                }
            }

            return result;
        }
    }
}
