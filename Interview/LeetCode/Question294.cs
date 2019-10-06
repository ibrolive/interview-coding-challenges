using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question294
    {
        // https://leetcode.com/problems/flip-game-ii/discuss/74010/Short-Java-and-Ruby
        public bool CanWin(string s)
        {
            for (int i = -1; (i = s.IndexOf("++", i + 1)) >= 0;)
                if (!CanWin(s.Substring(0, i) + "-" + s.Substring(i + 2)))
                    return true;

            return false;
        }
    }
}
