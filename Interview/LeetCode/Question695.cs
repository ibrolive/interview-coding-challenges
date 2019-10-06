using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question695
    {
        public static void EntryPoint()
        {
            int[,] grid = { { 1, 1, 0, 0, 0 }, { 1, 1, 0, 0, 0 }, { 0, 0, 0, 1, 1 }, { 0, 0, 0, 1, 1 } };

            (new Question695()).MaxAreaOfIsland(grid);
        }

        public int MaxAreaOfIsland(int[,] grid)
        {
            int result = 0,
                currenArea = 0;
            int[,] visited = new int[grid.GetLength(0), grid.GetLength(1)];

            for (int i = 0; i < grid.GetLength(0); i++)
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    currenArea = DFS(grid, i, j, visited);

                    result = currenArea > result ? currenArea : result;
                }

            return result;
        }

        private int DFS(int[,] grid, int i, int j, int[,] visited)
        {
            int currentArea = 0;

            if (grid[i, j] != 0)
            {
                currentArea++;
                visited[i, j] = 1;
            }
            else
                return 0;

            if (i - 1 >= 0 && visited[i - 1, j] != 1)
                currentArea += DFS(grid, i - 1, j, visited);
            if (i + 1 < grid.GetLength(0) && visited[i + 1, j] != 1)
                currentArea += DFS(grid, i + 1, j, visited);
            if (j - 1 >= 0 && visited[i, j - 1] != 1)
                currentArea += DFS(grid, i, j - 1, visited);
            if (j + 1 < grid.GetLength(1) && visited[i, j + 1] != 1)
                currentArea += DFS(grid, i, j + 1, visited);

            return currentArea;
        }
    }
}
