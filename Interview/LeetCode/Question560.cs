using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question560
    {
        public static void EntryPoint()
        {
            //(new Question560()).SubarraySum(new int[] { 28, 54, 7, -70, 22, 65, -6 }, 100);
            (new Question560()).SubarraySum(new int[] { 1, 1, 1 }, 2);
        }

        public int SubarraySum(int[] nums, int k)
        {
            int count = 0,
                sum = 0;
            Hashtable sums = new Hashtable();

            sums.Add(0, 1);

            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                if (sums.ContainsKey(sum - k))
                    count += (int)sums[sum - k];

                if (!sums.ContainsKey(sum))
                    sums.Add(sum, 1);
                else
                    sums[sum] = (int)sums[sum] + 1;
            }

            return count;
        }
    }
}