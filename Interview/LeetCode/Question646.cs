using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question646
    {
        public static void EntryPoint()
        {
            (new Question646()).FindLongestChain(new int[,] { { 3, 4 }, { 1, 2 }, { 7, 9 } });
        }

        public int FindLongestChain(int[,] pairs)
        {
            if (pairs == null || pairs.GetLength(0) == 0)
                return 0;

            int[][] input = new int[pairs.GetLength(0)][];
            int result = 1,
                rightBoundary = 0;

            for (int i = 0; i < pairs.GetLength(0); i++)
                input[i] = new int[] { pairs[i, 0], pairs[i, 1] };

            input = input.OrderBy(x => x[1]).ToArray<int[]>();
            rightBoundary = input[0][1];

            for (int i = 1; i < input.GetLength(0); i++)
                if (rightBoundary < input[i][0])
                {
                    rightBoundary = input[i][1];
                    result++;
                }

            return result;
        }
    }
}
