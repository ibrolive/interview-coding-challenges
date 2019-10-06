using System;

namespace Interview.Algorithm.DynamicProgramming
{
    // *L*ongest *C*ommon *S*ubsequence
    // State transform: https://en.wikipedia.org/wiki/Longest_common_subsequence_problem
    class LCS
    {
        public static void EntryPoint()
        {
            int result = (new LCS()).GetLCSLength("AGGTAB", "GXTXAYB", 6, 7);
        }

        public int GetLCSLength(string strA, string strB, int strALen, int strBLen)
        {
            if (strALen == 0 || strBLen == 0)
                return 0;

            if (strA[strALen - 1] == strB[strBLen - 1])
                return GetLCSLength(strA, strB, strALen - 1, strBLen - 1) + 1;
            else
                return Math.Max(GetLCSLength(strA, strB, strALen - 1, strBLen),
                                GetLCSLength(strA, strB, strALen, strBLen - 1));
        }
    }
}