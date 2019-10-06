using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question461
    {
        public int HammingDistance(int x, int y)
        {
            int count = 0,
                tempX = 0,
                tempY = 0,
                temp = 0;

            while (x != 0 || y != 0)
            {
                tempX = x & 1;
                tempY = y & 1;

                temp = tempX ^ tempY;

                count = temp == 1 ? count + 1 : count;

                x >>= 1;
                y >>= 1;
            }

            return count;
        }
    }
}
