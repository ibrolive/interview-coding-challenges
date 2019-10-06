using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question1
    {
        public int[] TwoSum(int[] nums, int target)
        {
            Hashtable hash = new Hashtable();

            for (int i = 0; i <= nums.Length - 1; i++)
                if (hash.ContainsKey(target - nums[i]))
                    return new int[] { (int)hash[target - nums[i]], i };
                else if (!hash.ContainsKey(nums[i]))
                    hash.Add(nums[i], i);

            return null;
        }
    }
}