using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question503
    {
        // https://leetcode.com/problems/next-greater-element-ii/solution/
        public int[] NextGreaterElements(int[] nums)
        {
            int[] res = new int[nums.Length];
            Stack<int> stack = new Stack<int>();

            for (int i = 2 * nums.Length - 1; i >= 0; --i)
            {
                while (stack.Count != 0 && nums[stack.Peek()] <= nums[i % nums.Length])
                    stack.Pop();

                res[i % nums.Length] = stack.Count == 0 ? -1 : nums[stack.Peek()];

                stack.Push(i % nums.Length);
            }

            return res;
        }
    }
}
