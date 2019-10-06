using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question189
    {
        public static void EntryPoint()
        {
            int[] nums = { 1, 2 };
            (new Question189()).Rotate(nums, 1);
        }

        public void Rotate(int[] nums, int k)
        {
            if (nums == null || k == 0)
                return;

            k %= nums.Length;
            Reverse(nums, 0, nums.Length - 1);
            Reverse(nums, 0, k - 1);
            Reverse(nums, k, nums.Length - 1);
        }

        private void Reverse(int[] nums, int start, int end)
        {
            int i = start, j = end, temp = 0;

            while (i < j)
            {
                temp = nums[j];
                nums[j] = nums[i];
                nums[i] = temp;

                i++;
                j--;
            }
        }
    }
}