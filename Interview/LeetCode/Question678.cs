using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question678
    {
        // https://leetcode.com/problems/valid-parenthesis-string/solution/
        public bool CheckValidString(string s)
        {
            int low = 0,
                high = 0;

            foreach (var item in s)
            {
                low += item == '(' ? 1 : -1;
                high += item != ')' ? 1 : -1;

                if (high < 0)
                    break;

                low = Math.Max(low, 0);
            }

            return low == 0;
        }
    }
}
