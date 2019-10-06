using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question807
    {
        public static void EntryPoint()
        {
            int[][] grid = new int[4][];
            grid[0] = new int[] { 3, 0, 8, 4 };
            grid[1] = new int[] { 2, 4, 5, 7 };
            grid[2] = new int[] { 9, 2, 6, 3 };
            grid[3] = new int[] { 0, 3, 1, 0 };

            (new Question807()).MaxIncreaseKeepingSkyline(grid);
        }

        public int MaxIncreaseKeepingSkyline(int[][] grid)
        {
            int result = 0,
                initialHeight = 0;
            int[] topToDown = new int[grid.Length],
                  leftToRight = new int[grid[0].Length];

            for (int i = 0; i < grid.Length; i++)
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] > topToDown[j])
                        topToDown[j] = grid[i][j];

                    if (grid[i][j] > leftToRight[i])
                        leftToRight[i] = grid[i][j];
                }

            for (int i = 0; i < grid.Length; i++)
                for (int j = 0; j < grid[0].Length; j++)
                {
                    initialHeight = grid[i][j];

                    while (grid[i][j] < topToDown[j] && grid[i][j] < leftToRight[i])
                        grid[i][j] += 1;

                    result += (grid[i][j] - initialHeight);
                }

            return result;
        }
    }
}
