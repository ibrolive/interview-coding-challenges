using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question477
    {
        public int TotalHammingDistance(int[] nums)
        {
            int result = 0;
            int[] nonZeroes = new int[32];

            foreach (var num in nums)
            {
                int n = num;
                int index = 31;

                while (n != 0)
                {
                    if (n % 2 != 0)
                        nonZeroes[index]++;

                    index--;
                    n = n / 2;
                }
            }

            for (int i = 0; i < 32; i++)
                result += nonZeroes[i] * (nums.Length - nonZeroes[i]);

            return result;
        }
    }
}
