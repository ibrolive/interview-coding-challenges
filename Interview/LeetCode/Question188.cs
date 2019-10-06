using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question188
    {
        // https://www.youtube.com/watch?v=oDhu5uGq_ic&t=1566s
        public int MaxProfit(int k, int[] prices)
        {
            if (k == 0 || prices.Length == 0)
                return 0;

            if (k > prices.Length / 2)
            {
                int tmp = 0;

                for (int i = 1; i < prices.Length; ++i)
                    tmp += Math.Max(0, prices[i] - prices[i - 1]);

                return tmp;
            }

            int[,] T = new int[k + 1, prices.Length];

            for (int i = 1; i < T.GetLength(0); i++)
            {
                int maxDiff = -prices[0];

                for (int j = 1; j < T.GetLength(1); j++)
                {
                    T[i, j] = Math.Max(T[i, j - 1], prices[j] + maxDiff);
                    maxDiff = Math.Max(maxDiff, T[i - 1, j] - prices[j]);
                }
            }

            return T[k, prices.Length - 1];
        }
    }
}
