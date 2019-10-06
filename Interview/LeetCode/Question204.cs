using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question204
    {
        // The code is based on the principle: https://zh.wikipedia.org/wiki/%E5%9F%83%E6%8B%89%E6%89%98%E6%96%AF%E7%89%B9%E5%B0%BC%E7%AD%9B%E6%B3%95
        public int CountPrimes(int n)
        {
            int count = 0;
            bool[] isPrimes = new bool[n];

            for (int i = 2; i < n; i++)
            {
                if (!isPrimes[i])
                {
                    count++;

                    for (int j = i; j < n; j = j + i)
                        isPrimes[j] = true;
                }
            }

            return count;
        }
    }
}
