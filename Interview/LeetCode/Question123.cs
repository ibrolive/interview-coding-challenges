using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question123
    {
        public int MaxProfit(int[] prices)
        {
            if (prices.Length == 0)
                return 0;

            int[,] T = new int[3, prices.Length];

            for (int i = 1; i < 3; i++)
            {
                int maxDiff = -prices[0];

                for (int j = 1; j < T.GetLength(1); j++)
                {
                    T[i, j] = Math.Max(T[i, j - 1], prices[j] + maxDiff);
                    maxDiff = Math.Max(maxDiff, T[i - 1, j] - prices[j]);
                }
            }

            return T[2, prices.Length - 1];
        }
    }
}
