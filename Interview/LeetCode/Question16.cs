using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question16
    {
        public static void EntryPoint()
        {
            (new Question16()).ThreeSumClosest(new int[] { -1, 2, 1, -4 }, 1);
        }

        public int ThreeSumClosest(int[] nums, int target)
        {
            int result = nums[0] + nums[1] + nums[nums.Length - 1],
                start = 0,
                end = 0,
                sum = 0;

            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 2; i++)
            {
                start = i + 1;
                end = nums.Length - 1;

                while (start < end)
                {
                    sum = nums[i] + nums[start] + nums[end];

                    if (sum > target)
                        end--;
                    else
                        start++;

                    if (Math.Abs(target - sum) < Math.Abs(target - result))
                        result = sum;
                }
            }

            return result;
        }
    }
}
