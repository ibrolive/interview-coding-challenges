using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question376
    {
        // https://leetcode.com/problems/wiggle-subsequence/discuss/84843/Easy-understanding-DP-solution-with-O(n)-Java-version
        public int WiggleMaxLength(int[] nums)
        {
            if (nums.Length == 0)
                return 0;

            int[] up = new int[nums.Length],
                  down = new int[nums.Length];

            up[0] = 1;
            down[0] = 1;

            for (int i = 1; i < nums.Length; i++)
                if (nums[i] > nums[i - 1])
                {
                    up[i] = down[i - 1] + 1;
                    down[i] = down[i - 1];
                }
                else if (nums[i] < nums[i - 1])
                {
                    down[i] = up[i - 1] + 1;
                    up[i] = up[i - 1];
                }
                else
                {
                    down[i] = down[i - 1];
                    up[i] = up[i - 1];
                }

            return Math.Max(down[nums.Length - 1], up[nums.Length - 1]);
        }
    }
}
