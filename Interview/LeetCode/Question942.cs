using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question942
    {
        // https://leetcode.com/problems/di-string-match/solution/
        public int[] DiStringMatch(string S)
        {
            int N = S.Length,
                lo = 0,
                hi = N;
            int[] ans = new int[N + 1];

            for (int i = 0; i < N; ++i)
                if (S[i] == 'I')
                    ans[i] = lo++;
                else
                    ans[i] = hi--;

            ans[N] = lo;

            return ans;
        }
    }
}
