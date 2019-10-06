using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question907
    {
        // https://leetcode.com/problems/sum-of-subarray-minimums/discuss/170750/C++JavaPython-Stack-Solution
        public int SumSubarrayMins(int[] A)
        {
            int res = 0,
                mod = (int)1e9 + 7;
            int[] left = new int[A.Length],
                  right = new int[A.Length];
            Stack<int[]> s1 = new Stack<int[]>(),
                         s2 = new Stack<int[]>();

            for (int i = 0; i < A.Length; i++)
            {
                int count = 1;

                while (s1.Count != 0 && s1.Peek()[0] > A[i])
                    count += s1.Pop()[1];
                s1.Push(new int[] { A[i], count });

                left[i] = count;
            }

            for (int i = A.Length - 1; i >= 0; i--)
            {
                int count = 1;

                while (s2.Count != 0 && s2.Peek()[0] >= A[i])
                    count += s2.Pop()[1];
                s2.Push(new int[] { A[i], count });

                right[i] = count;
            }

            for (int i = 0; i < A.Length; ++i)
                res = (res + A[i] * left[i] * right[i]) % mod;

            return res;
        }
    }
}
