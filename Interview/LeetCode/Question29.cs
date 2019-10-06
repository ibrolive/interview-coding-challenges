using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question29
    {
        // https://leetcode.com/problems/divide-two-integers/discuss/13397/Clean-Java-solution-with-some-comment.
        public int Divide(int dividend, int divisor)
        {
            int sign = dividend < 0 ^ divisor < 0 ? -1 : 1;
            long ldividend = Math.Abs((long)dividend),
                 ldivisor = Math.Abs((long)divisor),
                 lresult = Helper(ldividend, ldivisor);

            if (lresult > Int32.MaxValue)
                return sign > 0 ? Int32.MaxValue : Int32.MinValue;
            else
                return sign > 0 ? (int)lresult : -(int)lresult;
        }

        private long Helper(long ldividend, long ldivisor)
        {
            if (ldividend < ldivisor)
                return 0;

            long sum = ldivisor,
                 multiple = 1;

            while ((sum + sum) <= ldividend)
            {
                sum += sum;
                multiple += multiple;
            }

            return multiple + Helper(ldividend - sum, ldivisor);
        }
    }
}
