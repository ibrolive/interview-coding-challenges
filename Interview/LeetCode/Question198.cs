using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question198
    {
        public int Rob(int[] nums)
        {
            int[,] amount = new int[nums.Length + 1, 2];

            for (int i = 1; i <= nums.Length; i++)
            {
                amount[i, 0] = Math.Max(amount[i - 1, 0], amount[i - 1, 1]);
                amount[i, 1] = amount[i - 1, 0] + nums[i - 1];
            }

            return Math.Max(amount[nums.Length, 0], amount[nums.Length, 1]);
        }
    }
}
