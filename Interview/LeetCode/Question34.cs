using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question34
    {
        public static void EntryPoint()
        {
            (new Question34()).SearchRange(new int[] { 1 }, 1);
        }

        public int[] SearchRange(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
                return new int[] { -1, -1 };

            int i = 0, j = nums.Length - 1, k = 0, l = -1;

            while (i <= j)
            {
                k = i + (j - i) / 2;

                if (nums[k] == target)
                {
                    l = k;
                    break;
                }
                else if (nums[k] < target)
                    i = k + 1;
                else
                    j = k - 1;
            }

            if (l != -1)
            {
                i = l;
                j = l;

                while (i - 1 >= 0 && nums[i - 1] == nums[i])
                    i--;

                while (j + 1 <= nums.Length - 1 && nums[j + 1] == nums[j])
                    j++;

                return new int[] { i, j };
            }

            return new int[] { -1, -1 };
        }
    }
}