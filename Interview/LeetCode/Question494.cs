using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question494
    {
        public static void EntryPoint()
        {
            (new Question494()).FindTargetSumWays(new int[] { 1, 1, 1, 1, 1 }, 3);
        }

        public int FindTargetSumWays(int[] nums, int S)
        {
            int[][] memo = new int[nums.Length][];

            for (int i = 0; i < nums.Length; i++)
                memo[i] = Enumerable.Repeat(Int32.MinValue, 2001).ToArray();

            return Calculate(nums, 0, 0, S, memo);
        }

        public int Calculate(int[] nums, int i, int sum, int S, int[][] memo)
        {
            if (i == nums.Length)
            {
                if (sum == S)
                    return 1;
                else
                    return 0;
            }
            else
            {
                if (memo[i][sum + 1000] != Int32.MinValue)
                    return memo[i][sum + 1000];

                int add = Calculate(nums, i + 1, sum + nums[i], S, memo);
                int subtract = Calculate(nums, i + 1, sum - nums[i], S, memo);

                memo[i][sum + 1000] = add + subtract;

                return memo[i][sum + 1000];
            }
        }
    }
}
