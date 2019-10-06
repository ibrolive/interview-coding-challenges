using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question396
    {
        public int MaxRotateFunction(int[] A)
        {
            if (A == null || A.Length == 0)
                return 0;

            int n = A.Length;
            int sum = 0;
            int f0 = 0;

            for (int i = 0; i < n; i++)
            {
                sum += A[i];
                f0 += i * A[i];
            }

            int max = f0;

            for (int k = 1, fkminus1 = f0; k < n; k++)
            {
                int fk = fkminus1 + sum - n * A[n - k];

                max = Math.Max(max, fk);
                fkminus1 = fk;
            }

            return max;
        }
    }
}
