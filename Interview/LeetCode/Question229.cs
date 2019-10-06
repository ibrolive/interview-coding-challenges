using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question229
    {
        // https://leetcode.com/problems/majority-element-ii/discuss/63520/Boyer-Moore-Majority-Vote-algorithm-and-my-elaboration
        // https://leetcode.com/problems/majority-element-ii/discuss/63502/6-lines-general-case-O(N)-time-and-O(k)-space

        public IList<int> MajorityElement(int[] nums)
        {
            IList<int> result = new List<int>();
            int candidate1 = 0, candidate2 = 0,
                count1 = 0, count2 = 0;

            foreach (var item in nums)
            {
                if (candidate1 == item)
                    count1++;
                else if (candidate2 == item)
                    count2++;
                else if (count1 == 0)
                {
                    candidate1 = item;
                    count1++;
                }
                else if (count2 == 0)
                {
                    candidate2 = item;
                    count2++;
                }
                else
                {
                    count1--;
                    count2--;
                }
            }

            count1 = 0;
            count2 = 0;

            foreach (var item in nums)
                if (item == candidate1)
                    count1++;

            if (count1 > nums.Length / 3)
                result.Add(candidate1);

            foreach (var item in nums)
                if (item == candidate2)
                    count2++;

            if (count2 > nums.Length / 3 && candidate1 != candidate2)
                result.Add(candidate2);

            return result;
        }
    }
}
