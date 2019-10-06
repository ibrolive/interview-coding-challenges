using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question414
    {
        public static void EntryPoint()
        {
            (new Question414()).ThirdMax(new int[] { 1, 2, -2147483648 });
        }

        public int ThirdMax(int[] nums)
        {
            int max1 = Int32.MinValue, max2 = Int32.MinValue, max3 = Int32.MinValue, count = 0;
            bool isMinCounted = false;

            foreach (var item in nums)
            {
                if ((item == max1 && item != Int32.MinValue) ||
                    (item == max2 && item != Int32.MinValue) ||
                    (item == max3 && item != Int32.MinValue) ||
                    (item == Int32.MinValue && isMinCounted))
                    continue;

                if (item == Int32.MinValue && !isMinCounted &&
                    (max1 == Int32.MinValue || max2 == Int32.MinValue || max3 == Int32.MinValue))
                {
                    count++;
                    isMinCounted = true;
                }
                else if (item > max1)
                {
                    count++;
                    max3 = max2;
                    max2 = max1;
                    max1 = item;
                }
                else if (item > max2 && item < max1)
                {
                    count++;
                    max3 = max2;
                    max2 = item;
                }
                else if (item > max3)
                {
                    count++;
                    max3 = item;
                }
            }

            if (count < 3)
                return max1;

            return max3;
        }
    }
}
