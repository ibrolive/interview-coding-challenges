using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question1060
    {
        public int MissingElement(int[] nums, int k)
        {
            int n = nums.Length;

            if (k > missing(n - 1, nums))
                return nums[n - 1] + k - missing(n - 1, nums);

            int idx = 1;

            while (missing(idx, nums) < k)
                idx++;

            return nums[idx - 1] + k - missing(idx - 1, nums);
        }

        int missing(int idx, int[] nums)
        {
            return nums[idx] - nums[0] - idx;
        }
    }
}
