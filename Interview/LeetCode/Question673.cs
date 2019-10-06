using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question673
    {
        public int FindNumberOfLIS(int[] nums)
        {
            if (nums.Length <= 1)
                return nums.Length;

            int[] lengths = new int[nums.Length],
                  counts = new int[nums.Length];

            for (int i = 0; i < counts.Length; i++)
                counts[i] = 1;

            for (int j = 0; j < nums.Length; j++)
                for (int i = 0; i < j; i++)
                    if (nums[i] < nums[j])
                    {
                        if (lengths[i] >= lengths[j])
                        {
                            lengths[j] = lengths[i] + 1;
                            counts[j] = counts[i];
                        }
                        else if (lengths[i] + 1 == lengths[j])
                            counts[j] += counts[i];
                    }

            int longest = 0,
                ans = 0;
            foreach (var length in lengths)
                longest = Math.Max(longest, length);

            for (int i = 0; i < nums.Length; ++i)
                if (lengths[i] == longest)
                    ans += counts[i];

            return ans;
        }
    }
}
