using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question532
    {
        public static void EntryPoint()
        {
            (new Question532()).FindPairs(new int[] { 3, 1, 4, 1, 5 }, 2);
        }

        public int FindPairs(int[] nums, int k)
        {
            if (k < 0)
                return 0;

            int result = 0;
            System.Collections.Hashtable hash = new System.Collections.Hashtable();

            foreach (var item in nums)
                if (!hash.ContainsKey(item))
                    hash.Add(item, 1);
                else
                    hash[item] = (int)hash[item] + 1;

            foreach (var item in hash.Keys)
                if (k == 0)
                {
                    if ((int)hash[item] > 1)
                        result++;
                }
                else if (hash.ContainsKey((int)item + k))
                    result++;

            return result;
        }
    }
}