using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question1155
    {
        public int NumRollsToTarget(int d, int f, int target)
        {
            int mod = 1000000007;
            long[,] dp = new long[d + 1, target + 1];

            for (int face = 1; face <= f; face++)
                if (face <= target) dp[1, face] = 1;

            for (int i = 2; i <= d; i++)
                for (int j = 0; j <= target; j++)
                    for (int face = 1; face <= f; face++)
                    {
                        if (j - face >= 0)
                        {
                            dp[i, j] += dp[i - 1, j - face];
                            dp[i, j] %= mod;
                        }
                    }

            return (int)dp[d, target];
        }
    }
}
