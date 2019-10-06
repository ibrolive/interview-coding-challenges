using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question487
    {
        // https://leetcode.com/problems/max-consecutive-ones-ii/discuss/290069/C-simple-code.-Beats-100-speed-and-100-Memory
        // https://leetcode.com/problems/max-consecutive-ones-ii/discuss/97003/Simple-Java-solution-using-Q
        public int FindMaxConsecutiveOnes(int[] nums)
        {
            Queue<int> queue = new Queue<int>();
            int max = 0;
            int i = 0;

            while (i < nums.Length)
            {
                while (i < nums.Length && nums[i] != 0)
                {
                    queue.Enqueue(nums[i]);
                    i++;
                }

                if (queue.Contains(0))
                {
                    if (queue.Count > max)
                        max = queue.Count;
                    while (queue.Count != 0 && queue.Peek() != 0)
                        queue.Dequeue();
                    if (queue.Count != 0 && queue.Peek() == 0)
                        queue.Dequeue();
                }

                if (i < nums.Length)
                    queue.Enqueue(nums[i]);

                i++;
            }

            if (queue.Count != 0 && queue.Count > max)
                max = queue.Count;

            return max;
        }
    }
}
