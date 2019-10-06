using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question377
    {
        // https://leetcode.com/problems/combination-sum-iv/discuss/85036/1ms-Java-DP-Solution-with-Detailed-Explanation
        public int CombinationSum4(int[] nums, int target)
        {
            int[] comb = new int[target + 1];

            comb[0] = 1;

            for (int i = 1; i < comb.Length; i++)
                for (int j = 0; j < nums.Length; j++)
                    if (i - nums[j] >= 0)
                        comb[i] += comb[i - nums[j]];

            return comb[target];
        }
    }
}
