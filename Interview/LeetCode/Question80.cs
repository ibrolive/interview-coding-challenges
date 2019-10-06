using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question80
    {
        public static void EntryPoint()
        {
            (new Question80()).RemoveDuplicates(new int[] { 1, 1, 2, 2 });
        }

        public int RemoveDuplicates(int[] nums)
        {
            int index = 0;

            foreach (var num in nums)
                if (index <= 1 || num > nums[index - 2])
                    nums[index++] = num;

            return index;
        }
    }
}