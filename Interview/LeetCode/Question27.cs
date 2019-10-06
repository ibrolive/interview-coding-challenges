using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question27
    {
        public int RemoveElement(int[] nums, int val)
        {
            if (nums == null || nums.Length == 0)
                return 0;

            int slowIndex = 0, fastIndex = 0;

            while (slowIndex <= nums.Length - 1 && fastIndex <= nums.Length - 1)
            {
                if (nums[fastIndex] != val)
                {
                    nums[slowIndex] = nums[fastIndex];
                    slowIndex++;
                    fastIndex++;
                }
                else
                    fastIndex++;
            }

            return slowIndex;
        }
    }
}