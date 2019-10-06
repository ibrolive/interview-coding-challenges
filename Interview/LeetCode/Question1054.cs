using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question1054
    {
        public int[] RearrangeBarcodes(int[] barcodes)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int pos = 0;

            foreach (var item in barcodes)
            {
                if (!dict.Keys.Contains(item))
                    dict.Add(item, 0);

                dict[item] = dict[item] + 1;
            }

            foreach (var item in dict.Keys.OrderByDescending(key => dict[key]))
            {
                int count = dict[item];

                for (int i = 0; i < count; i++, pos += 2)
                {
                    if (pos >= barcodes.Length)
                        pos = 1;

                    barcodes[pos] = item;
                }
            }

            return barcodes;
        }
    }
}
