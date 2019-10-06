using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question258
    {
        public int AddDigits(int num)
        {
            int result = num,
                tempResult1 = 0,
                tempResult2 = 0;

            while (result / 10 > 0)
            {
                tempResult1 = result;
                while (tempResult1 != 0)
                {
                    tempResult2 += tempResult1 % 10;
                    tempResult1 /= 10;
                }

                result = tempResult2;
                tempResult2 = 0;
            }

            return result;
        }
    }
}