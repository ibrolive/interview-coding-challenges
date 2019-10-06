using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question300
    {
        public int LengthOfLIS(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            else if (nums.Length == 1)
                return 1;

            int currentLength = 1;
            int[] continousLength = new int[nums.Length];

            for (int i = 0; i <= nums.Length - 1; i++)
            {
                continousLength[i] = 1;

                for (int j = 0; j < i; j++)
                    if (nums[j] < nums[i])
                        continousLength[i] = Math.Max(continousLength[j] + 1, continousLength[i]);

                currentLength = Math.Max(continousLength[i], currentLength);
            }

            return currentLength;
        }
    }
}