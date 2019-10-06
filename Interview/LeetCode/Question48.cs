using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question48
    {
        public void Rotate(int[][] matrix)
        {
            int n = matrix.Length;

            for (int i = 0; i < n; i++)
                for (int j = i; j < n; j++)
                {
                    int tmp = matrix[j][i];

                    matrix[j][i] = matrix[i][j];
                    matrix[i][j] = tmp;
                }

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n / 2; j++)
                {
                    int tmp = matrix[i][j];

                    matrix[i][j] = matrix[i][n - j - 1];
                    matrix[i][n - j - 1] = tmp;
                }
        }
    }
}