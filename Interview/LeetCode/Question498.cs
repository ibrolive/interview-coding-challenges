using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question498
    {
        public int[] FindDiagonalOrder(int[][] matrix)
        {
            if (matrix.Length == 0 || matrix[0].Length == 0)
                return new int[] { };

            int m = matrix.Length,
                n = matrix[0].Length,
                i = 0,
                j = 0,
                pos = 0;
            int[] res = new int[m * n];
            bool isUp = true;

            while (pos < m * n)
            {
                if (isUp)
                {
                    for (; i >= 0 && j < n; i--, j++)
                        res[pos++] = matrix[i][j];

                    if (j == n)
                    {
                        j--;
                        i++;
                    }

                    i++;
                }
                else
                {
                    for (; i < m && j >= 0; i++, j--)
                        res[pos++] = matrix[i][j];

                    if (i == m)
                    {
                        i--;
                        j++;
                    }

                    j++;
                }

                isUp = !isUp;
            }

            return res;
        }
    }
}
