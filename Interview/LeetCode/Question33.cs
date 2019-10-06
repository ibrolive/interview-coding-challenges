using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question33
    {
        public static void EntryPoint()
        {
            (new Question33()).Search(new int[] { 5, 1, 3 }, 5);
        }

        public int Search(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
                return -1;

            int start = 0, 
                end = nums.Length - 1, 
                middle = 0, 
                middleValue = 0;

            while (start <= end)
            {
                middle = start + (end - start) / 2;

                if ((nums[middle] < nums[0]) == target < nums[0])
                    middleValue = nums[middle];
                else if (target < nums[0])
                    middleValue = int.MinValue;
                else if (target >= nums[0])
                    middleValue = int.MaxValue;

                if (middleValue == target)
                    return middle;
                else if (middleValue < target)
                    start = middle + 1;
                else
                    end = middle - 1;
            }

            return -1;
        }
    }
}