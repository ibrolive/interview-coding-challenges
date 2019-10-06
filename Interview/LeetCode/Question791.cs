using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question791
    {
        public static void EntryPoint()
        {
            (new Question791()).CustomSortString("cba", "abcd");
        }

        public string CustomSortString(string S, string T)
        {
            StringBuilder builder = new StringBuilder();
            Hashtable hash = new Hashtable();

            foreach (var item in T)
            {
                if (!hash.ContainsKey(item))
                    hash.Add(item, 0);

                hash[item] = (int)hash[item] + 1;
            }

            foreach (var item in S)
                if (hash.ContainsKey(item))
                {
                    for (int i = 0; i < (int)hash[item]; i++)
                        builder.Append(item);

                    hash.Remove(item);
                }


            foreach (var item in hash.Keys)
                for (int i = 0; i < (int)hash[item]; i++)
                    builder.Append((char)item);

            return builder.ToString();
        }
    }
}
