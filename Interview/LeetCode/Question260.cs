using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question260
    {
        public int[] SingleNumber(int[] nums)
        {
            int a = 0, 
                b = 0;

            foreach (var n in nums)
                a ^= n;

            foreach (var n in nums)
                if (Convert.ToBoolean(n & a & -a))
                    b ^= n;

            return new int[] { a ^ b, b };
        }
    }
}