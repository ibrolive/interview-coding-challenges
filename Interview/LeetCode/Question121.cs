using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question121
    {
        public int MaxProfit(int[] prices)
        {
            int min = int.MaxValue;
            int maxProfit = 0;

            foreach (int i in prices)
                if (i < min)
                    min = i;
                else if (i - min > maxProfit)
                    maxProfit = i - min;

            return maxProfit;
        }
    }
}