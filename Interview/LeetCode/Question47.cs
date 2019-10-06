using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question47
    {
        public static void EntryPoint()
        {
            (new Question47()).PermuteUnique(new int[] { 1, 1, 0, 0, 1, -1, -1, 1 });
        }

        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            List<IList<int>> result = new List<IList<int>>();
            bool[] used = new bool[nums.Length];

            Array.Sort(nums);

            Backtrack(nums, used, new List<int>(), result);

            return result;
        }

        private void Backtrack(int[] nums, bool[] used, List<int> currentCombination, List<IList<int>> result)
        {
            if (currentCombination.Count == nums.Length)
            {
                result.Add(new List<int>(currentCombination));
                return;
            }

            for (int i = 0; i < nums.Length; i++)
                if (used[i])
                    continue;
                else if (i > 0 && nums[i] == nums[i - 1] && !used[i - 1])
                    continue;
                else
                {
                    currentCombination.Add(nums[i]);
                    used[i] = true;
                    Backtrack(nums, used, currentCombination, result);
                    currentCombination.RemoveAt(currentCombination.Count - 1);
                    used[i] = false;
                }
        }
    }
}
