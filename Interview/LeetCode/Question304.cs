using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question304
    {
        public static void EntryPoint()
        {
            int[,] input = new int[,] { { 3, 0, 1, 4, 2 },
                                    { 5, 6, 3, 2, 1 },
                                    { 1, 2, 0, 1, 5 },
                                    { 4, 1, 0, 1, 7 },
                                    { 1, 0, 3, 0, 5 } };

            (new NumMatrix(input)).SumRegion(2, 1, 4, 3);
        }
    }

    // https://github.com/mission-peace/interview/blob/master/src/com/interview/dynamic/Immutable2DSumRangeQuery.java
    public class NumMatrix
    {
        private int[,] sums = null;

        public NumMatrix(int[,] matrix)
        {
            sums = new int[matrix.GetLength(0) + 1, matrix.GetLength(1) + 1];

            for (int i = 0; i < sums.GetLength(0); i++)
                sums[i, 0] = 0;

            for (int i = 1; i < sums.GetLength(1); i++)
                sums[0, i] = 0;

            for (int i = 1; i < sums.GetLength(0); i++)
                for (int j = 1; j < sums.GetLength(1); j++)
                    sums[i, j] = sums[i - 1, j] + sums[i, j - 1] - sums[i - 1, j - 1] + matrix[i - 1, j - 1];
        }

        public int SumRegion(int row1, int col1, int row2, int col2)
        {
            return sums[row2 + 1, col2 + 1] - sums[row2 + 1, col1] - sums[row1, col2 + 1] + sums[row1, col1];
        }
    }
}
