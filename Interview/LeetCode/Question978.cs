using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question978
    {
        public static void EntryPoint()
        {
            (new Question978()).MaxTurbulenceSize(new int[] { 9, 4, 2, 10, 7, 8, 8, 1, 9 });
        }

        public int MaxTurbulenceSize(int[] A)
        {
            int ans = 1,
                anchor = 0;

            for (int i = 1; i < A.Length; i++)
            {
                int c = A[i - 1].CompareTo(A[i]);

                if (c == 0)
                    anchor = i;
                else if (i == A.Length - 1 || c * A[i].CompareTo(A[i + 1]) != -1)
                {
                    ans = Math.Max(ans, i - anchor + 1);
                    anchor = i;
                }
            }

            return ans;
        }
    }
}
