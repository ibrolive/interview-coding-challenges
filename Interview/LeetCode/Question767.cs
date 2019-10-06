using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question767
    {
        // https://leetcode.com/problems/reorganize-string/solution/
        public string ReorganizeString(string S)
        {
            int[] counts = new int[26];
            char[] ans = new char[S.Length];
            int t = 1;

            foreach (var item in S.ToCharArray())
                counts[item - 'a'] += 100;

            for (int i = 0; i < 26; ++i)
                counts[i] += i;

            Array.Sort(counts);

            foreach (var code in counts)
            {
                int ct = code / 100;
                char ch = (char)('a' + (code % 100));

                if (ct > (S.Length + 1) / 2)
                    return "";

                for (int i = 0; i < ct; ++i)
                {
                    if (t >= S.Length)
                        t = 0;

                    ans[t] = ch;

                    t += 2;
                }
            }

            return new string(ans);
        }
    }
}
