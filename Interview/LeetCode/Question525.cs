using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question525
    {
        public int FindMaxLength(int[] nums)
        {
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            dictionary.Add(0, -1);
            int maxlen = 0,
                count = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                count = count + (nums[i] == 1 ? 1 : -1);

                if (dictionary.ContainsKey(count))
                    maxlen = Math.Max(maxlen, i - dictionary[count]);
                else
                    dictionary.Add(count, i);
            }

            return maxlen;
        }
    }
}
