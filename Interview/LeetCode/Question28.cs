using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question28
    {
        public static void EntryPoint()
        {
            (new Question28()).StrStr("hello", "ll");
        }

        public int StrStr(string haystack, string needle)
        {
            return KMP(haystack.ToCharArray(), needle.ToCharArray());
        }

        private int KMP(char[] text, char[] pattern)
        {
            int[] lps = computeTemporaryArray(pattern);
            int i = 0,
                j = 0;

            while (i < text.Length && j < pattern.Length)
                if (text[i] == pattern[j])
                {
                    i++;
                    j++;
                }
                else
                {
                    if (j != 0)
                        j = lps[j - 1];
                    else
                        i++;
                }

            if (j == pattern.Length)
                return i - j;

            return -1;
        }

        private int[] computeTemporaryArray(char[] pattern)
        {
            int[] lps = new int[pattern.Length];
            int index = 0;

            for (int i = 1; i < pattern.Length;)
                if (pattern[i] == pattern[index])
                {
                    lps[i] = index + 1;
                    index++;
                    i++;
                }
                else
                {
                    if (index != 0)
                        index = lps[index - 1];
                    else
                    {
                        lps[i] = 0;
                        i++;
                    }
                }

            return lps;
        }
    }
}
