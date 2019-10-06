using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question202
    {
        public static void EntryPoint()
        {
            (new Question202()).IsHappy(19);
        }

        // Why count 10?
        // Because Numbers that are happy follow a sequence that ends in 1. All non-happy numbers follow sequences that reach the cycle: 4, 16, 37, 58, 89, 145, 42, 20, 4,...
        // Reference: https://en.wikipedia.org/wiki/Happy_number
        public bool IsHappy(int n)
        {
            int temp, 
                counter = 10;

            if (n == 0)
                return false;

            while (counter-- > 0)
            {
                temp = n;
                n = 0;

                while (temp != 0)
                {
                    n += (temp % 10) * (temp % 10);
                    temp /= 10;
                }

                if (n == 1)
                    return true;
            }

            return false;
        }
    }
}
