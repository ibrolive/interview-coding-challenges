using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question264
    {
        // https://leetcode.com/problems/ugly-number-ii/discuss/69362/O(n)-Java-solution
        // https://leetcode.com/problems/ugly-number-ii/discuss/69373/Short-and-O(n)-Python-and-C++
        // https://www.geeksforgeeks.org/ugly-numbers/
        public int NthUglyNumber(int n)
        {
            int[] ugly = new int[n];
            int index2 = 0, index3 = 0, index5 = 0,
                factor2 = 2, factor3 = 3, factor5 = 5,
                min = 0;

            ugly[0] = 1;

            for (int i = 1; i < n; i++)
            {
                ugly[i] = min = Math.Min(Math.Min(factor2, factor3), factor5);

                if (factor2 == min)
                    factor2 = 2 * ugly[++index2];
                if (factor3 == min)
                    factor3 = 3 * ugly[++index3];
                if (factor5 == min)
                    factor5 = 5 * ugly[++index5];
            }

            return ugly[n - 1];
        }
    }
}
