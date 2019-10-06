using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question470
    {
        // https://leetcode.com/problems/implement-rand10-using-rand7/solution/
        public int Rand10()
        {
            int row, col, idx;
            do
            {
                row = rand7();
                col = rand7();
                idx = col + (row - 1) * 7;
            } while (idx > 40);
            return 1 + (idx - 1) % 10;
        }

        private int rand7()
        {
            return 0;
        }
    }
}
