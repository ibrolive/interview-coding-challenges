using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question96
    {
        // https://leetcode.com/problems/unique-binary-search-trees/discuss/31807/AC-clean-Java-DP-solution
        public int NumTrees(int n)
        {
            if (n == 0)
                return 0;

            int[] dp = new int[n + 1];

            dp[0] = 1;

            for (int i = 1; i <= n; i++)
                for (int j = 1; j <= i; j++)
                    dp[i] += dp[j - 1] * dp[i - j];

            return dp[n];
        }
    }
}
