using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question81
    {
        public static void EntryPoint()
        {
            (new Question81()).Search(new int[] { 3, 1, 1, 1, 1 }, 3);
        }

        // https://leetcode.com/problems/search-in-rotated-sorted-array-ii/discuss/28295/Easy-C%2B%2B-Solution-based-on-Version-I-of-the-Problem
        public bool Search(int[] nums, int target)
        {
            int l = 0,
                r = nums.Length - 1,
                mid = 0,
                midValue = 0;

            while (l <= r)
            {
                // if the duplications aren't removed, there will be a wrong answer for the testing case: { 1, 3, 1, 1, 1}. 
                // The code path to detect whether target and middle value is in the same part of sorted array will return a wrong result.
                while (l < r && nums[l] == nums[l + 1])
                    l++;

                while (r > l && nums[r] == nums[r - 1])
                    r--;

                mid = l + (r - l) / 2;

                if ((nums[0] <= target) == (nums[0] <= nums[mid]))
                    midValue = nums[mid];
                else if (nums[0] <= target)
                    midValue = Int32.MaxValue;
                else
                    midValue = Int32.MinValue;

                if (midValue == target)
                    return true;
                else if (midValue <= target)
                    l = mid + 1;
                else
                    r = mid - 1;
            }

            return false;
        }
    }
}
