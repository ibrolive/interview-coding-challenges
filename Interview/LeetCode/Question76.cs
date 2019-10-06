using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question76
    {
        public static void EntryPoint()
        {
            (new Question76()).MinWindow("ADOBECODEBANC", "ABC");
        }

        public string MinWindow(string s, string t)
        {
            if (s.Length == 0 || t.Length == 0)
                return "";

            Dictionary<char, int> dictT = new Dictionary<char, int>(),
                                  windowCounts = new Dictionary<char, int>();
            int required = 0,
                l = 0,
                r = 0,
                formed = 0;
            int[] ans = { -1, 0, 0 };

            for (int i = 0; i < t.Length; i++)
            {
                if (!dictT.ContainsKey(t[i]))
                    dictT.Add(t[i], 0);

                dictT[t[i]] += 1;
            }

            required = dictT.Count;

            while (r < s.Length)
            {
                char c = s[r];
                if (!windowCounts.ContainsKey(c))
                    windowCounts.Add(c, 0);

                windowCounts[c] += 1;

                if (dictT.ContainsKey(c) && windowCounts[c] == dictT[c])
                    formed++;

                while (l <= r && formed == required)
                {
                    c = s[l];

                    if (ans[0] == -1 || r - l + 1 < ans[0])
                    {
                        ans[0] = r - l + 1;
                        ans[1] = l;
                        ans[2] = r;
                    }

                    windowCounts[c] -= 1;
                    if (dictT.ContainsKey(c) && windowCounts[c] < dictT[c])
                        formed--;

                    l++;
                }

                r++;
            }

            return ans[0] == -1 ? "" : s.Substring(ans[1], ans[2] - ans[1] + 1);
        }
    }
}
