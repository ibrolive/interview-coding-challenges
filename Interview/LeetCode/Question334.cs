using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question334
    {
        // https://leetcode.com/problems/increasing-triplet-subsequence/discuss/79123/4-lines-C++....
        public bool IncreasingTriplet(int[] nums)
        {
            int a = Int32.MaxValue,
                b = a;

            foreach (var x in nums)
                if (x <= a)
                    a = x;
                else if (x <= b)
                    b = x;
                else
                    return true;

            return false;
        }
    }
}
