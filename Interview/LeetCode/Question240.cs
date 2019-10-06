using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question240
    {
        public static void EntryPoint()
        {
            (new Question240()).SearchMatrix(new int[1, 1] { { -5 } }, -2);
        }

        public bool SearchMatrix(int[,] matrix, int target)
        {
            int currentRow = 0, currentCol = matrix.GetLength(1) - 1;

            while(currentRow <= matrix.GetLength(0) - 1 && currentCol >= 0)
                if (matrix[currentRow, currentCol] == target)
                    return true;
                else if (matrix[currentRow, currentCol] < target)
                    currentRow++;
                else if (matrix[currentRow, currentCol] > target)
                    currentCol--;

            return false;
        }
    }
}