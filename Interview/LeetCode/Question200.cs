using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question200
    {
        public static void EntryPoint()
        {
            char[,] grid =  {
                { '1', '1', '1'},
                { '1', '0', '1'},
                { '1', '1', '1'}
            };

            (new Question200()).NumIslands(grid);
        }

        public int NumIslands(char[,] grid)
        {
            int result = 0;
            bool[,] visited = new bool[grid.GetLength(0), grid.GetLength(1)];

            for (int i = 0; i <= grid.GetLength(0) - 1; i++)
                for (int j = 0; j <= grid.GetLength(1) - 1; j++)
                    if (grid[i, j] != '0' && !visited[i, j])
                    {
                        result++;
                        DetectIsland(i, j, grid, visited);
                    }

            return result;
        }

        private void DetectIsland(int x, int y, char[,] grid, bool[,] visited)
        {
            visited[x, y] = true;

            if (x - 1 >= 0 && !visited[x - 1, y] && grid[x - 1, y] != '0')
                DetectIsland(x - 1, y, grid, visited);
            if (x + 1 <= grid.GetLength(0) - 1 && !visited[x + 1, y] && grid[x + 1, y] != '0')
                DetectIsland(x + 1, y, grid, visited);
            if (y - 1 >= 0 && !visited[x, y - 1] && grid[x, y - 1] != '0')
                DetectIsland(x, y - 1, grid, visited);
            if (y + 1 <= grid.GetLength(1) - 1 && !visited[x, y + 1] && grid[x, y + 1] != '0')
                DetectIsland(x, y + 1, grid, visited);
        }
    }
}