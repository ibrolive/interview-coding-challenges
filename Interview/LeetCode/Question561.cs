using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question561
    {
        public static void EntryPoint()
        {
            (new Question561()).ArrayPairSum(new int[] { 1, 4, 3, 2 });
        }

        public int ArrayPairSum(int[] nums)
        {
            int sum = 0;

            Array.Sort(nums);

            for (var i = 0; i < nums.Length; i += 2)
                sum += nums[i];

            return sum;
        }
    }
}