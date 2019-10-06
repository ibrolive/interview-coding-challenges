using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question201
    {
        // https://leetcode.com/problems/bitwise-and-of-numbers-range/discuss/56903/Simple-Solution
        public int RangeBitwiseAnd(int m, int n)
        {
            int r = Int32.MaxValue;

            while ((m & r) != (n & r))
                r <<= 1;

            return n & r;
        }
    }
}
