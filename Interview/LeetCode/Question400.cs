using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question400
    {
        public static void EntryPoint()
        {
            Console.WriteLine((new Question400()).FindNthDigit(13));
        }

        // https://discuss.leetcode.com/topic/71065/just-explain-no-code/2
        // https://leetcode.com/problems/nth-digit/discuss/88375/Short-Python+Java
        public int FindNthDigit(int n)
        {
            n -= 1;

            int digits = 1,
                first = 1;

            while (n / 9 / first / digits >= 1)
            {
                n -= 9 * first * digits;
                digits++;
                first *= 10;
            }

            return (first + n / digits + "")[n % digits] - '0';
        }
    }
}