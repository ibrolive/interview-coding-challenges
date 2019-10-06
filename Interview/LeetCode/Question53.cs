using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question53
    {
        public static void EntryPoint()
        {
            (new Question53()).MaxSubArray(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 });
        }

        // State transform:
        // Max ( Max(0, i), Max(0, i) + A[i + 1], A[i + 1] )
        public int MaxSubArray(int[] nums)
        {
            int currentSum = nums[0], continuousSum = nums[0];

            for (int i = 1; i <= nums.Length - 1; i++)
            {
                continuousSum = Math.Max(continuousSum + nums[i], nums[i]);
                currentSum = Math.Max(currentSum, continuousSum);
            }

            return currentSum;
        }
    }
}