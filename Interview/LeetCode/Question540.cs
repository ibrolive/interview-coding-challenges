using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question540
    {
        private int result = int.MinValue;

        public static void EntryPoint()
        {
            (new Question540()).SingleNonDuplicate(new int[] { 3, 3, 7, 7, 10, 11, 11 });
        }

        public int SingleNonDuplicate(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return int.MinValue;
            else if (nums.Length == 1)
                return nums[0];

            FindSingleNum(nums, 0, nums.Length - 1);

            return result;
        }

        public void FindSingleNum(int[] input, int start, int end)
        {
            int midIndex = (start + end) / 2;

            if (midIndex - 1 >= start && 
                midIndex + 1 <= end && 
                input[midIndex] != input[midIndex - 1] &&
                input[midIndex] != input[midIndex + 1])
            {
                result = input[midIndex];
                return;
            }
            else if (input[start] != input[start + 1])
            {
                result = input[start];
                return;
            }
            else if (input[end] != input[end - 1])
            {
                result = input[end];
                return;
            }

            if (midIndex - 1 >= start &&
                midIndex - 2 >= start &&
                input[midIndex] == input[midIndex - 1])
                FindSingleNum(input, start, midIndex - 2);
            else if (midIndex - 1 >= start &&
                     midIndex - 2 >= start &&
                     input[midIndex] != input[midIndex - 1])
                FindSingleNum(input, start, midIndex - 1);

            if (midIndex + 1 <= end &&
                midIndex + 2 <= end &&
                input[midIndex] == input[midIndex + 1])
                FindSingleNum(input, midIndex + 2, end);
            else if (midIndex + 1 <= end &&
                     midIndex + 2 <= end &&
                     input[midIndex] != input[midIndex + 1])
                FindSingleNum(input, midIndex + 1, end);
        }
    }
}