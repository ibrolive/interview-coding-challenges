using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question1130
    {
        public static void EntryPoint()
        {
            (new Question1130()).MctFromLeafValues(new int[] { 6, 2, 4, 8 });
        }

        public int MctFromLeafValues(int[] arr)
        {
            int[][] dp = new int[arr.Length][];
            int[][] max = new int[arr.Length][];

            for (int i = 0; i < arr.Length; i++)
            {
                dp[i] = Enumerable.Repeat(0, arr.Length).ToArray();
                max[i] = Enumerable.Repeat(0, arr.Length).ToArray();
            }

            // max[i][j] means the max value in arr[i..j].
            for (int i = 0; i < arr.Length; i++)
            {
                int localMax = Int32.MinValue;

                for (int j = i; j < arr.Length; j++)
                {
                    if (arr[j] > localMax)
                        localMax = arr[j];

                    max[i][j] = localMax;
                }
            }

            for (int len = 1; len < arr.Length; len++)
                for (int left = 0; left + len < arr.Length; left++)
                {
                    int right = left + len;

                    dp[left][right] = Int32.MaxValue;

                    if (len == 1)
                        dp[left][right] = arr[left] * arr[right];
                    else
                        for (int k = left; k < right; k++)
                            dp[left][right] = Math.Min(dp[left][right], dp[left][k] + dp[k + 1][right] + max[left][k] * max[k + 1][right]);
                }

            return dp[0][arr.Length - 1];
        }
    }
}
