using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    class Question64
    {
        public int MinPathSum(int[,] grid)
        {
            int[,] sum = new int[grid.GetLength(0), grid.GetLength(1)];

            sum[0, 0] = grid[0, 0];

            for (int i = 1; i < grid.GetLength(0); i++)
                sum[i, 0] = sum[i - 1, 0] + grid[i, 0];

            for (int i = 1; i < grid.GetLength(1); i++)
                sum[0, i] = sum[0, i - 1] + grid[0, i];

            for (int i = 1; i < grid.GetLength(0); i++)
                for (int j = 1; j < grid.GetLength(1); j++)
                    sum[i, j] = Math.Min(sum[i - 1, j] + grid[i, j], sum[i, j - 1] + grid[i, j]);

            return sum[sum.GetLength(0) - 1, sum.GetLength(1) - 1];
        }
    }
}
