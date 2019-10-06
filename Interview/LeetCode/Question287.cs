using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question287
    {
        public static void EntryPoint()
        {
            (new Question287()).FindDuplicate(new int[] { 3, 1, 3, 4, 2 });
        }

        // Binary search:
        // https://leetcode.com/problems/find-the-duplicate-number/discuss/72844/Two-Solutions-(with-explanation)%3A-O(nlog(n))-and-O(n)-time-O(1)-space-without-changing-the-input-array
        public int FindDuplicate(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;

            int low = 1,
                high = nums.Length - 1,
                middle = low + (high - low) / 2,
                count = 0;

            while (low <= high)
            {
                foreach (var item in nums)
                    if (item >= low && item <= middle)
                        count++;

                if (count > middle - low + 1)
                    high = middle;
                else
                    low = middle + 1;

                middle = low + (high - low) / 2;
                count = 0;
            }

            return middle;
        }
    }
}
