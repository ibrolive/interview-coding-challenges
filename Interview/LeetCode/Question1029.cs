using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question1029
    {
        // https://leetcode.com/problems/two-city-scheduling/solution/
        // https://leetcode.com/problems/two-city-scheduling/discuss/279125/C
        // https://leetcode.com/problems/two-city-scheduling/discuss/280619/Easy-sorting-solution-with-CSharp
        public int TwoCitySchedCost(int[][] costs)
        {
            var list = costs.OrderByDescending(c => Math.Abs(c[0] - c[1])).ToList();

            int res = 0,
                a = 0,
                b = 0;

            foreach (var l in list)
                if (a == costs.Length / 2)
                    res += l[1];
                else if (b == costs.Length / 2)
                    res += l[0];
                else
                {
                    res += Math.Min(l[0], l[1]);

                    if (l[0] < l[1])
                        a++;
                    else
                        b++;
                }

            return res;
        }
    }
}
