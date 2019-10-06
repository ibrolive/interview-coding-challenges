using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question137
    {
        public int SingleNumber(int[] nums)
        {
            int seenOnce = 0,
                seenTwice = 0;

            foreach (var num in nums)
            {
                seenOnce = ~seenTwice & (seenOnce ^ num);
                seenTwice = ~seenOnce & (seenTwice ^ num);
            }

            return seenOnce;
        }
    }
}
