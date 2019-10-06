using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question977
    {
        public static void EntryPoint()
        {
            (new Question977()).SortedSquares(new int[] { -1 });
        }

        public int[] SortedSquares(int[] A)
        {
            if (A == null || A.Length == 0)
                return new int[] { };

            int i = 0,
                j = 0,
                index = 0;
            int[] result = new int[A.Length];

            while (i < A.Length && A[i] < 0)
                i++;
            j = i;
            i--;

            while (i > -1 && j < A.Length)
                if (A[i] * A[i] <= A[j] * A[j])
                    result[index++] = A[i] * A[i--];
                else
                    result[index++] = A[j] * A[j++];

            while (i > -1)
                result[index++] = A[i] * A[i--];

            while (j < A.Length)
                result[index++] = A[j] * A[j++];

            return result;
        }
    }
}
