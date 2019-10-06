using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question713
    {
        // Sliding window: https://leetcode.com/problems/subarray-product-less-than-k/discuss/108861/JavaC++-Clean-Code-with-Explanation
        public int NumSubarrayProductLessThanK(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0)
                return 0;

            int result = 0,
                product = 1;

            for (int i = 0, j = 0; j < nums.Length; j++)
            {
                product *= nums[j];

                while (i <= j && product >= k)
                    product /= nums[i++];

                result += j - i + 1;
            }

            return result;
        }
    }
}
