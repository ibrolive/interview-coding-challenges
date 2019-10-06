using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question55
    {
        public static void EntryPoint()
        {
            (new Question55()).CanJump(new int[] { 2, 3, 1, 1, 4 });
        }

        //public bool CanJump(int[] nums)
        //{
        //    return DFS(nums, 0);
        //}

        //private bool DFS(int[] nums, int currentIndex)
        //{
        //    if (currentIndex >= nums.Length - 1)
        //        return true;

        //    for (int i = 1; i <= nums[currentIndex]; i++)
        //        return DFS(nums, currentIndex + i);

        //    return false;
        //}

        public bool CanJump(int[] nums)
        {
            if (nums.Length == 1 && nums[0] == 0)
                return true;
            else if (nums[0] == 0)
                return false;

            int count = 0,
                i = nums.Length - 1,
                j = i;

            while (i >= 0)
            {
                count = 0;
                j = i;

                while (j > 0)
                {
                    count++;

                    if (nums[j - 1] >= count)
                        break;

                    j--;
                }

                if (i != 0 && j == 0)
                    return false;

                i = j - 1;
            }

            return true;
        }
    }
}