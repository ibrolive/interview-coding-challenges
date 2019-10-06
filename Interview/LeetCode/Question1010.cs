using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question1010
    {
        public static void EntryPoint()
        {
            (new Question1010()).NumPairsDivisibleBy60(new int[] { 30, 20, 150, 100, 40 });
        }

        // https://leetcode.com/problems/pairs-of-songs-with-total-durations-divisible-by-60/discuss/296138/Java-solution-from-combination-perspective-with-best-explanation
        public int NumPairsDivisibleBy60(int[] time)
        {
            int result = 0;
            int[] pairs = new int[60];

            foreach (var item in time)
                pairs[item % 60]++;

            for (int i = 1; i < 30; i++)
                result += pairs[i] * pairs[60 - i];

            result += pairs[0] * (pairs[0] - 1) / 2;
            result += pairs[30] * (pairs[30] - 1) / 2;

            return result;
        }
    }
}
