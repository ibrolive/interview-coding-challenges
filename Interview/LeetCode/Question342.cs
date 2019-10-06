using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question342
    {
        // https://leetcode.com/problems/power-of-four/discuss/80455/One-of-my-favorite-tricks/281025
        public bool IsPowerOfFour(int num)
        {
            return (BitConverter.DoubleToInt64Bits(num) & -9214364837600034817) == 0x10000000000000L;
        }
    }
}
