using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question153
    {
        public static void EntryPoint()
        {
            (new Question153()).FindMin(new int[] { 2, 1 });
        }

        public int FindMin(int[] nums)
        {
            int start = 0, end = nums.Length - 1, middle = 0;

            while (start < end)
            {
                middle = start + (end - start) / 2;

                if (nums[middle] < nums[end])
                    end = middle;
                else
                    start = middle + 1;
            }

            return nums[start];
        }
    }
}