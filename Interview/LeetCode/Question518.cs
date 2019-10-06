using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question518
    {
        public static void EntryPoint()
        {
            (new Question518()).Change(5, new int[] { 1, 2, 5 });
        }

        public int Change(int amount, int[] coins)
        {
            if (amount == 0)
                return 1;
            else if (coins == null || coins.Length == 0)
                return 0;

            int[] amounts = new int[amount + 1];

            amounts[0] = 1;

            foreach (var item in coins)
                for (int i = item; i <= amount; i++)
                    amounts[i] += amounts[i - item];

            return amounts[amount];
        }
    }
}
