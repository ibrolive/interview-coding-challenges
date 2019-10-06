using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question283
    {
        public static void EntryPoint()
        {
            //(new Question283()).MoveZeroes2(new int[] { 0, 1, 0, 3, 12 });
            (new Question283()).MoveZeroes(new int[] { 0, 0, 1 });
        }

        public void MoveZeroes(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return;

            int currentIndex, tempIndex, tailIndex = nums.Length - 1;

            for (currentIndex = 0; currentIndex <= tailIndex; currentIndex++)
            {
                if (nums[currentIndex] == 0)
                {
                    for (tempIndex = currentIndex; tempIndex <= tailIndex - 1; tempIndex++)
                        nums[tempIndex] = nums[tempIndex + 1];

                    nums[tailIndex] = 0;

                    tailIndex--;
                    currentIndex--; // Start from the new location.
                }
            }
        }
    }
}