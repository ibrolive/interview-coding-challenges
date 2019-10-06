using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question249
    {
        public IList<IList<string>> GroupStrings(string[] strings)
        {
            if (strings == null || strings.Length == 0)
                return new List<IList<string>>();

            List<IList<string>> result = new List<IList<string>>();
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
            StringBuilder key = new StringBuilder();

            dictionary.Add(Int32.MinValue.ToString(), new List<string>());

            foreach (var item in strings)
            {
                if (item.Length == 1)
                    dictionary[Int32.MinValue.ToString()].Add(item);
                else
                {
                    key.Clear();

                    for (int i = 0; i < item.Length - 1; i++)
                        key.Append(item[i + 1] - item[i] < 0 ? item[i + 1] - item[i] + 26 : item[i + 1] - item[i]);

                    if (!dictionary.ContainsKey(key.ToString()))
                        dictionary.Add(key.ToString(), new List<string>());

                    dictionary[key.ToString()].Add(item);
                }
            }

            foreach (var item in dictionary.Values)
            {
                if (item.Count != 0)
                {
                    item.Sort();
                    result.Add(item);
                }
            }

            return result;
        }
    }
}
