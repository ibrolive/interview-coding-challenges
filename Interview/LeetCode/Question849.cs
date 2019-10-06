using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question849
    {
        public int MaxDistToClosest(int[] seats)
        {
            int N = seats.Length,
                prev = -1,
                future = 0,
                ans = 0;

            for (int i = 0; i < N; ++i)
                if (seats[i] == 1)
                    prev = i;
                else
                {
                    while (future < N && seats[future] == 0 || future < i)
                        future++;

                    int left = prev == -1 ? N : i - prev;
                    int right = future == N ? N : future - i;

                    ans = Math.Max(ans, Math.Min(left, right));
                }

            return ans;
        }
    }
}
