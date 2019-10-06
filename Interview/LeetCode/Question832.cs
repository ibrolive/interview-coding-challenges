using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question832
    {
        public static void EntryPoint()
        {
            int[][] input = new int[3][];
            input[0] = new int[] { 1, 1, 0 };
            input[1] = new int[] { 1, 0, 1 };
            input[2] = new int[] { 0, 0, 0 };

            (new Question832()).FlipAndInvertImage(input);
        }

        public int[][] FlipAndInvertImage(int[][] A)
        {
            for (int i = 0; i < A[0].Length; i++)
            {
                int j = 0,
                    k = A[0].Length - 1;

                while (j < k)
                {
                    A[i][j] += A[i][k];
                    A[i][k] = A[i][j] - A[i][k];
                    A[i][j] = A[i][j] - A[i][k];

                    A[i][j] = A[i][j] == 0 ? 1 : 0;
                    A[i][k] = A[i][k] == 0 ? 1 : 0;

                    j++;
                    k--;
                }

                if (j == k)
                    A[i][j] = A[i][j] == 0 ? 1 : 0;
            }

            return A;
        }
    }
}
