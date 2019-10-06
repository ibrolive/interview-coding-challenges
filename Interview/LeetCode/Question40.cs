using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question40
    {
        public static void EntryPoint()
        {
            (new Question40()).CombinationSum2(new int[] { 10, 1, 2, 7, 6, 1, 5 }, 8);
        }

        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            IList<IList<int>> result = new List<IList<int>>();

            Array.Sort(candidates);

            Helper(candidates, target, 0, new List<int>(), result);

            return result;
        }

        private void Helper(int[] candidates, int target, int start, List<int> currentCombination, IList<IList<int>> result)
        {
            List<int> temp = null;

            if (target < 0)
                return;

            if (target == 0)
            {
                temp = new List<int>();

                foreach (var item in currentCombination)
                    temp.Add(item);

                result.Add(temp);

                return;
            }

            if (start < candidates.Length)
            {
                for (int i = start; i < candidates.Length; i++)
                {
                    if (i != start && candidates[i - 1] == candidates[i])
                        continue;

                    currentCombination.Add(candidates[i]);

                    Helper(candidates, target - candidates[i], i + 1, currentCombination, result);

                    currentCombination.RemoveAt(currentCombination.Count - 1);
                }
            }
        }
    }
}
