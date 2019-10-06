using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question371
    {
        public static void EntryPoint()
        {
            (new Question371()).GetSum(-2, 5);
        }

        public int GetSum(int a, int b)
        {
            if (a == 0) return b;
            if (b == 0) return a;

            while (b != 0)
            {
                int carry = a & b;
                a = a ^ b;
                b = carry << 1;
            }

            return a;
        }
    }
}