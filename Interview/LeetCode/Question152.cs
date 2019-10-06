using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question152
    {
        public int MaxProduct(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;

            int result = nums[0],
                maxProduct = result,
                minProduct = result,
                temp = 0;

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] < 0)
                {
                    temp = maxProduct;
                    maxProduct = minProduct;
                    minProduct = temp;
                }

                maxProduct = Math.Max(nums[i], nums[i] * maxProduct);
                minProduct = Math.Min(nums[i], nums[i] * minProduct);
                result = Math.Max(result, maxProduct);
            }

            return result;
        }
    }
}
