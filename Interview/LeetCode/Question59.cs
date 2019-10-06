using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question59
    {
        public int[,] GenerateMatrix(int n)
        {
            if (n == 0)
                return new int[0, 0];
            else if (n == 1)
                return new int[1, 1] { { 1 } };

            int[,] result = new int[n, n];
            int rowMin = 0,
                colMin = 0,
                rowMax = n - 1,
                colMax = n - 1,
                currentRow = 0,
                currentCol = 0,
                currentNum = 1;

            while (rowMin <= rowMax && colMin <= colMax)
            {
                currentRow = rowMin;
                currentCol = colMin;

                while (currentCol <= colMax)
                    result[currentRow, currentCol++] = currentNum++;

                currentRow++;
                currentCol--;
                while (currentRow <= rowMax)
                    result[currentRow++, currentCol] = currentNum++;

                currentRow--;
                currentCol--;
                while (currentCol >= colMin)
                    result[currentRow, currentCol--] = currentNum++;

                currentRow--;
                currentCol++;
                while (currentRow > rowMin)
                    result[currentRow--, currentCol] = currentNum++;

                rowMin++;
                colMin++;
                rowMax--;
                colMax--;
            }

            return result;
        }
    }
}