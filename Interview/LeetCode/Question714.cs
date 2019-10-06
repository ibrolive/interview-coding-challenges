using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question714
    {
        public static void EntryPoint()
        {
            //(new Question714()).MaxProfit(new int[] { 1, 3, 2, 8, 4, 9 }, 2);
            (new Question714()).MaxProfit(new int[] { 4, 3, 2, 1 }, 2);
        }

        public int MaxProfit(int[] prices, int fee)
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
                buy[i] = Math.Max(skip[i - 1], sell[i - 1]) - prices[i];
                hold[i] = Math.Max(buy[i - 1], hold[i - 1]);
                skip[i] = Math.Max(skip[i - 1], sell[i - 1]);
                sell[i] = Math.Max(buy[i - 1], hold[i - 1]) + prices[i] - fee;
            }

            int max = Math.Max(buy[prices.Length - 1], hold[prices.Length - 1]);
            max = Math.Max(skip[prices.Length - 1], max);
            max = Math.Max(sell[prices.Length - 1], max);

            return Math.Max(max, 0);
        }
    }
}
