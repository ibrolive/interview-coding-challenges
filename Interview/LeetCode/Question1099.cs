using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question1099
    {
        public int TwoSumLessThanK(int[] A, int K)
        {
            int result = Int32.MinValue,
                i = 0,
                j = A.Length - 1;

            Array.Sort(A);

            while (i < j)
            {
                if (A[i] + A[j] < K && A[i] + A[j] > result)
                    result = A[i] + A[j];

                if (A[i] + A[j] < K)
                    i++;
                else
                    j--;
            }

            return result;
        }
    }
}
