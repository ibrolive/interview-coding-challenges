using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question191
    {
        public int HammingWeight(uint n)
        {
            int count = 0;

            while (n != 0)
            {
                if ((n & (~n + 1)) == 1)
                    count++;

                n = n >> 1;
            }

            return count;
        }
    }
}