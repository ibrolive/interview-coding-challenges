using System;

namespace Interview.Algorithm.DynamicProgramming
{
    // Refer: http://www.hawstein.com/posts/dp-novice-to-advanced.html
    class MinCoins
    {
        public static void EntryPoint()
        {
            Console.WriteLine((new MinCoins()).GetMinCoinVol(11, new int[] { 1, 3, 5 }));
        }

        private int GetMinCoinVol(int target, int[] coins)
        {
            if (target <= 0 || coins.Length == 0)
                return -1;

            int[] d = new int[target + 1];

            d[0] = 0;

            for (int i = 1; i <= target; i++)
            {
                d[i] = Int32.MaxValue;

                for (int j = 0; j < coins.Length; j++)
                    if (i - coins[j] >= 0)
                        if (d[i - coins[j]] + 1 < d[i])
                            d[i] = d[i - coins[j]] + 1;
            }

            return d[target];
        }
    }
}