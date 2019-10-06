using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question611
    {
        public int TriangleNumber(int[] nums)
        {
            int count = 0;

            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 2; i++)
            {
                int k = i + 2;

                for (int j = i + 1; j < nums.Length - 1 && nums[i] != 0; j++)
                {
                    while (k < nums.Length && nums[i] + nums[j] > nums[k])
                        k++;

                    count += k - j - 1;
                }
            }

            return count;
        }
    }
}
