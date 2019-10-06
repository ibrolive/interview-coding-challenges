using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question231
    {
        public bool IsPowerOfTwo(int n)
        {
            if (n <= 0)
                return false;

            int result = 1;

            for (int i = 0; i < 31; i++)
                if (n == (result << i))
                    return true;

            return false;
        }
    }
}
