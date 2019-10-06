using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question405
    {
        public string ToHex(int num)
        {
            if (num == 0)
                return "0";

            long n = num;
            StringBuilder builder = new StringBuilder();

            if (n < 0)
                n = long.MaxValue - Math.Abs(n) + 1;

            while (n > 0)
            {
                long r = n % 16;

                if (r < 10)
                    builder.Insert(0, r.ToString());
                else
                    builder.Insert(0, ((char)('a' + r - 10)).ToString());

                n /= 16;
            }

            if (builder.Length > 8)
                return builder.ToString().Substring(builder.Length - 8);

            return builder.ToString();
        }
    }
}
