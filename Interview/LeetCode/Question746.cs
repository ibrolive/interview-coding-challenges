using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question746
    {
        public int MinCostClimbingStairs(int[] cost)
        {
            if (cost == null || cost.Length == 0)
                return 0;
            else if (cost.Length == 1)
                return cost[0];
            else if (cost.Length == 2)
                return cost[0] <= cost[1] ? cost[0] : cost[1];

            int[] totalCost = new int[cost.Length + 1];

            totalCost[0] = cost[0];
            totalCost[1] = cost[1];

            for (int i = 2; i <= cost.Length; i++)
                if (i < cost.Length)
                    totalCost[i] = Math.Min(totalCost[i - 1] + cost[i], totalCost[i - 2] + cost[i]);
                else
                    totalCost[i] = Math.Min(totalCost[i - 1], totalCost[i - 2]);

            return totalCost[cost.Length];
        }
    }
}
