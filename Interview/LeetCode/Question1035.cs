using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question1035
    {
        // https://leetcode.com/problems/uncrossed-lines/discuss/282842/JavaC++Python-DP-The-Longest-Common-Subsequence
        public int MaxUncrossedLines(int[] A, int[] B)
        {
            int m = A.Length,
                n = B.Length;

            int[,] dp = new int[m + 1, n + 1];

            for (int i = 1; i <= m; ++i)
                for (int j = 1; j <= n; ++j)
                    if (A[i - 1] == B[j - 1])
                        dp[i, j] = 1 + dp[i - 1, j - 1];
                    else
                        dp[i, j] = Math.Max(dp[i, j - 1], dp[i - 1, j]);

            return dp[m, n];
        }
    }
}
