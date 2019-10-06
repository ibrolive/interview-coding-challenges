using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question463
    {
        public static void EntryPoint()
        {
            int[,] input = { { 0, 1, 0, 0 },
                             { 1, 1, 1, 0 },
                             { 0, 1, 0, 0 },
                             { 1, 1, 0, 0 } };

            (new Question463()).IslandPerimeter(input);
        }

        public int IslandPerimeter(int[,] grid)
        {
            if (grid == null)
                return 0;

            int perimeter = 0;

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j] == 0)
                        continue;

                    if (i == 0 || grid[i - 1, j] == 0)
                        perimeter++;

                    if (i == grid.GetLength(0) - 1 || grid[i + 1, j] == 0)
                        perimeter++;

                    if (j == 0 || grid[i, j - 1] == 0)
                        perimeter++;

                    if (j == grid.GetLength(1) - 1 || grid[i, j + 1] == 0)
                        perimeter++;
                }
            }

            return perimeter;
        }
    }
}