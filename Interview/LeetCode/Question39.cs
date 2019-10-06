using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question39
    {
        public static void EntryPoint()
        {
            (new Question39()).CombinationSum(new int[] { 2, 3, 6, 7 }, 7);
        }

        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            IList<IList<int>> result = new List<IList<int>>();

            SubsetSum(candidates, target, candidates.Length - 1, new List<int>(), result);

            return result;
        }

        public void SubsetSum(int[] candidates, int target, int end, List<int> previousCombination, IList<IList<int>> result)
        {
            int count = 1;
            List<int> currentCombination = CopyList(previousCombination);

            if ((end < 0 && target != 0) || target < 0)
                return;
            else if (target == 0)
                result.Add(previousCombination);
            else
            {
                SubsetSum(candidates, target, end - 1, CopyList(previousCombination), result);

                while (target - candidates[end] * count >= 0)
                {
                    currentCombination.Add(candidates[end]);
                    SubsetSum(candidates, target - candidates[end] * count++, end - 1, CopyList(currentCombination), result);
                }
            }
        }

        public List<int> CopyList(List<int> source)
        {
            List<int> result = new List<int>();

            foreach (var item in source)
                result.Add(item);

            return result;
        }
    }
}