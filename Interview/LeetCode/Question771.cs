using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question771
    {
        public int NumJewelsInStones(string J, string S)
        {
            int result = 0;
            Hashtable stones = new Hashtable();

            foreach (var item in S)
                if (!stones.ContainsKey(item))
                    stones.Add(item, 1);
                else
                    stones[item] = (int)stones[item] + 1;

            foreach (var item in J)
                if (stones.ContainsKey(item))
                    result += (int)stones[item];

            return result;
        }
    }
}
