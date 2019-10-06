using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question74
    {
        public static void EntryPoint()
        {
            (new Question74()).SearchMatrix(new[,] { { 1, 3, 5, 7 }, { 10, 11, 16, 20 } }, 3);
        }

        public bool SearchMatrix(int[,] matrix, int target)
        {
            if (matrix == null)
                return false;

            int row = 0,
                col = matrix.GetLength(1) - 1;

            while (row <= matrix.GetLength(0) - 1 && col >= 0)
                if (matrix[row, col] == target)
                    return true;
                else if (matrix[row, col] < target)
                    row++;
                else
                    col--;

            return false;
        }
    }
}