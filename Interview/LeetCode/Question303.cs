using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question303
    {
        public static void EntryPoint()
        {
            (new NumArray(new int[] { -2, 0, 3, -5, 2, -1 })).SumRange(0, 2);
        }
    }

    public class NumArray
    {
        private int[] source = null;

        public NumArray(int[] nums)
        {
            if (nums != null || nums.Length != 0)
                for (int i = 1; i < nums.Length; i++)
                    nums[i] += nums[i - 1];

            source = nums;
        }

        public int SumRange(int i, int j)
        {
            return source[j] - (i == 0 ? 0 : source[i - 1]);
        }
    }
}
