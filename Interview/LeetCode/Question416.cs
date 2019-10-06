using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question416
    {
        public static void EntryPoint()
        {
            (new Question416()).CanPartition(new int[] { 5, 7, 6, 4 });
        }

        public bool CanPartition(int[] nums)
        {
            int sum = nums.Sum();

            if (sum % 2 != 0)
                return false;

            int target = sum / 2;

            if (nums.Contains(target))
                return true;

            bool[,] dp = new bool[nums.Length + 1, target + 1];

            for (int i = 0; i <= nums.Length; i++)
                dp[i, 0] = true;

            for (int i = 1; i <= nums.Length; i++)
                for (int j = 0; j <= target; j++)
                {
                    dp[i, j] = dp[i - 1, j];

                    if (j >= nums[i - 1])
                        dp[i, j] |= dp[i - 1, j - nums[i - 1]];
                }

            return dp[nums.Length, target];
        }
    }
}
