using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    class Question645
    {
        public int[] FindErrorNums(int[] nums)
        {
            int[] result = new int[2];
            Hashtable hashtable = new Hashtable();

            foreach (int item in nums)
                if (hashtable.ContainsKey(item))
                    result[0] = item;
                else
                    hashtable.Add(item, null);

            foreach (int item in nums)
            {
                if (item != 1 && !hashtable.ContainsKey(item - 1))
                {
                    result[1] = item - 1;
                    break;
                }
                else if (item != nums.Length && !hashtable.ContainsKey(item + 1))
                {
                    result[1] = item + 1;
                    break;
                }
            }

            return result;
        }
    }
}
