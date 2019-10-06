using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question523
    {
        public static void EntryPoint()
        {
            (new Question523()).CheckSubarraySum(new int[] { 23, 2, 6, 4, 7 }, 6);
        }

        // https://leetcode.com/problems/continuous-subarray-sum/solution/
        public bool CheckSubarraySum(int[] nums, int k)
        {
            Dictionary<int, int> temp = new Dictionary<int, int>();
            int sum = 0;

            temp.Add(0, -1);

            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];

                if (temp.ContainsKey(k == 0 ? sum : sum % k))
                {
                    if (i - temp[k == 0 ? sum : sum % k] > 1)
                        return true;
                }
                else
                    temp.Add(k == 0 ? sum : sum % k, i);
            }

            return false;
        }
    }
}
