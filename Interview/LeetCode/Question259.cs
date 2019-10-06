using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question259
    {
        // How to prove the time complexity is O(n^2)?
        public int ThreeSumSmaller(int[] nums, int target)
        {
            int result = 0,
                i = 0, j = 0, k = 0;

            Array.Sort(nums);

            for (i = 0; i < nums.Length - 2; i++)
            {
                j = i + 1;
                k = nums.Length - 1;

                while (j < k)
                    if (nums[i] + nums[j] + nums[k] < target)
                    {
                        result += k - j;
                        j++;
                    }
                    else
                        k--;
            }

            return result;
        }
    }
}
