using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question263
    {
        public bool IsUgly(int num)
        {
            if (num == 0)
                return false;

            int temp = num;

            while (temp % 2 == 0)
                temp /= 2;

            while (temp % 3 == 0)
                temp /= 3;

            while (temp % 5 == 0)
                temp /= 5;

            return temp == 1 ? true : false;
        }
    }
}
