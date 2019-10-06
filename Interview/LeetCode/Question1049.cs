using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question1049
    {
        public int LastStoneWeightII(int[] stones)
        {
            HashSet<int> sums = new HashSet<int>();
            sums.Add(0);

            foreach (var stone in stones)
            {
                HashSet<int> nextSums = new HashSet<int>();

                foreach (var s in sums)
                {
                    if (!nextSums.Contains(s + stone))
                        nextSums.Add(s + stone);

                    if (!nextSums.Contains(s - stone))
                        nextSums.Add(s - stone);
                }

                sums = nextSums;
            }

            return sums.Where(s => s >= 0).Min();
        }
    }
}
