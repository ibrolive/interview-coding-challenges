using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question31
    {
        public static void EntryPoint()
        {
            (new Question31()).NextPermutation(new int[] { 3, 2, 1 });
        }

        public void NextPermutation(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return;

            int indexPeek = 0,
                indexLargestinSmallPartition = 0;

            for (indexPeek = nums.Length - 2; indexPeek >= 0; indexPeek--)
                if (nums[indexPeek] < nums[indexPeek + 1])
                    break;

            if (indexPeek < 0)
                Array.Sort(nums);
            else
            {
                for (indexLargestinSmallPartition = nums.Length - 1; indexLargestinSmallPartition >= indexPeek; indexLargestinSmallPartition--)
                    if (nums[indexLargestinSmallPartition] > nums[indexPeek])
                        break;

                nums[indexPeek] = nums[indexPeek] + nums[indexLargestinSmallPartition];
                nums[indexLargestinSmallPartition] = nums[indexPeek] - nums[indexLargestinSmallPartition];
                nums[indexPeek] = nums[indexPeek] - nums[indexLargestinSmallPartition];

                Array.Sort(nums, indexPeek + 1, nums.Length - indexPeek - 1);
            }
        }
    }
}
