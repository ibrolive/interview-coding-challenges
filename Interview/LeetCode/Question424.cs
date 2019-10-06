using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question424
    {
        // https://leetcode.com/problems/longest-repeating-character-replacement/discuss/91328/O(n)-sliding-window-approach
        public int CharacterReplacement(string s, int k)
        {
            int res = 0;

            for (int i = 0; i < 26; i++)
                res = Math.Max(res, characterReplacementLetter(s, k, (char)('A' + i)));

            return res;
        }

        private int characterReplacementLetter(string s, int k, char l)
        {
            int res = 0,
                from = 0,
                to = -1,
                notEqual = 0;

            while (to < s.Length - 1)
            {
                if (s[to + 1] == l || notEqual < k)
                {
                    if (s[to + 1] != l)
                        notEqual++;

                    to++;
                    res = Math.Max(res, to - from + 1);
                }
                else
                {
                    if (s[from] != l)
                        notEqual--;

                    from++;
                }
            }

            return res;
        }
    }
}
