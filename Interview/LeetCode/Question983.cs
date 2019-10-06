using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question983
    {
        int[] costs = null;
        int[] memo = new int[366];
        HashSet<int> dayset = new HashSet<int>();

        public int MincostTickets(int[] days, int[] costs)
        {
            this.costs = costs;

            foreach (var item in days)
                dayset.Add(item);

            return dp(1);
        }

        public int dp(int i)
        {
            if (i > 365)
                return 0;
            if (memo[i] != 0)
                return memo[i];

            int ans = 0;

            if (dayset.Contains(i))
            {
                ans = Math.Min(dp(i + 1) + costs[0], dp(i + 7) + costs[1]);
                ans = Math.Min(ans, dp(i + 30) + costs[2]);
            }
            else
                ans = dp(i + 1);

            memo[i] = ans;

            return ans;
        }
    }
}
