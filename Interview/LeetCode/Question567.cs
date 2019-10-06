using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question567
    {
        public static void EntryPoint()
        {
            (new Question567()).CheckInclusion("adc", "dcda");
        }

        public bool CheckInclusion(string s1, string s2)
        {
            if (s1.Length > s2.Length)
                return false;

            int[] s1map = new int[26],
                  s2map = new int[26];

            for (int i = 0; i < s1.Length; i++)
            {
                s1map[s1[i] - 'a']++;
                s2map[s2[i] - 'a']++;
            }

            for (int i = 0; i < s2.Length - s1.Length; i++)
            {
                if (Matches(s1map, s2map))
                    return true;

                s2map[s2[i + s1.Length] - 'a']++;
                s2map[s2[i] - 'a']--;
            }

            return Matches(s1map, s2map);
        }

        private bool Matches(int[] s1map, int[] s2map)
        {
            for (int i = 0; i < 26; i++)
                if (s1map[i] != s2map[i])
                    return false;

            return true;
        }
    }
}
