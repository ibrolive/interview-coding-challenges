using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question309
    {
        public static void EntryPoint()
        {
            (new Question309()).MaxProfit(new int[] { 2, 1, 4 });
        }

        public int MaxProfit(int[] prices)
        {
            if (prices.Length <= 1)
                return 0;

            int[] buy = new int[prices.Length],
                  hold = new int[prices.Length],
                  skip = new int[prices.Length],
                  sell = new int[prices.Length];

            buy[0] = 0 - prices[0];
            hold[0] = 0 - prices[0];

            for (int i = 1; i < prices.Length; i++)
            {
                buy[i] = i == 1 ? (prices[0] > prices[1] ? 0 - prices[1] : buy[0]) : Math.Max(skip[i - 1], sell[i - 2]) - prices[i];
                hold[i] = Math.Max(buy[i - 1], hold[i - 1]);
                skip[i] = Math.Max(skip[i - 1], sell[i - 1]);
                sell[i] = Math.Max(buy[i - 1], hold[i - 1]) + prices[i];
            }

            int max = Math.Max(buy[prices.Length - 1], hold[prices.Length - 1]);
            max = Math.Max(skip[prices.Length - 1], max);
            max = Math.Max(sell[prices.Length - 1], max);

            return Math.Max(max, 0);
        }
    }
}
