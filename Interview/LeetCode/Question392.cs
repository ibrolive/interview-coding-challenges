using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question392
    {
        public static void EntryPoint()
        {
            (new Question392()).IsSubsequence("axc", "ahbgdc");
        }

        // https://leetcode.com/problems/is-subsequence/discuss/87258/2-lines-Python
        public bool IsSubsequence(string s, string t)
        {
            if (s.Length > t.Length)
                return false;
            else if (s == string.Empty)
                return true;

            int start = 0,
                temp = 0;

            foreach (var character in s)
            {
                temp = t.IndexOf(character, start);

                if (temp < 0)
                    return false;

                start = temp + 1;
            }

            return true;
        }
    }
}
