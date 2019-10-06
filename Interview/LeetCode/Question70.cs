using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question70
    {
        public int ClimbStairs(int n)
        {
            if (n == 0 || n == 1 || n == 2)
                return n;

            int[] array = new int[n + 1];
            array[1] = 1;
            array[2] = 2;

            for (int i = 3; i <= n; i++)
                array[i] = array[i - 1] + array[i - 2];

            return array[n];
        }

        public int ClimbStairs2(int n)
        {
            int[] a = { 1, 2, 0 };
            int i = 2;

            while (i < n)
            {
                a[i % 3] = a[(i + 1) % 3] + a[(i + 2) % 3];
                i++;
            }

            return a[(n - 1) % 3];
        }
    }
}