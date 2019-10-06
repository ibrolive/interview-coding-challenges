using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question213
    {
        public static void EntryPoint()
        {
            (new Question213()).Rob(new int[] { 2, 3, 2 });
        }

        public int Rob(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            else if (nums.Length == 1)
                return nums[0];

            return Math.Max(DP(nums, 0), DP(nums, 1));
        }

        private int DP(int[] nums, int startIndex)
        {
            int[,] result = new int[nums.Length, 2];

            for (int i = 1; i < nums.Length; i++)
            {
                result[i, 0] = Math.Max(result[i - 1, 0], result[i - 1, 1]);
                result[i, 1] = result[i - 1, 0] + nums[startIndex];

                startIndex++;
            }

            return Math.Max(result[nums.Length - 1, 0], result[nums.Length - 1, 1]);
        }
    }
}
