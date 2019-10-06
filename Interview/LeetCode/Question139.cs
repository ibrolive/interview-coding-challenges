using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question139
    {
        public static void EntryPoint()
        {
            string s = "leetcode";
            IList<string> wordDict = new List<string>();
            wordDict.Add("leet");
            wordDict.Add("code");

            Console.WriteLine((new Question139()).WordBreak(s, wordDict));
        }

        // State Transform:
        // f(i)=any_of(f(j) && s[j+1,i]∈dict) ,0≤j<i
        public bool WordBreak(string s, IList<string> wordDict)
        {
            bool[] f = new bool[s.Length + 1];

            f[0] = true;

            for (int i = 1; i <= s.Length; i++)
                for (int j = 0; j < i; j++)
                    if (f[j] && wordDict.Contains(s.Substring(j, i - j)))
                        f[i] = true;

            return f[s.Length];
        }
    }
}