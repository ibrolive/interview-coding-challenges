using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question1124
    {
        // This is a DP problem.
        // https://leetcode.com/problems/longest-well-performing-interval/discuss/334680/Simple-DP-Solution-with-O(n)-Time-Complexity
        public int LongestWPI(int[] hours)
        {
            if (hours.Length == 0)
                return 0;

            int sum = 0,
                maxLen = 0;
            Dictionary<int, int> sum2Location = new Dictionary<int, int>();

            for (int i = 0; i < hours.Length; i++)
            {
                sum += (hours[i] > 8 ? 1 : -1);

                if (sum >= 1)
                    maxLen = i + 1;
                else
                {
                    if (!sum2Location.ContainsKey(sum))
                        sum2Location.Add(sum, i);

                    if (sum2Location.ContainsKey(sum - 1))
                        maxLen = Math.Max(maxLen, i - sum2Location[sum - 1]);
                }
            }

            return maxLen;
        }
    }
}
