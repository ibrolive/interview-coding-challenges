using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question268
    {
        public int MissingNumber(int[] nums)
        {
            int expectedSum = nums.Length * (nums.Length + 1) / 2, currentSum = 0;

            foreach (var item in nums)
                currentSum += item;

            return expectedSum - currentSum;
        }
    }
}