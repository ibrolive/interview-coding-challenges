using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question390
    {
        public static void EntryPoint()
        {
            (new Question390()).LastRemaining(9);
        }

        public int LastRemaining(int n)
        {
            int head = 1,
                remaining = n,
                step = 1;
            bool leftToRight = true;

            while (remaining > 1)
            {
                if (leftToRight || remaining % 2 == 1)
                    head += step;

                step *= 2;
                remaining /= 2;
                leftToRight = !leftToRight;
            }

            return head;
        }
    }
}
