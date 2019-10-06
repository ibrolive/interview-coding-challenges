using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question583
    {
        public int MinDistance(string word1, string word2)
        {
            int[][] dp = new int[word1.Length + 1][];

            for (int i = 0; i < dp.Length; i++)
                dp[i] = Enumerable.Repeat(0, word2.Length + 1).ToArray();

            for (int i = 0; i <= word1.Length; i++)
                for (int j = 0; j <= word2.Length; j++)
                {
                    if (i == 0 || j == 0)
                        continue;
                    if (word1[i - 1] == word2[j - 1])
                        dp[i][j] = 1 + dp[i - 1][j - 1];
                    else
                        dp[i][j] = Math.Max(dp[i - 1][j], dp[i][j - 1]);
                }

            return word1.Length + word2.Length - 2 * dp[word1.Length][word2.Length];
        }
    }
}
