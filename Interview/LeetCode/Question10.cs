using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question10
    {
        public static void EntryPoint()
        {
            (new Question10()).IsMatch("aa", "a*");
        }

        // https://github.com/mission-peace/interview/blob/master/src/com/interview/dynamic/RegexMatching.java
        public bool IsMatch(string s, string p)
        {
            bool[][] T = new bool[s.Length + 1][];

            for (int i = 0; i < T.Length; i++)
                T[i] = new bool[p.Length + 1];

            T[0][0] = true;

            //Deals with patterns like a* or a*b* or a*b*c*
            for (int i = 1; i < T[0].Length; i++)
                if (p[i - 1] == '*')
                    T[0][i] = T[0][i - 2];

            for (int i = 1; i < T.Length; i++)
                for (int j = 1; j < T[0].Length; j++)
                    if (p[j - 1] == '.' || p[j - 1] == s[i - 1])
                        T[i][j] = T[i - 1][j - 1];
                    else if (p[j - 1] == '*')
                    {
                        // * is 0
                        T[i][j] = T[i][j - 2];

                        // * is 1...n
                        if (p[j - 2] == '.' || p[j - 2] == s[i - 1])
                            T[i][j] = T[i][j] | T[i - 1][j];
                    }
                    else
                        T[i][j] = false;

            return T[s.Length][p.Length];
        }
    }
}
