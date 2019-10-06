using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question1122
    {
        public int[] RelativeSortArray(int[] arr1, int[] arr2)
        {
            List<int> results = new List<int>();
            Dictionary<int, int> dict = new Dictionary<int, int>();

            foreach (var item in arr2)
                dict.Add(item, 0);

            foreach (var item in arr1)
                if (dict.ContainsKey(item))
                    dict[item] = dict[item] + 1;
                else
                    results.Add(item);

            results.Sort();

            for (int i = arr2.Length - 1; i > -1; i--)
                while (dict[arr2[i]] > 0)
                {
                    results.Insert(0, arr2[i]);
                    dict[arr2[i]] -= 1;
                }

            return results.ToArray();
        }
    }
}
