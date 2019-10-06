using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question686
    {
        public static void EntryPoint()
        {
            (new Question686()).RepeatedStringMatch("abcd", "cdabcdab");
        }

        public int RepeatedStringMatch(string A, string B)
        {
            if (A == null || A == string.Empty || B == null || B == string.Empty)
                return -1;

            StringBuilder temp = new StringBuilder(A);
            int result = 1;

            while (temp.Length < B.Length)
            {
                temp.Append(A);
                result++;
            }

            if (temp.ToString().Contains(B))
                return result;
            else if (temp.Append(A).ToString().Contains(B))
                return ++result;
            else
                return -1;
        }
    }
}
