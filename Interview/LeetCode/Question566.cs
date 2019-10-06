using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question566
    {
        public static void EntryPoint()
        {
            (new Question566()).MatrixReshape(new int[,] { { 1, 2 }, { 3, 4 } }, 2, 4);
        }

        public int[,] MatrixReshape(int[,] nums, int r, int c)
        {
            if (nums.GetLength(0) * nums.GetLength(1) > r * c)
                return null;

            if (nums.GetLength(0) <= r && nums.GetLength(1) <= c)
                return nums;

            int[,] result = new int[r, c];
            int resultRow = 0, resultCol = 0;

            for (int i = 0; i <= nums.GetLength(0) - 1; i++)
            {
                for (int j = 0; j <= nums.GetLength(1) - 1; j++)
                {
                    if (resultCol > c - 1)
                    {
                        resultRow++;
                        resultCol = 0;
                    }

                    result[resultRow, resultCol] = nums[i, j];

                    resultCol++;
                }
            }

            return result;
        }
    }
}