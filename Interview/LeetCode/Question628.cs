using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question628
    {
        public int MaximumProduct(int[] nums)
        {
            if (nums.Length == 3)
                return nums[0] * nums[1] * nums[2];

            Array.Sort(nums);

            if (nums[1] < 0 &&
                nums[0] * nums[1] * nums[nums.Length - 1] > nums[nums.Length - 3] * nums[nums.Length - 2] * nums[nums.Length - 1])
                return nums[0] * nums[1] * nums[nums.Length - 1];
            else
                return nums[nums.Length - 3] * nums[nums.Length - 2] * nums[nums.Length - 1];
        }
    }
}
