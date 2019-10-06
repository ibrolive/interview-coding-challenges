using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question402
    {
        public static void EntryPoint()
        {
            (new Question402()).RemoveKdigits("10", 1);
        }

        // https://leetcode.com/problems/remove-k-digits/discuss/88668/Short-Python-one-O(n)-and-one-RegEx
        // Use stack to resolve this problem.
        public string RemoveKdigits(string num, int k)
        {
            if (k >= num.Length)
                return "0";

            StringBuilder res = new StringBuilder();

            foreach (char c in num)
            {
                while (res.Length > 0 && k > 0 && res[res.Length - 1] > c)
                {
                    res.Remove(res.Length - 1, 1);
                    k--;
                }

                if (c != '0' || res.Length > 0)
                    res.Append(c);
            }

            while (k-- > 0)
                res.Remove(res.Length - 1, 1);

            return res.Length > 0 ? res.ToString() : "0";
        }
    }
}
