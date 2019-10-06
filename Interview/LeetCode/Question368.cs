using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question368
    {
        public static void EntryPoint()
        {
            (new Question368()).LargestDivisibleSubset(new int[] { 1, 2, 3 });
        }

        // https://leetcode.com/problems/largest-divisible-subset/discuss/222652/15-lines-concise-Java-DP-solution
        public IList<int> LargestDivisibleSubset(int[] nums)
        {
            IList<int> result = new List<int>(),
                       temp = null;
            List<IList<int>> dp = new List<IList<int>>();

            if (nums.Length != 0)
            {
                Array.Sort(nums);

                for (int i = 0; i < nums.Length; i++)
                {
                    temp = new List<int>();
                    temp.Add(nums[i]);

                    for (int j = 0; j < i; j++)
                        if (nums[i] % nums[j] == 0 && dp[j].Count + 1 > temp.Count)
                        {
                            temp = new List<int>();
                            foreach (var item in dp[j])
                                temp.Add(item);

                            temp.Add(nums[i]);
                        }

                    result = temp.Count > result.Count ? temp : result;
                    dp.Add(temp);
                }
            }

            return result;
        }
    }
}
