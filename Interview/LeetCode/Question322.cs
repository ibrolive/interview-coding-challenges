using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question322
    {
        public int CoinChange(int[] coins, int amount)
        {
            if (amount == 0)
                return 0;

            int[] DP = new int[amount + 1];
            DP[0] = 1;

            foreach (var c in coins)
                for (int i = c; i <= amount; i++)
                    if (DP[i - c] != 0)
                    {
                        if (DP[i] != 0)
                            DP[i] = Math.Min(DP[i], DP[i - c] + 1);
                        else
                            DP[i] = DP[i - c] + 1;
                    }

            return DP[amount] == 0 ? -1 : DP[amount] - 1;
        }
    }
}
