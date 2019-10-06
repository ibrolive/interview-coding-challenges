using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question643
    {
        public static void EntryPoint()
        {
            (new Question643()).FindMaxAverage(new int[] { 4, 2, 1, 3, 3 }, 2);
        }

        public double FindMaxAverage(int[] nums, int k)
        {
            double result = 0,
                   slidingWindow = 0;

            if (nums.Length <= k)
            {
                foreach (var item in nums)
                    result += item;

                return result / nums.Length;
            }

            for (int i = 0; i < k; i++)
                slidingWindow += nums[i];

            result = slidingWindow;

            for (int i = k; i < nums.Length; i++)
            {
                slidingWindow = slidingWindow + nums[i] - nums[i - k];
                result = slidingWindow > result ? slidingWindow : result;
            }

            return result / k;
        }
    }
}
