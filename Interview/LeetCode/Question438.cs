using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question438
    {
        public static void EntryPoint()
        {
            (new Question438()).FindAnagrams("abab", "ab");
        }

        public IList<int> FindAnagrams(string s, string p)
        {
            if (s.Length < p.Length)
                return new List<int>();

            int[] countS = new int[26], 
                  countP = new int[26];
            int leftWindowIndex = 0;
            bool isMatch = false;
            List<int> result = new List<int>();

            foreach (var item in p)
                countP[item - 'a']++;

            for (int i = 0; i < s.Length; i++)
            {
                countS[s[i] - 'a']++;

                if (i >= p.Length - 1)
                {
                    isMatch = true;

                    for (int j = p.Length - 1; j >= 0; j--)
                        if (countS[p[j] - 'a'] != countP[p[j] - 'a'])
                        {
                            isMatch = false;
                            break;
                        }

                    if (isMatch)
                        result.Add(leftWindowIndex);

                    countS[s[leftWindowIndex++] - 'a']--;
                }
            }

            return result;
        }
    }
}