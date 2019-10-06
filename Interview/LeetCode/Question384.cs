using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question384
    {
        public static void EntryPoint()
        {
            Solution solution = new Solution(new int[] { 1, 2, 3 });
            solution.Shuffle();
        }

        // https://leetcode.com/problems/shuffle-an-array/discuss/86001/C++-solution-with-Fisher-Yates-algorithm
        public class Solution
        {
            int[] original = null,
                  result = null;
            Random random = null;

            public Solution(int[] nums)
            {
                this.original = nums;
                this.result = new int[nums.Length];
                this.random = new Random();

                Reset();
            }

            /** Resets the array to its original configuration and return it. */
            public int[] Reset()
            {
                for (int i = 0; i < result.Length; i++)
                    result[i] = original[i];

                return this.result;
            }

            /** Returns a random shuffling of the array. */
            public int[] Shuffle()
            {
                for (int i = result.Length - 1; i > 0; i--)
                {
                    int j = random.Next(i + 1);

                    if (i != j)
                    {
                        result[i] += result[j];
                        result[j] = result[i] - result[j];
                        result[i] = result[i] - result[j];
                    }
                }

                return result;
            }
        }
    }
}
