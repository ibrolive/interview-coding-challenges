using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question361
    {
        public static void EntryPoint()
        {
            char[][] grid = new char[3][];

            grid[0] = new char[4] { '0', 'E', '0', '0' };
            grid[1] = new char[4] { 'E', '0', 'W', 'E' };
            grid[2] = new char[4] { '0', 'E', '0', '0' };

            (new Question361()).MaxKilledEnemies(grid);
        }

        // https://leetcode.com/problems/bomb-enemy/discuss/83383/Simple-DP-solution-in-Java
        public int MaxKilledEnemies(char[][] grid)
        {
            if (grid == null || 
                grid.Length == 0 || 
                grid[0].Length == 0)
                return 0;

            int max = 0;
            int row = 0;
            int[] col = new int[grid[0].Length];

            for (int i = 0; i < grid.Length; i++)
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 'W')
                        continue;

                    if (j == 0 || grid[i][j - 1] == 'W')
                        row = killedEnemiesRow(grid, i, j);

                    if (i == 0 || grid[i - 1][j] == 'W')
                        col[j] = killedEnemiesCol(grid, i, j);

                    if (grid[i][j] == '0')
                        max = (row + col[j] > max) ? row + col[j] : max;
                }

            return max;
        }

        private int killedEnemiesRow(char[][] grid, int i, int j)
        {
            int num = 0;

            while (j <= grid[0].Length - 1 && grid[i][j] != 'W')
            {
                if (grid[i][j] == 'E')
                    num++;

                j++;
            }

            return num;
        }

        private int killedEnemiesCol(char[][] grid, int i, int j)
        {
            int num = 0;

            while (i <= grid.Length - 1 && grid[i][j] != 'W')
            {
                if (grid[i][j] == 'E')
                    num++;

                i++;
            }

            return num;
        }
    }
}
