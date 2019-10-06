using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question694
    {
        public static void EntryPoint()
        {
            int[,] grid = { { 1, 1, 0, 0, 0 }, { 1, 1, 0, 0, 0 }, { 0, 0, 0, 1, 1 }, { 0, 0, 0, 1, 1 } };

            (new Question694()).NumDistinctIslands(grid);
        }

        public int NumDistinctIslands(int[,] grid)
        {
            string format = string.Empty;
            Hashtable formats = new Hashtable();

            for (int i = 0; i < grid.GetLength(0); i++)
                for (int j = 0; j < grid.GetLength(1); j++)
                    if (grid[i, j] != 0 && grid[i, j] != -1)
                    {
                        format = SearchIslands(grid, i, j, new StringBuilder(), "START", 0);

                        if (!formats.ContainsKey(format))
                            formats.Add(format, null);
                    }

            return formats.Count;
        }

        public string SearchIslands(int[,] grid, int startRow, int startCol, StringBuilder format, string track, int seed)
        {
            grid[startRow, startCol] = -1;
            format.Append(track);
            seed++;

            if (startRow - 1 >= 0 && grid[startRow - 1, startCol] != 0 && grid[startRow - 1, startCol] != -1)
                SearchIslands(grid, startRow - 1, startCol, format, "UP" + seed.ToString(), seed);
            if (startRow + 1 <= grid.GetLength(0) - 1 && grid[startRow + 1, startCol] != 0 && grid[startRow + 1, startCol] != -1)
                SearchIslands(grid, startRow + 1, startCol, format, "DOWN" + seed.ToString(), seed);
            if (startCol - 1 >= 0 && grid[startRow, startCol - 1] != 0 && grid[startRow, startCol - 1] != -1)
                SearchIslands(grid, startRow, startCol - 1, format, "LEFT" + seed.ToString(), seed);
            if (startCol + 1 <= grid.GetLength(1) - 1 && grid[startRow, startCol + 1] != 0 && grid[startRow, startCol + 1] != -1)
                SearchIslands(grid, startRow, startCol + 1, format, "RIGHT" + seed.ToString(), seed);

            return format.ToString();
        }
    }
}
