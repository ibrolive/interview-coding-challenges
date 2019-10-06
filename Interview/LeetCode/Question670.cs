using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question670
    {
        public static void EntryPoint()
        {
            (new Question670()).MaximumSwap(2736);
        }

        public int MaximumSwap(int num)
        {
            char[] A = num.ToString().ToCharArray();
            int[] last = new int[10];

            for (int i = 0; i < A.Length; i++)
                last[A[i] - '0'] = i;

            for (int i = 0; i < A.Length; i++)
                for (int d = 9; d > A[i] - '0'; d--)
                    if (last[d] > i)
                    {
                        char tmp = A[i];

                        A[i] = A[last[d]];
                        A[last[d]] = tmp;

                        return Convert.ToInt32(new String(A));
                    }

            return num;
        }
    }
}
