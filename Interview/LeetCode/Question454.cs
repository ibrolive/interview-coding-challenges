using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question454
    {
        public int FourSumCount(int[] A, int[] B, int[] C, int[] D)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int tempSum,
                count = 0;

            for (int i = 0; i < A.Length; i++)
                for (int j = 0; j < B.Length; j++)
                {
                    tempSum = A[i] + B[j];

                    if (dict.ContainsKey(tempSum))
                        dict[tempSum]++;
                    else
                        dict.Add(tempSum, 1);
                }

            for (int i = 0; i < C.Length; i++)
                for (int j = 0; j < D.Length; j++)
                {
                    tempSum = -(C[i] + D[j]);

                    if (dict.ContainsKey(tempSum))
                        count += dict[tempSum];
                }

            return count;
        }
    }
}
