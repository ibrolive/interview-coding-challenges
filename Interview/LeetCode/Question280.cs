using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question280
    {
        public static void EntryPoint()
        {
            (new Question280()).WiggleSort(new int[] { 1, 3, 1, 2 });
        }

        public void WiggleSort(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return;

            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (i % 2 == 0 && nums[i] > nums[i + 1])
                    Swap(nums, i, i + 1);
                else if (i % 2 != 0 && nums[i] < nums[i + 1])
                    Swap(nums, i, i + 1);
            }
        }

        private void Swap(int[] nums, int index1, int index2)
        {
            nums[index1] = nums[index1] + nums[index2];
            nums[index2] = nums[index1] - nums[index2];
            nums[index1] = nums[index1] - nums[index2];
        }
    }
}
