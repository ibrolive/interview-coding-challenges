using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question542
    {
        public int[][] UpdateMatrix(int[][] matrix)
        {
            if (matrix.Length == 0 || matrix == null)
                return matrix;

            int rows = matrix.Length;
            int cols = matrix[0].Length;
            int[][] dist = new int[rows][];
            Queue<Tuple<int, int>> q = new Queue<Tuple<int, int>>();
            int[,] dir = { { -1, 0 },
                           { 1, 0 },
                           { 0, -1 },
                           { 0, 1 } };

            for (int i = 0; i < rows; i++)
            {
                dist[i] = new int[cols];

                for (int j = 0; j < cols; j++)
                    dist[i][j] = Int32.MaxValue;
            }

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    if (matrix[i][j] == 0)
                    {
                        dist[i][j] = 0;
                        q.Enqueue(new Tuple<int, int>(i, j));
                    }

            while (q.Count != 0)
            {
                Tuple<int, int> curr = q.Dequeue();

                for (int i = 0; i < 4; i++)
                {
                    int new_r = curr.Item1 + dir[i, 0],
                        new_c = curr.Item2 + dir[i, 1];

                    if (new_r >= 0 && new_c >= 0 && new_r < rows && new_c < cols)
                        if (dist[new_r][new_c] > dist[curr.Item1][curr.Item2] + 1)
                        {
                            dist[new_r][new_c] = dist[curr.Item1][curr.Item2] + 1;
                            q.Enqueue(new Tuple<int, int>(new_r, new_c));
                        }
                }
            }

            return dist;
        }
    }
}