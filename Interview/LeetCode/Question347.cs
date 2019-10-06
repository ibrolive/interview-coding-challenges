using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question347
    {
        public static void EntryPoint()
        {
            int[] nums = { 1, 1, 1, 2, 2, 3 };
            (new Question347()).TopKFrequent(nums, 2);
        }

        public IList<int> TopKFrequent(int[] nums, int k)
        {
            if (nums == null || k == 0)
                return null;

            Dictionary<int, int> frequency = new Dictionary<int, int>();
            List<int> result = new List<int>();
            int currentMax = 0;

            for (int i = 0; i <= nums.Length - 1; i++)
                if (frequency.Keys.Contains<int>(nums[i]))
                    frequency[nums[i]] = frequency[nums[i]] + 1;
                else
                    frequency.Add(nums[i], 1);

            for (int i = k; i >= 1; i--)
            {
                currentMax = frequency.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
                result.Add(currentMax);
                frequency.Remove(currentMax);
            }

            return result;
        }
    }
}