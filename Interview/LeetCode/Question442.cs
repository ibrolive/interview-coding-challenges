using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question442
    {
        public static void EntryPoint()
        {
            (new Question442()).FindDuplicates(new int[] { 10, 2, 5, 10, 9, 1, 1, 4, 3, 7 });
        }

        public IList<int> FindDuplicates(int[] nums)
        {
            IList<int> result = new List<int>();
            int index = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                index = Math.Abs(nums[i]) - 1;

                if (nums[index] < 0)
                    result.Add(Math.Abs(nums[i]));
                else
                    nums[index] = -nums[index];
            }

            return result;
        }
    }
}
