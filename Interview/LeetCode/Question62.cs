using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question62
    {
        public static void EntryPoint()
        {
            (new Question62()).UniquePaths(1, 2);
        }

        public int UniquePaths(int m, int n)
        {
            int[,] matrix = new int[m, n];

            matrix[0, 0] = 1;

            if (m > 1)
                for (int i = 1; i <= matrix.GetLength(0) - 1; i++)
                    matrix[i, 0] = 1;

            if (n > 1)
                for (int i = 1; i <= matrix.GetLength(1) - 1; i++)
                    matrix[0, i] = 1;

            for (int i = 1; i <= matrix.GetLength(0) - 1; i++)
                for (int j = 1; j <= matrix.GetLength(1) - 1; j++)
                    matrix[i, j] = matrix[i - 1, j] + matrix[i, j - 1];

            return matrix[m - 1, n - 1];
        }
    }
}