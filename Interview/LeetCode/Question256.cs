using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question256
    {
        public int MinCost(int[,] costs)
        {
            int[,] totalCosts = new int[costs.GetLength(0) + 1, 3];

            for (int i = 1; i <= costs.GetLength(0); i++)
            {
                totalCosts[i, 0] = Math.Min(totalCosts[i - 1, 1], totalCosts[i - 1, 2]) + costs[i - 1, 0];
                totalCosts[i, 1] = Math.Min(totalCosts[i - 1, 0], totalCosts[i - 1, 2]) + costs[i - 1, 1];
                totalCosts[i, 2] = Math.Min(totalCosts[i - 1, 0], totalCosts[i - 1, 1]) + costs[i - 1, 2];
            }

            return Math.Min(totalCosts[costs.GetLength(0), 0],
                            Math.Min(totalCosts[costs.GetLength(0), 1], totalCosts[costs.GetLength(0), 2]));
        }
    }
}
