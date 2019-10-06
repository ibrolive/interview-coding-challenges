using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question457
    {
        public static void EntryPoint()
        {
            (new Question457()).CircularArrayLoop(new int[] { 1, 2, 7, 8 });
        }

        // https://leetcode.com/problems/circular-array-loop/discuss/94148/Java-SlowFast-Pointer-Solution?page=1
        public bool CircularArrayLoop(int[] nums)
        {
            if (nums.Length == 1)
                return false;

            int n = nums.Length;

            for (int i = 0; i < n; i++)
            {
                if (nums[i] == 0)
                    continue;

                int j = i,
                    k = GetIndex(i, nums);

                while (nums[k] * nums[i] > 0 && nums[GetIndex(k, nums)] * nums[i] > 0)
                {
                    if (j == k)
                    {
                        if (j == GetIndex(j, nums))
                            break;

                        return true;
                    }

                    j = GetIndex(j, nums);
                    k = GetIndex(GetIndex(k, nums), nums);
                }

                j = i;
                int val = nums[i];

                while (nums[j] * val > 0)
                {
                    int next = GetIndex(j, nums);

                    nums[j] = 0;
                    j = next;
                }
            }

            return false;
        }

        public int GetIndex(int i, int[] nums)
        {
            int n = nums.Length;

            return i + nums[i] >= 0 ? (i + nums[i]) % n : n + ((i + nums[i]) % n);
        }
    }
}
