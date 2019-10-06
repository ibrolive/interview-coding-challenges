using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question516
    {
        public static void EntryPoint()
        {
            (new Question516()).LongestPalindromeSubseq("abccba");
        }

        public int LongestPalindromeSubseq(string s)
        {
            if (s == null || s.Length == 0)
                return 0;

            int[,] result = new int[s.Length + 1, s.Length + 1];

            for (int i = 0; i <= s.Length; i++)
            {
                result[i, 0] = 0;
                result[0, i] = 0;
            }

            for (int i = 1; i <= s.Length; i++)
                for (int j = 1; j <= s.Length; j++)
                    if (s[i - 1] == s[s.Length - j])
                        result[i, j] = result[i - 1, j - 1] + 1;
                    else
                        result[i, j] = Math.Max(result[i - 1, j], result[i, j - 1]);

            return result[s.Length, s.Length];
        }
    }
}
