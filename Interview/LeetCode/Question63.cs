using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question63
    {
        public int UniquePathsWithObstacles(int[,] obstacleGrid)
        {
            if (obstacleGrid[0, 0] == 1)
                return 0;

            int[,] matrix = new int[obstacleGrid.GetLength(0), obstacleGrid.GetLength(1)];

            matrix[0, 0] = 1;

            for (int i = 1; i <= matrix.GetLength(0) - 1; i++)
                if (obstacleGrid[i, 0] != 1)
                    matrix[i, 0] = 1;
                else
                    break;

            for (int i = 1; i <= matrix.GetLength(1) - 1; i++)
                if (obstacleGrid[0, i] != 1)
                    matrix[0, i] = 1;
                else
                    break;

            for (int i = 1; i <= matrix.GetLength(0) - 1; i++)
                for (int j = 1; j <= matrix.GetLength(1) - 1; j++)
                    if (obstacleGrid[i, j] != 1)
                        if (obstacleGrid[i - 1, j] != 1 && obstacleGrid[i, j - 1] != 1)
                            matrix[i, j] = matrix[i - 1, j] + matrix[i, j - 1];
                        else if (obstacleGrid[i - 1, j] != 1 && obstacleGrid[i, j - 1] == 1)
                            matrix[i, j] = matrix[i - 1, j];
                        else if (obstacleGrid[i - 1, j] == 1 && obstacleGrid[i, j - 1] != 1)
                            matrix[i, j] = matrix[i, j - 1];

            return matrix[obstacleGrid.GetLength(0) - 1, obstacleGrid.GetLength(1) - 1];
        }
    }
}
