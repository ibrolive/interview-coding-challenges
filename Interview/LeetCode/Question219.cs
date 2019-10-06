using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question219
    {
        public static void EntryPoint()
        {
            (new Question219()).ContainsNearbyDuplicate(new int[] { 1, 0, 1, 1 }, 1);
        }

        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            Hashtable hash = new Hashtable();

            for (int i = 0; i < nums.Length; i++)
                if (!hash.Contains(nums[i]))
                    hash.Add(nums[i], i);
                else if (i - (int)hash[nums[i]] <= k)
                    return true;
                else
                    hash[nums[i]] = i;

            return false;
        }
    }
}
