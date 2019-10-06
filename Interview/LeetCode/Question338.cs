using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question338
    {
        public int[] CountBits(int num)
        {
            int[] result = new int[num + 1];

            for (int i = 0; i <= num; i++)
                result[i] = result[i >> 1] + (i & 1);

            return result;
        }
    }
}