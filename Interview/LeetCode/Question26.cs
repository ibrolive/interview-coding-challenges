using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question26
    {
        public int RemoveDuplicates(int[] nums)
        {
            int index = 0;

            foreach (var num in nums)
                if (index == 0 || num > nums[index - 1])
                    nums[index++] = num;

            return index;
        }
    }
}