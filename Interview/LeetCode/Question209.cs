using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question209
    {
        public static void EntryPoint()
        {
            (new Question209()).MinSubArrayLen(7, new int[] { 2, 3, 1, 2, 4, 3 });
        }

        public int MinSubArrayLen(int s, int[] nums)
        {
            int result = Int32.MaxValue,
                sum = 0,
                i = 0,
                j = 0;

            while (i < nums.Length)
            {
                sum += nums[i++];

                while (sum >= s)
                {
                    result = Math.Min(result, i - j);
                    sum -= nums[j++];
                }
            }

            return result == Int32.MaxValue ? 0 : result;
        }
    }
}
