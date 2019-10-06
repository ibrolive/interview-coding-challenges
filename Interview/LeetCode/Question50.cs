using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question50
    {
        public static void EntryPoint()
        {
            (new Question50()).MyPow(2, 3);
        }

        // https://leetcode.com/problems/powx-n/discuss/19563/Iterative-Log(N)-solution-with-Clear-Explanation
        public double MyPow(double x, int n)
        {
            double ans = 1;
            long absN = Math.Abs((long)n);

            while (absN > 0)
            {
                if ((absN & 1) == 1)
                    ans *= x;

                absN >>= 1;
                x *= x;
            }

            return n < 0 ? 1 / ans : ans;
        }
    }
}
