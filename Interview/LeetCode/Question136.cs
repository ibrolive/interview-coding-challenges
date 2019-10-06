using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question136
    {
        public static void EntryPoint()
        {
            (new Question136()).SingleNumber(new int[] { 1, 2, 3, 3, 1 });
        }

        public int SingleNumber(int[] nums)
        {
            int result = 0;

            for (int i = 0; i < nums.Length; i++)
                result ^= nums[i];

            return result;
        }
    }
}