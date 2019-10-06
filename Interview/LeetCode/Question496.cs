using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question496
    {
        // https://leetcode.com/problems/next-greater-element-i/solution/
        public int[] NextGreaterElement(int[] nums1, int[] nums2)
        {
            int[] result = new int[nums1.Length];
            Stack<int> stack = new Stack<int>();
            Dictionary<int, int> dictionary = new Dictionary<int, int>();

            foreach (var item in nums2)
            {
                while (stack.Count != 0 && stack.Peek() < item)
                    dictionary.Add(stack.Pop(), item);

                stack.Push(item);
            }

            while (stack.Count != 0)
                dictionary.Add(stack.Pop(), -1);

            for (int i = 0; i < nums1.Length; i++)
                result[i] = dictionary[nums1[i]];

            return result;
        }
    }
}
