using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question451
    {
        public static void EntryPoint()
        {
            (new Question451()).FrequencySort("tree");
        }

        public string FrequencySort(string s)
        {
            Hashtable hashtable = new Hashtable();
            int count = 0, maxCount = 0;
            char maxChar = '\u0000';
            StringBuilder result = new StringBuilder();

            foreach (var item in s)
                if (hashtable.ContainsKey(item))
                    hashtable[item] = (int)hashtable[item] + 1;
                else
                    hashtable.Add(item, 1);

            count = hashtable.Count;

            while (count != 0)
            {
                foreach (var item in hashtable.Keys)
                {
                    if ((int)hashtable[item] > maxCount)
                    {
                        maxCount = (int)hashtable[item];
                        maxChar = (char)item;
                    }
                }

                for (int i = 0; i < maxCount; i++)
                    result.Append(maxChar);

                hashtable.Remove(maxChar);
                count = hashtable.Count;
                maxCount = 0;
            }

            return result.ToString();
        }
    }
}
