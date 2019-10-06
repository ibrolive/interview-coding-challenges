using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question1062
    {
        public static void EntryPoint()
        {
            (new Question1062()).LongestRepeatingSubstring("aaabaabbbaaabaabbaabbbabbbaaaabbaaaaaabbbaabbbbbbbbbaaaabbabbaba");
        }

        public int LongestRepeatingSubstring(string S)
        {
            int[][] dp = new int[S.Length + 1][];
            int res = 0;

            for (int i = 0; i < dp.Length; i++)
                dp[i] = new int[S.Length + 1];

            for (int i = 1; i <= S.Length; i++)
                for (int j = i + 1; j <= S.Length; j++)
                    if (S[i - 1] == S[j - 1])
                    {
                        dp[i][j] = dp[i - 1][j - 1] + 1;
                        res = Math.Max(res, dp[i][j]);
                    }

            return res;
        }
    }
}
