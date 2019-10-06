using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question905
    {
        public int[] sortArrayByParity(int[] A)
        {
            int i = 0,
                j = A.Length - 1;

            while (i < j)
            {
                if (A[i] % 2 > A[j] % 2)
                {
                    int tmp = A[i];
                    A[i] = A[j];
                    A[j] = tmp;
                }

                if (A[i] % 2 == 0) i++;
                if (A[j] % 2 == 1) j--;
            }

            return A;
        }
    }
}
