using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question73
    {
        public void SetZeroes(int[,] matrix)
        {
            if (matrix == null || (matrix.GetLength(0) == 0 && matrix.GetLength(1) == 0))
                return;

            bool rowEdgeToZero = false,
                 colEdgeToZero = false;

            for (int i = 0; i <= matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j <= matrix.GetLength(1) - 1; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        if (i == 0)
                            rowEdgeToZero = true;
                        if (j == 0)
                            colEdgeToZero = true;

                        matrix[i, 0] = 0;
                        matrix[0, j] = 0;
                    }
                }
            }

            for (int i = 1; i <= matrix.GetLength(0) - 1; i++)
                for (int j = 1; j <= matrix.GetLength(1) - 1; j++)
                    if (matrix[i, 0] == 0 || matrix[0, j] == 0)
                        matrix[i, j] = 0;

            if (rowEdgeToZero)
                for (int i = 0; i <= matrix.GetLength(1) - 1; i++)
                    matrix[0, i] = 0;

            if (colEdgeToZero)
                for (int i = 0; i <= matrix.GetLength(0) - 1; i++)
                    matrix[i, 0] = 0;
        }
    }
}
