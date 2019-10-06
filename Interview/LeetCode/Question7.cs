using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question7
    {
        public int reverse(int x)
        {
            int result = 0;

            while (x != 0)
            {
                int tail = x % 10;
                int tempResult = result * 10 + tail;

                if ((tempResult - tail) / 10 != result)
                    return 0;
                result = tempResult;

                x = x / 10;
            }

            return result;
        }
    }
}