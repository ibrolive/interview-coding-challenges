using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question387
    {
        public static void EntryPoint()
        {
            (new Question387()).FirstUniqChar("leetcode");
        }

        public int FirstUniqChar(string s)
        {
            Dictionary<char, int[]> dictionary = new Dictionary<char, int[]>();

            for (int i = 0; i <= s.Length - 1; i++)
                if (dictionary.ContainsKey(s[i]))
                    ((int[])dictionary[s[i]])[0]++;
                else
                    dictionary.Add(s[i], new int[] { 1, i });

            foreach (var item in dictionary.Values)
                if (((int[])item)[0] == 1)
                    return ((int[])item)[1];

            return -1;
        }
    }
}