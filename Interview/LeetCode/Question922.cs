using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question922
    {
        public int[] SortArrayByParityII(int[] A)
        {
            int j = 1;

            for (int i = 0; i < A.Length; i += 2)
                if (A[i] % 2 == 1)
                {
                    while (A[j] % 2 == 1)
                        j += 2;

                    int tmp = A[i];
                    A[i] = A[j];
                    A[j] = tmp;
                }

            return A;
        }
    }
}
