using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question360
    {
        public int[] SortTransformedArray(int[] nums, int a, int b, int c)
        {
            if (nums == null || nums.Length == 0)
                return new int[0];

            int[] sorted = new int[nums.Length];
            int index = a >= 0 ? nums.Length - 1 : 0,
                i = 0,
                j = nums.Length - 1,
                ri = Cal(nums[i], a, b, c),
                rj = Cal(nums[j], a, b, c);

            while (i <= j)
                if (a >= 0)
                {
                    if (ri > rj)
                    {
                        sorted[index--] = ri;
                        i++;
                        if (i <= j)
                            ri = Cal(nums[i], a, b, c);
                    }
                    else
                    {
                        sorted[index--] = rj;
                        j--;
                        if (i <= j)
                            rj = Cal(nums[j], a, b, c);
                    }
                }
                else
                {
                    if (ri < rj)
                    {
                        sorted[index++] = ri;
                        i++;
                        if (i <= j)
                            ri = Cal(nums[i], a, b, c);
                    }
                    else
                    {
                        sorted[index++] = rj;
                        j--;
                        if (i <= j)
                            rj = Cal(nums[j], a, b, c);
                    }
                }

            return sorted;
        }

        public int Cal(int x, int a, int b, int c)
        {
            return (a * x * x + b * x + c);
        }
    }
}
