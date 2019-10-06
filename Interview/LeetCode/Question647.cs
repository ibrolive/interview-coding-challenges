using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question647
    {
        public int CountSubstrings(string s)
        {
            if (s == String.Empty || s.Length == 0)
                return 0;

            int result = 0;

            for (int i = 0; i < s.Length; i++)
                result += CheckPalindromic(s, i, i) + CheckPalindromic(s, i, i + 1);

            return result;
        }

        private int CheckPalindromic(string source, int left, int right)
        {
            int result = 0;

            while (left >= 0 &&
                   right < source.Length &&
                   source[left--] == source[right++])
                result++;

            return result;
        }
    }
}