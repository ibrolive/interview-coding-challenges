using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question9
    {
        public bool IsPalindrome(int x)
        {
            if (x < 0)
                return false;
            else if (x < 10)
                return true;

            int temp = x,
                reverse = 0;

            while (temp != 0)
            {
                reverse = temp % 10 + reverse * 10;
                temp /= 10;
            }

            return x == reverse;
        }
    }
}