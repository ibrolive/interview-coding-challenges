using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question90
    {
        public static void EntryPoint()
        {
            (new Question90()).SubsetsWithDup(new int[] { 4, 4, 4, 1, 4 });
        }

        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return new List<IList<int>>();

            IList<IList<int>> result = new List<IList<int>>();

            Array.Sort(nums);

            for (int i = 0; i < nums.Length; i++)
            {
                if (i != 0 && nums[i - 1] == nums[i])
                    continue;

                Helper(nums, i, new List<int>(), result);
            }

            result.Add(new List<int>());

            return result;
        }

        private void Helper(int[] nums, int index, List<int> previousRound, IList<IList<int>> result)
        {
            List<int> temp = new List<int>();

            if (index < nums.Length)
            {
                foreach (var item in previousRound)
                    temp.Add(item);

                temp.Add(nums[index]);
                result.Add(temp);

                for (int i = index + 1; i < nums.Length; i++)
                {
                    if (i != index + 1 && nums[i - 1] == nums[i])
                        continue;

                    Helper(nums, i, temp, result);
                }
            }
        }
    }
}
