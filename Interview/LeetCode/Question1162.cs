using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question1162
    {
        public static void EntryPoint()
        {
            (new Question1162()).MaxDistance(utility.ConvertStringToIntArray("[1,0,0],[1,0,0],[0,0,0]"));
        }

        public int MaxDistance(int[][] grid)
        {
            int steps = 0;
            Queue<Tuple<int, int>> q = new Queue<Tuple<int, int>>();

            for (int i = 0; i < grid.Length; i++)
                for (int j = 0; j < grid[i].Length; ++j)
                    if (grid[i][j] == 1)
                    {
                        q.Enqueue(new Tuple<int, int>(i - 1, j));
                        q.Enqueue(new Tuple<int, int>(i + 1, j));
                        q.Enqueue(new Tuple<int, int>(i, j - 1));
                        q.Enqueue(new Tuple<int, int>(i, j + 1));
                    }

            while (q.Count > 0)
            {
                int count = q.Count;

                steps++;

                while (count-- > 0)
                {
                    int i = q.Peek().Item1,
                        j = q.Peek().Item2;

                    q.Dequeue();

                    if (i >= 0 && j >= 0 && i < grid.Length && j < grid[i].Length && grid[i][j] == 0)
                    {
                        grid[i][j] = steps;

                        q.Enqueue(new Tuple<int, int>(i - 1, j));
                        q.Enqueue(new Tuple<int, int>(i + 1, j));
                        q.Enqueue(new Tuple<int, int>(i, j - 1));
                        q.Enqueue(new Tuple<int, int>(i, j + 1));
                    }
                }
            }

            return steps == 1 ? -1 : steps - 1;
        }
    }
}
