using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question413
    {
        public int NumberOfArithmeticSlices(int[] A)
        {
            int[] dp = new int[A.Length];
            int sum = 0;

            for (int i = 2; i < dp.Length; i++)
                if (A[i] - A[i - 1] == A[i - 1] - A[i - 2])
                {
                    dp[i] = 1 + dp[i - 1];
                    sum += dp[i];
                }

            return sum;
        }
    }
}
