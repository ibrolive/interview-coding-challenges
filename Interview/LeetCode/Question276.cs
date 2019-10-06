using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question276
    {
        // https://leetcode.com/problems/paint-fence/discuss/71156/O(n)-time-java-solution-O(1)-space
        public int NumWays(int n, int k)
        {
            if (n == 0) return 0;
            else if (n == 1) return k;
            int diffColorCounts = k * (k - 1);
            int sameColorCounts = k;
            for (int i = 2; i < n; i++)
            {
                int temp = diffColorCounts;
                diffColorCounts = (diffColorCounts + sameColorCounts) * (k - 1);
                sameColorCounts = temp;
            }
            return diffColorCounts + sameColorCounts;
        }
    }
}
